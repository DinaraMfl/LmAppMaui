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
        private string currentLanguage = "en";
        private readonly string defaultLanguage = "en";

        public QuizPage(DatabaseService database, List<Question> questions)
        {
            InitializeComponent();
            _database = database ?? throw new ArgumentNullException(nameof(database));

            Shell.SetTabBarIsVisible(this, false);

            if (questions == null || questions.Count == 0)
            {
                DisplayAlert("Error", "The list of questions is empty. Check the database!", "OK");
                return;
            }

            _questions = questions.OrderBy(q => Guid.NewGuid()).ToList();
            _shuffledAnswersList = _questions
                .Select(q => new List<string> { q.Answer1, q.Answer2, q.Answer3 }
                .OrderBy(a => Guid.NewGuid()).ToList()).ToList();

            _currentSelectedAnswers = new List<string>();
            _selectedAnswers.Clear();

            for (int i = 0; i < _questions.Count; i++)
            {
                _selectedAnswers.Add(new List<string>());
            }

            _answeredQuestions = Enumerable.Repeat(false, _questions.Count).ToList();

            ShowQuestion();

            MessagingCenter.Subscribe<object>(this, "LanguageChanged", (sender) =>
            {
                MainThread.BeginInvokeOnMainThread(() => UpdateUI());
            });
            UpdateUI();
        }

        private void ShowQuestion()
        {
            if (_questions == null || _questions.Count == 0)
            {
                DisplayAlert("Fehler", "Keine Fragen gefunden!", "OK");
                return;
            }

            if (_currentIndex >= _questions.Count)
            {
                Navigation.PushAsync(new ResultsPage(_selectedAnswers, _questions, _results));
                return;
            }

            var question = _questions[_currentIndex];
            QuestionCounterLabel.Text = $"{_currentIndex + 1} / {_questions.Count}";
            QuestionLabel.Text = question.Text;

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
            var correctAnswers = question.CorrectAnswers.Split("| ").ToList();

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
                    // Show correct answers in green
                    if (correctAnswers.Contains(label.Text))
                    {
                        label.TextColor = Colors.LimeGreen;
                    }
                }
            }

            // Adjust the button text based on whether the question was already answered
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
            if (!_isAnswerRevealed)
            {
                if (_currentSelectedAnswers.Count == 0)
                {
                    await DisplayAlert("", "Bitte wählen Sie mindestens eine Antwort aus!", "OK");
                    return;
                }

                // Saving answers
                _selectedAnswers[_currentIndex] = new List<string>(_currentSelectedAnswers);
                _answeredQuestions[_currentIndex] = true;

                // Show only correct answers in green
                var question = _questions[_currentIndex];
                var correctAnswers = question.CorrectAnswers.Split("| ").ToList();


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
                return; // Waiting for the second press
            }

            // Second press - go to the next question
            _currentIndex++;

            _isAnswerRevealed = false;

            if (_currentIndex < _questions.Count)
            {
                ShowQuestion();
            }
            else
            {
                await Navigation.PushAsync(new ResultsPage(_selectedAnswers, _questions, new List<(int, bool)>()));
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            if (_currentIndex == 0)
            {
                bool confirmExit = await DisplayAlert("", "Möchten Sie das Quiz verlassen?", "Ja", "Nein");
                if (confirmExit)
                {
                    await Navigation.PopToRootAsync();
                }
            }
            else
            {
                _selectedAnswers[_currentIndex] = new List<string>(_currentSelectedAnswers);
                _currentIndex--;
                ShowQuestion();
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
        }
    }
}