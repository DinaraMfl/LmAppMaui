using System.Globalization;
using System.Threading;
using AzubiApp.Resources; // Stelle sicher, dass du den richtigen Namespace für AppResources verwendest
using AzubiApp.Resources.Translate;
using Microsoft.Maui.Controls;

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
                Device.BeginInvokeOnMainThread(() => UpdateUI());
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
            LanguageButton.Text = AppResources.ChangeLanguageButton;
            MyLabel.Text = AppResources.Einstellungen;
        }
    }
}
