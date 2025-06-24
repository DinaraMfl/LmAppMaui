using System.Collections.ObjectModel;
using AzubiApp.Models;
using AzubiApp.Services;
using AzubiApp.Resources.Translate;

namespace AzubiApp.Views
{
    public partial class ResultsPage : ContentPage
    {
        private readonly DatabaseService _database;
        private string currentLanguage = "en";
        private readonly string defaultLanguage = "en";
        public ObservableCollection<ResultItem> Results { get; set; }

        public ResultsPage(List<List<string>> userAnswers, List<Question> questions, List<(int QuestionId, bool IsCorrect)> results, bool category = false)
        {
            InitializeComponent();
            _database = new DatabaseService();
            Shell.SetTabBarIsVisible(this, false);
            Results = new ObservableCollection<ResultItem>();
            BindingContext = this;

            if (category) { ShowResults(userAnswers, questions, category); } // without progress
            else { ShowResults(userAnswers, questions); } // with progress

            MessagingCenter.Subscribe<object>(this, "LanguageChanged", (sender) =>
            {
                MainThread.BeginInvokeOnMainThread(() => UpdateUI());
            });
            UpdateUI();
        }

        private void ShowResults(List<List<string>> userAnswers, List<Question> questions, bool category = false)
        {
            Results.Clear();
            int correctCount = 0;

            List<(int QuestionId, bool IsCorrect)> resultsToUpdate = category ? null : new List<(int QuestionId, bool IsCorrect)>();


            string lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

            string yourAnswerTranlsate = AppResources.ResultPageYourAnswersText;// your answers text 
            string correctAnswersTranlatetText = AppResources.ResultPageCorrectAnswersText; // right answers

            for (int i = 0; i < questions.Count; i++)
            {
                var question = questions[i];
                var correctAnswers = (lang == "de" ? question.CorrectAnswersDe : question.CorrectAnswersEn)
                            .Split("|", StringSplitOptions.TrimEntries)
                            .ToList(); 
                
                var userSelected = userAnswers[i];

                bool isCorrect = correctAnswers.All(userSelected.Contains) && correctAnswers.Count == userSelected.Count;
                if (isCorrect) correctCount++;

                if (!category)
                {
                    resultsToUpdate.Add((question.Id, isCorrect));
                }

                var questionText = lang == "de" ? question.TextDe : question.TextEn;
                var imagePath = lang == "de" ? question.ImagePathDe : question.ImagePathEn;

                Results.Add(new ResultItem
                {
                    QuestionText = $"\t{i + 1}. {questionText}",
                    UserAnswerText = $"\t\t\t{yourAnswerTranlsate} \n{string.Join("\n", userSelected)}", // answers from user - 'Your questions'
                    CorrectAnswerText = $"\n\t\t{correctAnswersTranlatetText} \n{ string.Join("\n", correctAnswers)}", // correct answers from database 'Right questions'
                    ResultText = isCorrect ? "Green" : "BackgroundColor= \"False\"",
                    ResultColor = isCorrect ? Colors.Green : Colors.Red,
                    ShowCorrectAnswer = !isCorrect,
                    ImagePath = string.IsNullOrEmpty(imagePath) ? null : imagePath
                });         
            }

            ScoreLabel.Text = $"{correctCount} / {questions.Count}";

            if (!category)
            {
                UpdateStats(resultsToUpdate);
            }
        }

        private async void UpdateStats(List<(int QuestionId, bool IsCorrect)> results)
        {            
            await _database.UpdateQuestionStatsAsync(results);
        }

        private async void OnBackToStartClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private void UpdateUI()
        {
            ResultTitle.Text = AppResources.ResultTitle;
            CorrectAnswerTitle.Text = AppResources.CorrectAnswerTitle; // correct answers Subtitle (.../...)
            BackToStartButton.Text = AppResources.BackToStartButton;
        }

        protected override bool OnBackButtonPressed()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Navigation.PopToRootAsync();
            });

            return true;
        }
    }

    public class ResultItem
    {
        public string QuestionText { get; set; }
        public string UserAnswerText { get; set; }
        public string CorrectAnswerText { get; set; }
        public string ResultText { get; set; }
        public Color ResultColor { get; set; }
        public bool ShowCorrectAnswer { get; set; }
        public string ScoreLabel { get; set; }
        public string ImagePath { get; set; }
        public bool HasImage => !string.IsNullOrEmpty(ImagePath);
    }
}