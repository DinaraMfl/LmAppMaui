using AzubiApp.Views;
using AzubiApp.Resources.Translate;
using AzubiApp.Services;

namespace AzubiApp
{
    public partial class AppShell : Shell
    {
        private readonly DatabaseService _database;
        private string currentLanguage = "en";
        private readonly string defaultLanguage = "en";
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(QuizPage), typeof(QuizPage)); //´Register the route
            Routing.RegisterRoute(nameof(UseCasePage), typeof(UseCasePage)); //´Register the route

            MessagingCenter.Subscribe<object>(this, "LanguageChanged", (sender) =>
            {
                MainThread.BeginInvokeOnMainThread(() => UpdateUI());
            });
            UpdateUI();


        }

        private void UpdateUI() 
        {
            AppShellHomeButton.Title = AppResources.AppShellHomeButton;
            AppShellSettingsButton.Title = AppResources.AppShellSettingsButton;

        }
       
    }
}



