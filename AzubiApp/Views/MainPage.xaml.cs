using AzubiApp.Resources.Translate;
using AzubiApp.Services;
using AzubiApp.Models;

namespace AzubiApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _database;
        private string currentLanguage = "en";
        private readonly string defaultLanguage = "en"; // Die Standard-/neutrale Sprache (z. B. Englisch)

        public MainPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<object>(this, "LanguageChanged", (sender) =>
            {
                MainThread.BeginInvokeOnMainThread(() => UpdateUI());
            });
            UpdateUI();

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

        private void UpdateUI()
        {
            // Labels manuell mit den neuen Sprachressourcen aktualisieren
            TitleQuizs.Text = AppResources.QuizLabelTitle;
            TitleUseCases.Text = AppResources.TitleUseCases;
            ContinueQuizButtons.Text = AppResources.ContinueButton;
            TopicssTitle.Text = AppResources.TopicsTitle;
        }

        private void OnLanguageButtonClicked(object sender, EventArgs e)
        {
            // Sprache umschalten
            LanguageManager.ToggleLanguage();
        }

        private async void OnStartUseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UseCasesPage()); // Submitting questions to QuizPage
        }

        private async void OnModuleClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ModulePage());
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
