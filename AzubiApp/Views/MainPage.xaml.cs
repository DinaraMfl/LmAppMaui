using AzubiApp.Services;
using AzubiApp.Models;

namespace AzubiApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _database;

        public MainPage()
        {
            InitializeComponent();
            _database = new DatabaseService();  // Initializing the database

            // Filling the database when the application starts
            Task.Run(async () => await SeedData.Initialize(_database)).Wait();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateProgress();  // Update the progress every time the page appears
        }

        private async void OnStartQuizClicked(object sender, EventArgs e)
        {
            int numberOfQuestions = 5;
            var database = new DatabaseService(); 

            List<Question> questions = await _database.GetShuffledQuestionsAsync(numberOfQuestions); // Loading questions

            if (questions.Count == 0)
            {
                await DisplayAlert("Error", "No questions available!", "OK");
                return;
            }

            await Navigation.PushAsync(new QuizPage(database, questions)); // Submitting questions to QuizPage
        }

        private async void OnStartUseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UseMainPage()); // Submitting questions to QuizPage
        }

        private async void UpdateProgress()
        {
            var questions = await _database.GetAllQuestionsAsync();
            int completed = questions.Count(q => q.Points >= Question.MaxPoints);
            double progress = (double)completed / questions.Count;
            ProgressBar.Progress = progress;
            ProgressLabel.Text = $"Fortschritt: {Math.Round(progress * 100)}%";
        }
    }
}
