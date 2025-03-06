using AzubiApp.Services;
using AzubiApp.Models;



namespace AzubiApp.Views;

public partial class ModulePage : ContentPage
{
	public ModulePage()
	{
		InitializeComponent();
	}

	private async void OnBackModuleMain(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}

    
}