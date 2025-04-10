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

        public ResultsPage(List<List<string>> userAnswers, List<Question> questions, List<(int QuestionId, bool IsCorrect)> results)
        {
            InitializeComponent();
            Results = new ObservableCollection<ResultItem>();
            BindingContext = this;
            ShowResults(userAnswers, questions);
            MessagingCenter.Subscribe<object>(this, "LanguageChanged", (sender) =>
            {
                MainThread.BeginInvokeOnMainThread(() => UpdateUI());
            });
            UpdateUI();
        }

        private void ShowResults(List<List<string>> userAnswers, List<Question> questions)
        {
            Results.Clear();
            int correctCount = 0;
            var results = new List<(int QuestionId, bool IsCorrect)>();

            for (int i = 0; i < questions.Count; i++)
            {
                var question = questions[i];
                var correctAnswers = question.CorrectAnswers.Split("| ").ToList();
                var userSelected = userAnswers[i];

                bool isCorrect = correctAnswers.All(userSelected.Contains) && correctAnswers.Count == userSelected.Count;
                if (isCorrect) correctCount++;

                results.Add((question.Id, isCorrect)); // Create a result for each question

                Results.Add(new ResultItem
                {
                    QuestionText = $" {i + 1}. {question.Text}",
                    UserAnswerText = $"Ihre Antwort: {string.Join("\n", userSelected)}",
                    CorrectAnswerText = $"Richtige Antwort: {string.Join("\n", correctAnswers)}",
                    ResultText = isCorrect ? "Green" : "BackgroundColor= \"False\"",
                    ResultColor = isCorrect ? Colors.Green : Colors.Red,
                    ShowCorrectAnswer = !isCorrect
                });
            }

            ScoreLabel.Text = $"Richtige Antworten: {correctCount} / {questions.Count}";
            UpdateStats(results);
        }

        private async void UpdateStats(List<(int QuestionId, bool IsCorrect)> results)
        {
            var database = new DatabaseService();
            await database.UpdateQuestionStatsAsync(results);
        }

        private async void OnBackToStartClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private void UpdateUI()
        {
            ResultTitle.Text = AppResources.ResultTitle;
            CorrectAnswerTitle.Text = AppResources.CorrectAnswerTitle;
            BackToStartButton.Text = AppResources.BackToStartButton;
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
    }
}