using AzubiApp.Resources.Translate;
using AzubiApp.Services;
using System.Globalization;

using System.Globalization;
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
            _database = Application.Current.Handler.MauiContext.Services.GetService<DatabaseService>();

            MessagingCenter.Subscribe<object>(this, "LanguageChanged", (sender) =>
            {
                Device.BeginInvokeOnMainThread(() => UpdateUI());
            });

            UpdateUI();

        }

        private async void OnStartQuizClicked(object sender, EventArgs e)
        {
            int numberOfQuestions = 5;

            var questions = await _database.GetShuffledQuestionsAsync(numberOfQuestions); // Loading questions

            if (questions.Count == 0)
            {
                await DisplayAlert("Error", "No questions available!", "OK");
                return;
            }

            await Navigation.PushAsync(new QuizPage(questions)); // Submitting questions to QuizPage
        }

        private void UpdateUI()
        {
            // Labels manuell mit den neuen Sprachressourcen aktualisieren
            TitleQuizs.Text = AppResources.QuizLabelTitle;
            TitleUseCases.Text = AppResources.TitleUseCases;
            ContinueQuizButtons.Text = AppResources.ContinueButton;
         
        }

        private void OnLanguageButtonClicked(object sender, EventArgs e)
        {
            // Sprache umschalten
            LanguageManager.ToggleLanguage();
        }

        private async void OnStartUseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UseMainPage()); // Submitting questions to QuizPage
        }
    }   
}
