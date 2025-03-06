using AzubiApp.Services;

namespace AzubiApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _database;

        public MainPage()
        {
            InitializeComponent();
            _database = Application.Current.Handler.MauiContext.Services.GetService<DatabaseService>();
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

        private async void OnStartUseClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UseMainPage()); // Submitting questions to QuizPage
        }
    }   
}
