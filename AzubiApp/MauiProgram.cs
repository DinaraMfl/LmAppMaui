using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using AzubiApp.Services;
using AzubiApp.Views;

namespace AzubiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit() // for exander in ResultPage
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Determine the path to the database file in the local storage
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "QuestionsCatalog.db");

            // Copy the database from resources if it does not exist and delete the last version
            File.Delete(dbPath);
            CopyDatabaseIfNotExistsAsync(dbPath);

            // Registering a database context with the SQLite provider
            builder.Services.AddDbContext<QuizDbContext>(options =>
                options.UseSqlite($"Filename={dbPath}"));

            // Registering our database service
            builder.Services.AddSingleton<DatabaseService>();

            // Register MainPage for DI
            builder.Services.AddTransient<MainPage>();

            return builder.Build();
        }

        private static async Task CopyDatabaseIfNotExistsAsync(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                using Stream stream = await FileSystem.OpenAppPackageFileAsync("QuestionsCatalog.db");
                using FileStream fileStream = File.Create(dbPath);
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}
// without EntityFramework, with clear database every time
