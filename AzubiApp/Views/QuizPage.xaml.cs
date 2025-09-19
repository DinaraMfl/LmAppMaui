using AzubiApp.Models;
using AzubiApp.Services;
using AzubiApp.Resources.Translate;

namespace AzubiApp.Views
{
    public partial class QuizPage : ContentPage
    {
        private readonly List<Question> _questions;
        private int _currentIndex = 0;
        private readonly List<List<string>> _selectedAnswers = new();
        private List<string> _currentSelectedAnswers;
        private Dictionary<CheckBox, Label> _answerMap;
        private List<List<string>> _shuffledAnswersList;
        private readonly DatabaseService _database;
        private readonly List<(int QuestionId, bool IsCorrect)> _results = new();
        private readonly List<bool> _answeredQuestions;
        private bool _isAnswerRevealed = false;
        private readonly bool _category;
        private string currentLanguage = "en";
        private readonly string defaultLanguage = "en";
        private bool _isAlertShowing = false;
        private bool _isSelectAlertShowing = false;
        private bool _isNavigating = false;

        public QuizPage(DatabaseService database, List<Question> questions, bool category = false)
        {
            InitializeComponent();
            _database = database ?? throw new ArgumentNullException(nameof(database));

            Shell.SetTabBarIsVisible(this, false);

            if (questions == null || questions.Count == 0)
            {
                DisplayAlert("", "The list of questions is empty. Check the database!", "OK");
                return;
            }

            _category = category;
            _questions = questions.OrderBy(q => Guid.NewGuid()).ToList();

            _shuffledAnswersList = new List<List<string>>();

            foreach (var question in _questions)
            {
                string lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
                var answerOptions = lang == "de"
                    ? new List<string> { question.Answer1De, question.Answer2De, question.Answer3De }
                    : new List<string> { question.Answer1En, question.Answer2En, question.Answer3En };

                var shuffled = answerOptions.OrderBy(a => Guid.NewGuid()).ToList();
                _shuffledAnswersList.Add(shuffled);
            }

            _currentSelectedAnswers = new List<string>();
            _selectedAnswers.Clear();

            for (int i = 0; i < _questions.Count; i++)
            {
                _selectedAnswers.Add(new List<string>());
            }

            _answeredQuestions = Enumerable.Repeat(false, _questions.Count).ToList();

            if (category) ShowQuestion(category);
            else ShowQuestion();

            MessagingCenter.Subscribe<object>(this, "LanguageChanged", (sender) =>
            {
                MainThread.BeginInvokeOnMainThread(() => UpdateUI());
            });
            UpdateUI();
        }

        private void ShowQuestion(bool category = false)
        {
            if (_questions == null || _questions.Count == 0)
            {
                DisplayAlert("", "No questions found!", "OK");
                return;
            }

            if (_currentIndex >= _questions.Count)
            {
                Navigation.PushAsync(new ResultsPage(_selectedAnswers, _questions, _results, category));
                return;
            }

            if (category) ExitModuleQuizButton.IsVisible = true;

            var question = _questions[_currentIndex];
            QuestionCounterLabel.Text = $"{_currentIndex + 1} / {_questions.Count}";

            string lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

            QuestionLabel.Text = lang == "de" ? question.TextDe : question.TextEn;

            if (lang == "de" && !string.IsNullOrEmpty(question.ImagePathDe))
            {
                QuestionImage.Source = $"Images/QuestionsImage/De/{question.ImagePathDe}";
                QuestionImage.IsVisible = true;
            }
            else if (lang == "en" && !string.IsNullOrEmpty(question.ImagePathEn))
            {
                QuestionImage.Source = $"Images/QuestionsImage/En/{question.ImagePathEn}";
                QuestionImage.IsVisible = true;
            }
            else
            {
                QuestionImage.IsVisible = false;
            }

            var answerOptions = lang == "de"
                ? new List<string> { question.Answer1De, question.Answer2De, question.Answer3De }
                : new List<string> { question.Answer1En, question.Answer2En, question.Answer3En };

            var shuffledAnswers = _shuffledAnswersList[_currentIndex];

            Answer1Text.Text = shuffledAnswers[0];
            Answer2Text.Text = shuffledAnswers[1];
            Answer3Text.Text = shuffledAnswers[2];

            _answerMap = new Dictionary<CheckBox, Label>
            {
                { Answer1, Answer1Text },
                { Answer2, Answer2Text },
                { Answer3, Answer3Text }
            };

            _currentSelectedAnswers = new List<string>(_selectedAnswers[_currentIndex]);
            bool isLocked = _answeredQuestions[_currentIndex];

            var correctAnswers = (lang == "de" ? question.CorrectAnswersDe : question.CorrectAnswersEn)
                .Split("|", StringSplitOptions.TrimEntries)
                .ToList();

            foreach (var pair in _answerMap)
            {
                var checkBox = pair.Key;
                var label = pair.Value;

                checkBox.IsChecked = _selectedAnswers[_currentIndex].Contains(label.Text);
                checkBox.IsEnabled = !isLocked;
                checkBox.Color = isLocked ? Colors.Gray : Colors.White;
                label.TextColor = Colors.White;

                if (isLocked)
                {
                    if (correctAnswers.Contains(label.Text))
                    {
                        label.TextColor = Colors.LimeGreen;
                    }
                }
            }

            if (isLocked)
            {
                NextQuizButton.Text = (_currentIndex == _questions.Count - 1) ? AppResources.FinishButton : AppResources.NextQuizButton;
            }
            else
            {
                NextQuizButton.Text = AppResources.CheckButton;
            }

            _isAnswerRevealed = isLocked;
        }

