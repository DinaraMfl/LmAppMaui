using AzubiApp.Resources.Translate;
using AzubiApp.Services;
using AzubiApp.Models;

namespace AzubiApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _database;
        private bool isUseCaseStarting = false;
        private bool isModuleClicked = false;
        private bool isSelectLevelClicked = false;
        private string currentLanguage = "en";
        private readonly string defaultLanguage = "en";

        public MainPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<object>(this, "LanguageChanged", (sender) =>
            {
                MainThread.BeginInvokeOnMainThread(() => UpdateUI());
            });
            UpdateUI();

            _database = new DatabaseService();
            // Filling the database when the application starts
            Task.Run(async () => await SeedData.Initialize(_database)).Wait();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateProgress();  // Update the progress every time the page appears
        }

        private async void OnSelectLevelClicked(object sender, EventArgs e)
        {
            if (isSelectLevelClicked) return;
            isSelectLevelClicked = true;

            try
            {
                await Navigation.PushAsync(new QuizLevelPage(_database));

            }
            finally
            {
                isSelectLevelClicked = false;
            }
        }

        private void OnLanguageButtonClicked(object sender, EventArgs e)
        {
            LanguageManager.ToggleLanguage();
        }

        private async void OnStartUseClicked(object sender, EventArgs e)
        {
            if (isUseCaseStarting) return;
            isUseCaseStarting = true;

            try
            {
                await Navigation.PushAsync(new UseCasesPage()); // Submitting questions to QuizPage
            }
            finally
            {
                isUseCaseStarting = false;
            }
        }

        private async void OnModuleClicked(object sender, EventArgs e)
        {
            if (isModuleClicked) return;
            isModuleClicked = true;

            try
            {
                await Navigation.PushAsync(new ModulePage());
            }
            finally
            {
                isModuleClicked = false;
            }
        }

        private async void UpdateProgress()
        {
            string mainPageProgressText = AppResources.MainPageProgressText;
            var questions = await _database.GetAllQuestionsAsync();
            int completed = questions.Count(q => q.Points >= Question.MaxPoints);
            double progress = (double)completed / questions.Count;
            ProgressBar.Progress = progress;
            ProgressLabel.Text = $"{mainPageProgressText}: {Math.Round(progress * 100)}%";
        }

        private void UpdateUI()
        {
            QuizSubtitle.Text = AppResources.QuizSubtitle; // Start from where you left off 
            UseCasesSubtitle.Text = AppResources.UseCasesSubtitle; // Learn more about Logomate
            TopicsQuizButton.Text = AppResources.TopicsQuizButton; // Topics / Themengebiete
            MainPageOpenButton.Text = AppResources.MainPageOpenButton; // Open / Öffnen
            MainPageUseCaseTitle.Text = AppResources.MainPageUseCaseTitle; // Use case
            SelectLevelButton.Text = AppResources.SelectLevelButton; // Select Level / Level auswählen
        }
    }
}