using System;
using System.IO;
using System.Threading.Tasks;

namespace AzubiApp.Views;

public partial class UseCasePage : ContentPage
{
    public UseCasePage()
    {
        InitializeComponent();
        LoadHtmlWithCssAndImages();
    }

    private async void LoadHtmlWithCssAndImages()
    {
        await CopyAssetsToLocalFolder();

        var htmlFilePath = Path.Combine(FileSystem.AppDataDirectory, "html", "index.html");

        // 🔥 WICHTIG: WebView braucht "file://" + Slashs
        string url = $"file://{htmlFilePath.Replace("\\", "/")}";

        webView.Source = new UrlWebViewSource
        {
            Url = url
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