        private void OnAnswerChecked(object sender, CheckedChangedEventArgs e)
        {
            if (_answeredQuestions[_currentIndex])
                return;

            if (sender is CheckBox checkBox && _answerMap.ContainsKey(checkBox))
            {
                string selectedText = _answerMap[checkBox].Text;
                if (e.Value)
                    _currentSelectedAnswers.Add(selectedText);
                else
                    _currentSelectedAnswers.Remove(selectedText);
            }
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            if (_isNavigating) return;

            if (!_isAnswerRevealed)
            {
                if (_currentSelectedAnswers.Count == 0)
                {
                    if (_isSelectAlertShowing) return;
                    _isSelectAlertShowing = true;

                    await DisplayAlert(AppResources.AlertError, AppResources.AlertSelect, "OK");
                    _isSelectAlertShowing = false;

                    return;
                }

                _selectedAnswers[_currentIndex] = new List<string>(_currentSelectedAnswers);
                _answeredQuestions[_currentIndex] = true;

                var question = _questions[_currentIndex];
                string lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

                var correctAnswers = (lang == "de" ? question.CorrectAnswersDe : question.CorrectAnswersEn)
                    .Split("|", StringSplitOptions.TrimEntries)
                    .ToList();

                foreach (var pair in _answerMap)
                {
                    var checkBox = pair.Key;
                    var label = pair.Value;

                    if (correctAnswers.Contains(label.Text))
                    {
                        label.TextColor = Colors.LimeGreen;
                    }

                    checkBox.IsEnabled = false;
                    checkBox.Color = Colors.Gray;
                }

                // Change the button text
                NextQuizButton.Text = (_currentIndex == _questions.Count - 1) ? AppResources.FinishButton : AppResources.NextQuizButton;

                _isAnswerRevealed = true;
                return;
            }

            _currentIndex++;

            _isAnswerRevealed = false;

            if (_currentIndex < _questions.Count)
            {
                ShowQuestion();
            }
            else
            {
                _isNavigating = true;
                await Navigation.PushAsync(new ResultsPage(_selectedAnswers, _questions, new List<(int, bool)>(), _category));
                _isNavigating = false;
            }
        }

        protected override bool OnBackButtonPressed()
        {   
            _ = OnAndroidBackPressed();
            return true; 
        }

        private async Task OnAndroidBackPressed() // Die funktion ist für die zurück fuktion vom Andriod handy mit alert
        {
            if (_currentIndex == 0)
            {
                if (_isAlertShowing) return;
                _isAlertShowing = true;

                bool confirmExit = await DisplayAlert(
                    "",
                    AppResources.AlertLeaveQuiz,
                    AppResources.AlertYes,
                    AppResources.AlertNo
                );

                _isAlertShowing = false;

                if (confirmExit)
                {
                    await Navigation.PopAsync();
                }
            }
            else
            {
                _selectedAnswers[_currentIndex] = new List<string>(_currentSelectedAnswers);
                _currentIndex--;
                ShowQuestion();
            }
        }

        private async void OnBackClicked(object sender, EventArgs e) // Die funktion ist normale zurück button mit alert
        {
            if (_currentIndex == 0)
            {
                if (_isAlertShowing) return;
                _isAlertShowing = true;

                bool confirmExit = await DisplayAlert("", AppResources.AlertLeaveQuiz,AppResources.AlertYes,AppResources.AlertNo);

                _isAlertShowing = false;

                if (confirmExit)
                {
                    await Navigation.PopAsync();
                }
            }
            else
            {
                _selectedAnswers[_currentIndex] = new List<string>(_currentSelectedAnswers);
                _currentIndex--;
                ShowQuestion();
            }
        }

        private async void OnExitClicked(object sender, EventArgs e) // Die funktion ist normale zurück button mit alert
        {
            if (_isAlertShowing) return;
            _isAlertShowing = true;

            bool confirmExit = await DisplayAlert("", AppResources.AlertLeaveQuiz, AppResources.AlertYes, AppResources.AlertNo);

            _isAlertShowing = false;

            if (confirmExit)
            {
                await Navigation.PopAsync();
            }
        }

        private void OnAnswerTapped(object sender, EventArgs e)
        {
            if (_answeredQuestions[_currentIndex])
                return;

            if (sender is Label label && label.Parent is HorizontalStackLayout parent)
            {
                var checkBox = parent.Children.OfType<CheckBox>().FirstOrDefault();
                if (checkBox != null)
                {
                    checkBox.IsChecked = !checkBox.IsChecked;
                }
            }
        }

        private void UpdateUI()
        {
            BackQuizButton.Text = AppResources.BackQuizButton; // Back / Zurück
            ExitModuleQuizButton.Text = AppResources.ExitModuleQuizButton; // Exit / Beenden
        }
    }
}