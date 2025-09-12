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
                "html/imguse/imagecox.png",
                "html/imguse/imagesib1.png",
                "html/imguse/imagesib2.png",
                "html/imguse/imagesib3.png",
                "html/imguse/imagesib4.png",
                "html/imguse/imagesib5.png",
                "html/imguse/imagesib6.png",
                "html/imguse/imagesib7.png",
                "html/imguse/imagesib8.png",
                "html/imguse/imagesib9.png",
                "html/imguse/imagesplit1.png",
                "html/imguse/imagesplit2.png",
                "html/imguse/imagesplit3.png",
                "html/imguse/imagesplit4.png",
                "html/imguse/imageuml1.png",
                "html/imguse/imageuml2.png",
                "html/imguse/imagepuflo1.png",
                "html/imguse/imagepuflo2.png",
                "html/imguse/imagepuflo3.png",
                "html/imguse/imagepuflo4.png",
                "html/imguse/imagepuflo5.png",
                "html/imguse/imagepuflo6.png",
                "html/imguse/imagepuflo7.png",
                "html/imguse/imagepuflo8.png",
                "html/imguse/imageabc1.png",
                "html/imguse/imageabc2.png",
                "html/imguse/imageabc3.png",
                "html/imguse/imageabc4.png",
                "html/imguse/imageabc5.png",
                "html/imguse/imageabc6.png",
                "html/imguse/imageabc7.png",
                "html/imguse/imageabc8.png",
                "html/imguse/imageabc9.png",
                "html/imguse/imageabc10.png",
                "html/imguse/imageabc11.png",
                "html/imguse/imageabc12.png",
                "html/imguse/imageabc13.png",
                "html/imguse/imageabc14.png",
                "html/imguse/imageauto1.png",
                "html/imguse/imageauto2.png",
                "html/imguse/imagever1.png",
                "html/imguse/imagever2.png",
                "html/imguse/imageliefryhth1.png",
                "html/imguse/imageliefryhth2.png",
                "html/imguse/imagepar1.png",
                "html/imguse/imagepar2.png",
                "html/imguse/imagepar3.png",
                "html/imguse/imagepar4.png",
                "html/imguse/imagepar5.png",
                "html/imguse/imagefil1.png",
                "html/imguse/imagefil2.png",
                "html/imguse/imagefil3.png",
                "html/imguse/imagefil4.png",
                "html/imguse/imagefil5.png",
                "html/imguse/imagewie1.png",
                "html/imguse/imagewie2.png",
                "html/imguse/imagewie3.png",
                "html/imguse/imagevor1.png",
                "html/imguse/imagevor2.png",
                "html/imguse/imageakt1.png",
                "html/imguse/imageakt2.png",
                "html/imguse/imageakt3.png",
                "html/imguse/imagekon1.png",
                "html/imguse/imagekon2.png",
                "html/imguse/imagevbe1.png",
                "html/imguse/imagevbe1en.png",
                "html/imguse/imagevbe2.png",
                "html/imguse/imagevbe2en.png",
                "html/imguse/imagevbe3.png",
                "html/imguse/imagevbe3en.png",
                "html/imguse/imagespo1.png",
                "html/imguse/imagespo1en.png",
                "html/imguse/imagesai1.png",
                "html/imguse/imagesai2.png",
                "html/imguse/imagesai3.png",
                "html/imguse/imagesai3en.png",
                "html/imguse/imagesai4.png",
                "html/imguse/imagesai4en.png",
                "html/imguse/imagesai5.png",
                "html/imguse/imagesai6.png",
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
