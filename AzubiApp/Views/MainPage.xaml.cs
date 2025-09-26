using AzubiApp.Resources.Translate;
using AzubiApp.Services;
using AzubiApp.Models;

namespace AzubiApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _database;
        private bool isQuizStarting = false;
        private bool isUseCaseStarting = false;
        private bool isModuleClicked = false;
        private string currentLanguage = "en";
        private readonly string defaultLanguage = "en"; // Die Standard-/neutrale Sprache (z. B. Englisch)
        private int _lastCompletedLevel = -1;

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
            if (isQuizStarting) return;
            isQuizStarting = true;

            try
            {
                int numberOfQuestions = 5;

                List<Question> questions = await _database.GetQuestionsForLanguageAsync(currentLanguage, numberOfQuestions); // Loading questions

                if (questions.Count == 0)
                {
                    bool restart = await DisplayAlert(
                                "",
                                AppResources.AlertResetProgress,
                                AppResources.AlertYes,
                                AppResources.AlertNo
                            );

                    if (restart)
                    {
                        await _database.ClearUserProgressAsync();
                        await SeedData.Initialize(_database);

                        _database.ResetCurrentDifficultyLevel();


                        questions = await _database.GetQuestionsForLanguageAsync(currentLanguage, numberOfQuestions);

                        if (questions.Count > 0)
                        {
                            await Navigation.PushAsync(new QuizPage(_database, questions));
                        }
                    }

                    return;
                }

                await Navigation.PushAsync(new QuizPage(_database, questions)); // Submitting questions to QuizPage
            }

            finally
            {
                isQuizStarting = false;
            }
        }

        private void UpdateUI()
        {
            // prachressourcen aktualisieren
            // Labels manuell mit den neuen Sprachressourcen aktualisieren
            QuizSubtitle.Text = AppResources.QuizSubtitle; // Start from where you left off 
            UseCasesSubtitle.Text = AppResources.UseCasesSubtitle; // Learn more about Logomate
            ContinueQuizButton.Text = AppResources.ContinueQuizButton; // Continue
            TopicsQuizButton.Text = AppResources.TopicsQuizButton;
            MainPageOpenButton.Text = AppResources.MainPageOpenButton;
            MainPageUseCaseTitle.Text = AppResources.MainPageUseCaseTitle;
        }

        private void OnLanguageButtonClicked(object sender, EventArgs e)
        {
            // Sprache umschalten
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

        private async void OnModuleClick(object sender, EventArgs e)
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

            int currentLevel = await GetCurrentDifficultyLevelAsync();

            var questions = (await _database.GetAllQuestionsAsync())
                            .Where(q => q.DifficultyLevel == currentLevel)
                            .ToList();
            if (questions.Count == 0)
            {
                ProgressBar.Progress = 1;
                ProgressLabel.Text = $"{mainPageProgressText}: 100% (Level {currentLevel})";
                return;
            }

            int completed = questions.Count(q => q.Points >= Question.MaxPoints);
            double progress = (double)completed / questions.Count;
            ProgressBar.Progress = progress;
            ProgressLabel.Text = $"{mainPageProgressText}: {Math.Round(progress * 100)}% (Level {currentLevel})";
        }

        private async Task<int> GetCurrentDifficultyLevelAsync()
        {
            var questions = await _database.GetAllQuestionsAsync();

            var activeQuestions = questions.Where(q => !(q.Points >= Question.MaxPoints && q.Level == 0))
                                           .OrderBy(q => q.DifficultyLevel)
                                           .ToList();

            if (activeQuestions.Count == 0)
            {
                int lastLevel = questions.Max(q => q.DifficultyLevel);

                if (_lastCompletedLevel != lastLevel)
                {
                    _lastCompletedLevel = lastLevel;

                    await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert(
                            "Quiz Complete",
                            "All levels are completed!",
                            "OK");
                    });
                }

                return lastLevel;
            }

            int currentLevel = activeQuestions.First().DifficultyLevel;

            for (int level = 1; level < currentLevel; level++)
            {
                bool hasActive = questions.Any(q => q.DifficultyLevel == level &&
                                                     !(q.Points >= Question.MaxPoints && q.Level == 0));

                if (!hasActive && _lastCompletedLevel != level)
                {
                    _lastCompletedLevel = level;

                    await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert(
                            "Level Complete",
                            $"Level {level} is completed!",
                            "OK");
                    });
                }
            }

            return currentLevel;
        }
    }
}
