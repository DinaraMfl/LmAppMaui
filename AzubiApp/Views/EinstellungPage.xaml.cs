using System.Globalization;
using AzubiApp.Resources.Translate;

namespace AzubiApp.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            UpdateUI();

            // Höre auf Sprachwechsel
            MessagingCenter.Subscribe<object>(this, "LanguageChanged", (sender) =>
            {
                MainThread.BeginInvokeOnMainThread(() => UpdateUI());
            });
        }

        private void OnLanguageButtonClicked(object sender, EventArgs e)
        {
            ToggleLanguage();
        }

        private void ToggleLanguage()
        {
            string newLanguage = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "en" ? "de" : "en";
            SetLanguage(newLanguage);
        }

        private void SetLanguage(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentUICulture = culture;
            AppResources.Culture = culture;

            // UI-Update auslösen
            MessagingCenter.Send<object>(new object(), "LanguageChanged");
        }

        private void UpdateUI()
        {
            ChangeLanguageButton.Text = AppResources.ChangeLanguageButton;
            Settings.Text = AppResources.Settings;
        }
    }
}
