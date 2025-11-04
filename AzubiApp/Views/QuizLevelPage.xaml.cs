using AzubiApp.Models;
using AzubiApp.Resources.Translate;
using AzubiApp.Services;

namespace AzubiApp.Views;

public partial class QuizLevelPage : ContentPage
{
    private readonly DatabaseService _database;
    private bool isQuizStarting = false;
    private string currentLanguage = "en";
    private readonly string defaultLanguage = "en";
    private string _selectedLevel = null; 

    public QuizLevelPage(DatabaseService database)
	{
		InitializeComponent();
        _database = database ?? throw new ArgumentNullException(nameof(database));


        MessagingCenter.Subscribe<object>(this, "LanguageChanged", (sender) =>
        {
            MainThread.BeginInvokeOnMainThread(() => UpdateUI());
        });
        UpdateUI();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateProgress();  // Update the progress every time the page appears
    }

    private void OnLevelCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            var radioButton = sender as RadioButton;

            if (radioButton != null)
            {
                _selectedLevel = radioButton.Value.ToString();
            }
        }
    }

    private async void OnStartQuizClicked(object sender, EventArgs e)
    {
        if (_selectedLevel == null || !int.TryParse(_selectedLevel, out int selectedLevel))
        {
            await DisplayAlert("", AppResources.SelectYourLevelTitle, "OK");
            return;
        }

        if (isQuizStarting) return;
        isQuizStarting = true;

        try
        {
            int numberOfQuestions = 15;

            var allLevelQuestions = (await _database.GetAllQuestionsAsync())
                                    .Where(q => q.DifficultyLevel == selectedLevel)
                                    .ToList();

            bool isLevelCompleted = allLevelQuestions.Count > 0 &&
                                    allLevelQuestions.All(q => q.Points >= Question.MaxPoints)
                                    && allLevelQuestions.All(q => q.Level == 0);
            
            if (isLevelCompleted)
            {
                bool restart = await DisplayAlert(
                            "",
                            AppResources.AlertResetProgress,
                            AppResources.AlertYes,
                            AppResources.AlertNo
                        );

                if (restart)
                {
                    await _database.ClearUserProgressByLevelAsync(selectedLevel);
                    await SeedData.Initialize(_database);
                } 
                else return;
            }

                var questions = await _database.GetQuestionsForLanguageAndLevelAsync(currentLanguage, selectedLevel, numberOfQuestions);

                if (questions.Count == 0)
                {
                    await DisplayAlert("Error", "No questions available for this level.", "OK");
                    return;
                }
            
            await Navigation.PushAsync(new QuizPage(_database, questions));
        }

        finally
        {
            isQuizStarting = false;
        }
    }

    private async void UpdateProgress()
    {
        string mainPageProgressText = AppResources.MainPageProgressText;
        var allQuestions = await _database.GetAllQuestionsAsync();

        for (int level = 1; level <= 3; level++)
        {
            var levelQuestions = allQuestions.Where(q => q.DifficultyLevel == level).ToList();
            double progress = 0;

            if (levelQuestions.Count > 0)
            {
                int completed = levelQuestions.Count(q => q.Points >= Question.MaxPoints);
                progress = (double)completed / levelQuestions.Count;
            }
            else
            {
                progress = 1; 
            }

            switch (level)
            {
                case 1:
                    ProgressBar1.Progress = progress;
                    ProgressLabel1.Text = $"{mainPageProgressText}: {Math.Round(progress * 100)}%";
                    break;
                case 2:
                    ProgressBar2.Progress = progress;
                    ProgressLabel2.Text = $"{mainPageProgressText}: {Math.Round(progress * 100)}%";
                    break;
                case 3:
                    ProgressBar3.Progress = progress;
                    ProgressLabel3.Text = $"{mainPageProgressText}: {Math.Round(progress * 100)}%";
                    break;
            }
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void UpdateUI()
    {
        ContinueQuizButton.Text = AppResources.ContinueQuizButton;
        SelectYourLevelTitle.Text = AppResources.SelectYourLevelTitle;
        BackQuizButton.Text = AppResources.BackQuizButton;
    }
}