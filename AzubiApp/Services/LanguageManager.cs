using AzubiApp.Resources.Translate;
using System.Globalization;
using System.Threading;

namespace AzubiApp
{
    public static class LanguageManager
    {
        private static string currentLanguage = "en"; // Standard-Sprache

        public static void InitializeLanguage()
        {
            string deviceLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            if (deviceLanguage == "de" || deviceLanguage == "en")
                SetLanguage(deviceLanguage);
            else
                SetLanguage("en");
        }

        public static void ToggleLanguage()
        {
            // Wechsel zwischen Englisch und Deutsch
            if (currentLanguage == "en")
                SetLanguage("de");
            else
                SetLanguage("en");
        }

        public static void SetLanguage(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentUICulture = culture;
            AppResources.Culture = culture;
            currentLanguage = cultureCode;

            // Die UI wird benachrichtigt, damit die Labels aktualisiert werden
            MessagingCenter.Send<object>(new object(), "LanguageChanged");
        }

        public static string GetCurrentLanguage() => currentLanguage;
    }
}
