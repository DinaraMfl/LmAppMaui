using System.Globalization;
using AzubiApp.Resources.Translate;
#if ANDROID
using AndroidWebView = Android.Webkit.WebView;
#endif

namespace AzubiApp.Views
{
    public partial class UseCasePage : ContentPage
    {
        private string currentLanguage = "en";
        private readonly string defaultLanguage = "en";
        private readonly string sectionId;

        public UseCasePage(string sectionId)
        {
            InitializeComponent();
            this.sectionId = sectionId;

            Shell.SetTabBarIsVisible(this, false);

            MessagingCenter.Subscribe<object>(this, "LanguageChanged", (sender) =>
            {
                MainThread.BeginInvokeOnMainThread(() => UpdateUI());
            });
            UpdateUI();

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

                var currentLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToLowerInvariant();
                string localizedFileName = currentLanguage == "de" ? "indexDe.html" : "indexEn.html";

                var htmlDir = Path.Combine(FileSystem.AppDataDirectory, "html");
                var htmlFile = Path.Combine(htmlDir, localizedFileName);

                if (!File.Exists(htmlFile))
                {
                    htmlFile = Path.Combine(htmlDir, "indexEn.html");
                }

                string html = await File.ReadAllTextAsync(htmlFile);

                // Android и iOS ожидают путь в формате file://
                var baseUrl = $"file://{htmlDir.Replace("\\", "/")}/";

                if (!string.IsNullOrEmpty(sectionId))
                {
                    html += $@"
                        <script>
                            document.addEventListener('DOMContentLoaded', function () {{
                                const allSections = document.querySelectorAll('section');
                                allSections.forEach(s => s.style.display = 'none');
                                const target = document.getElementById('{sectionId}');
                                if (target) {{
                                    target.style.display = 'block';
                                }}
                            }});
                        </script>";
                }

                webView.Source = new HtmlWebViewSource
                {
                    Html = html,
                    BaseUrl = baseUrl
                };
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Fehler beim Laden des HTML: {ex}");
            }
        }

        private async Task CopyHtmlAssetsToAppData()
        {
            // Hartkodierte Liste deiner HTML-Assets (Dateien in Resources/Raw oder im Projektordner)
            string[] assets = new[]
            {
                "html/indexDe.html",
                "html/indexEn.html",
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

        private void UpdateUI()
        {
            UseCaseBackButton.Text = AppResources.UseCaseBackButton;
            LoadHtmlAsync(); 
        }
    }     
}
