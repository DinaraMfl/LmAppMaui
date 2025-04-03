using AzubiApp.Models;
using System.Collections.ObjectModel;
using AzubiApp.Resources.Translate;
using AzubiApp.Services;

namespace AzubiApp.Views
{
    public partial class ResultsPage : ContentPage
    {
        private readonly DatabaseService _database;
        private string currentLanguage = "en";
        private readonly string defaultLanguage = "en";
        public ObservableCollection<ResultItem> Results { get; set; }
        
        public ResultsPage(List<List<string>> userAnswers, List<Question> questions)
        {
            InitializeComponent();
            Results = new ObservableCollection<ResultItem>();
            BindingContext = this;
            ShowResults(userAnswers, questions);
            MessagingCenter.Subscribe<object>(this, "LanguageChanged", (sender) =>
            {
                Device.BeginInvokeOnMainThread(() => UpdateUI());
            });
            UpdateUI();
        }

        private void ShowResults(List<List<string>> userAnswers, List<Question> questions)
        {
            Results.Clear();
            int correctCount = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                var question = questions[i];
                var correctAnswers = question.CorrectAnswers.Split("| ").ToList();
                var userSelected = userAnswers[i];

                bool isCorrect = correctAnswers.All(userSelected.Contains) && correctAnswers.Count == userSelected.Count;
                if (isCorrect) correctCount++;

                Results.Add(new ResultItem
                {
                    QuestionText = $" {i + 1}. {question.Text}",
                    UserAnswerText = $"Ihre Antwort: {string.Join("\n", userSelected)}",
                    CorrectAnswerText = $"Richtige Antwort: {string.Join("\n", correctAnswers)}",
                    ResultText = isCorrect ? "Green" : "BackgroundColor= \"False\"",
                    ResultColor = isCorrect ? Colors.Green : Colors.Red, 
                    ShowCorrectAnswer = !isCorrect // Shows the correct answer only if there is an error
                });
            }

            ScoreLabel.Text = $" {correctCount} / {questions.Count}";
        }

        private async void OnBackToStartClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

       private void UpdateUI()
       {
            ResultTitles.Text = AppResources.ResultTitle;
            CorrectAnswerTitles.Text = AppResources.CorrectAnswersTitle;
            BackToStart.Text = AppResources.BackToStartButton;
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
