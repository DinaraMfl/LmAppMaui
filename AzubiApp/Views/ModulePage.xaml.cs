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
        OrderButton.Text = AppResources.OrderButton;
        ParameterButton.Text = AppResources.ParameterButton;
        ConditionsButton.Text = AppResources.ConditionsButton;
        ForecastButton.Text = AppResources.ForecastButton;
        FilterButton.Text = AppResources.FilterButton;       
        GeneralButton.Text = AppResources.GeneralButton;
        BackModuleButton.Text = AppResources.BackModuleButton;
    }
}