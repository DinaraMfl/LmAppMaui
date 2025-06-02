using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using MauiWebView = Microsoft.Maui.Controls.WebView;
#if ANDROID
using AndroidWebView = Android.Webkit.WebView;
#endif

namespace AzubiApp.Views
{
    public partial class UseCasePage : ContentPage
    {
        public UseCasePage()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, false);

#if ANDROID
            // Registriere Event, sobald der native Handler existiert
            webView.HandlerChanged += OnHandlerChanged;
#endif
            // HTML-Inhalte in die AppData kopieren und laden
            LoadHtmlAsync();
        }

#if ANDROID
        private void OnHandlerChanged(object sender, EventArgs e)
        {
            // Warten, bis der Handler verfügbar ist
            var native = webView.Handler?.PlatformView as AndroidWebView;
            if (native == null)
                return;

            // Android-spezifische Einstellungen
            native.Settings.AllowFileAccess = true;
            native.Settings.AllowFileAccessFromFileURLs = true;
            native.Settings.AllowUniversalAccessFromFileURLs = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // Event wieder abmelden, um Leaks zu vermeiden
            webView.HandlerChanged -= OnHandlerChanged;
        }
#endif

        private async void LoadHtmlAsync()
        {
            try
            {
                await CopyHtmlAssetsToAppData();

                var htmlDir = Path.Combine(FileSystem.AppDataDirectory, "html");
                var htmlFile = Path.Combine(htmlDir, "index.html");
                string html = await File.ReadAllTextAsync(htmlFile);

                // Android und iOS erwarten file://-Pfad mit Slashes
                var baseUrl = $"file://{htmlDir.Replace("\\", "/")}/";

                webView.Source = new HtmlWebViewSource
                {
                    Html = html,
                    BaseUrl = baseUrl
                };
            }
            catch (Exception ex)
            {
                // Debug-Ausgabe, falls beim Laden etwas schiefgeht
                System.Diagnostics.Debug.WriteLine($"Fehler beim Laden des HTML: {ex}");
            }
        }

        private async Task CopyHtmlAssetsToAppData()
        {
            // Hartkodierte Liste deiner HTML-Assets (Dateien in Resources/Raw oder im Projektordner)
            string[] assets = new[]
            {
                "html/index.html",
                "html/style.css",
                "html/imguse/imagecos.png",
                "html/imguse/imagecow.png",
                "html/imguse/imagecox.png"
            };

            foreach (var asset in assets)
            {
                var destPath = Path.Combine(FileSystem.AppDataDirectory, asset);
                var destDir = Path.GetDirectoryName(destPath)!;
                if (!Directory.Exists(destDir))
                    Directory.CreateDirectory(destDir);

                if (File.Exists(destPath))
                    File.Delete(destPath);

                // Kopiere Asset aus dem APK/App-Paket in AppData
                using var inStream = await FileSystem.OpenAppPackageFileAsync(asset);
                using var outStream = File.Create(destPath);
                await inStream.CopyToAsync(outStream);
            }
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Prüfen, ob Seite im Push-Stack ist
                if (Navigation?.NavigationStack.Count > 1)
                {
                    await Navigation.PopAsync();
                }
                // Falls modal geöffnet (PushModalAsync), dann schließen
                else if (Navigation?.ModalStack.Count > 0)
                {
                    await Navigation.PopModalAsync();
                }
                // Fallback: Shell-Back, falls Shell verwendet wird
                else if (Shell.Current != null)
                {
                    await Shell.Current.GoToAsync("..");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Back-Button-Fehler: {ex}");
            }
        }
    }
}
