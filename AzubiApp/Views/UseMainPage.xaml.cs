namespace AzubiApp.Views;

public partial class UseMainPage : ContentPage
{
	public UseMainPage()
	{
		InitializeComponent();
	}

	// Usecaes Button
	private async void OnStartUseCaseClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new UseCasesPage());
	}

	// UseCases to UseMainPage
	private async void OnBackUseMain(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}

	private async void OnModuleClick(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ModulePage());
    }
}	