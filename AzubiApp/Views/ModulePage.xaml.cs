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
		MessagingCenter.Subscribe<object>(this, "LanguageChanged", (sender) =>
		{
            MainThread.BeginInvokeOnMainThread(() => UpdateUI());
        });
        UpdateUI();
    }

	private async void OnBackModuleMain(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}

	private void UpdateUI()
	{
		BackButtons.Text = AppResources.BackButton;
		GeneralsButton.Text = AppResources.GeneralButton;
		FiltersButton.Text = AppResources.FilterButton;
		ParametersButton.Text = AppResources.ParameterButton;
		ConditionssButton.Text = AppResources.ConditionsButton;
		OrdersButtons.Text = AppResources.OrderButton;
		ForcastsButton.Text = AppResources.ForecastButton;
	}
}