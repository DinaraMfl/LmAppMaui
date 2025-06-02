namespace AzubiApp.Views;

public partial class UseCasePage : ContentPage
{
    public UseCasePage()
    {
        Shell.SetTabBarIsVisible(this, false);

        InitializeComponent();
        LoadHtmlForAndroidAndWindows();
    }

    private async void LoadHtmlForAndroidAndWindows()
    {
        // Kopiere alle Dateien wie gehabt
        await CopyAssetsToLocalFolder();

        string htmlFolder = Path.Combine(FileSystem.AppDataDirectory, "html");
        string htmlFile = Path.Combine(htmlFolder, "index.html");

        // Lade HTML-Inhalt als String
        string htmlContent = await File.ReadAllTextAsync(htmlFile);

        // Setze baseUrl als "file:///..." (für Android/WebView-Zugriff)
        string baseUrl = $"file://{htmlFolder.Replace("\\", "/")}/";

        webView.Source = new HtmlWebViewSource
        {
            Html = htmlContent,
            BaseUrl = baseUrl
        };
    }

    private async Task CopyAssetsToLocalFolder()
    {
        string[] files = new[]
        {
            "html/index.html",
            "html/style.css",
            "html/imguse/imageCO1.png",
            "html/imguse/imageCO2.png",
            "html/imguse/imageCO3.png"
        };

        foreach (var file in files)
        {
            string targetPath = Path.Combine(FileSystem.AppDataDirectory, file);
            string? dir = Path.GetDirectoryName(targetPath);

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir!);

            if (File.Exists(targetPath))
                File.Delete(targetPath);

            using var asset = await FileSystem.OpenAppPackageFileAsync(file);
            using var dest = File.Create(targetPath);
            await asset.CopyToAsync(dest);
        }
    }
}
