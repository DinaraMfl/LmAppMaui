using AzubiApp.Resources.Translate;
using AzubiApp.Services;

namespace AzubiApp.Views;

public partial class ModulePage : ContentPage
{
	private readonly DatabaseService _database;
	private string currentLanguage = "en";
	private readonly string defaultLanguage = "en";

	public ModulePage()
	{
		InitializeComponent();
        _database = new DatabaseService();

        MessagingCenter.Subscribe<object>(this, "LanguageChanged", (sender) =>
		{
            MainThread.BeginInvokeOnMainThread(() => UpdateUI());
        });
        UpdateUI();
    }

    private async void OnCategorySelected(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            string selectedCategory = button.CommandParameter?.ToString();

            if (string.IsNullOrEmpty(selectedCategory))
                return;

            await StartQuizWithCategory(selectedCategory);
        }
    }

    // Startet das Quiz mit Fragen zur gewählten Kategorie
    private async Task StartQuizWithCategory(string category)
    {
        var allQuestions = await _database.GetAllQuestionsAsync();

        var filteredQuestions = allQuestions
          .Where(q => q.QuizCategory.Any(cat =>
              cat.Trim().Equals(category.Trim(), StringComparison.OrdinalIgnoreCase)))
          .OrderBy(q => Guid.NewGuid())
          .ToList();

        if (filteredQuestions.Count == 0)
        {
            await DisplayAlert("Fehler", $"Keine Fragen zur Kategorie '{category}' gefunden!", "OK");
            return;
        }

        await Navigation.PushAsync(new QuizPage(_database, filteredQuestions, true));
    }

    private async void OnBackModuleMain(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}

	private void UpdateUI()
	{
        OrderButton.Text = AppResources.OrderButton;
        ParameterButton.Text = AppResources.ParameterButton;
        ConditionsButton.Text = AppResources.ConditionsButton;
        ForecastButton.Text = AppResources.ForecastButton;
        FilterButton.Text = AppResources.FilterButton;       
        GeneralButton.Text = AppResources.GeneralButton;
        BackModuleButton.Text = AppResources.BackModuleButton;
    }
}