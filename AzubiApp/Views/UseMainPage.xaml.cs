using AzubiApp.Services;
using AzubiApp.Models;



namespace AzubiApp.Views;

public partial class UseMainPage : ContentPage
{
	public UseMainPage()
	{
		InitializeComponent();
	}

	private async void OnStartUseCaseClicked(object sender, EventArgs e)
	{

		await Navigation.PushAsync(new UseCasesPage());


	}




	private async void OnBackUseMain(object sender, EventArgs e)
	{


		await Navigation.PopAsync();
	}



	private async void OnModuleClick(object sender, EventArgs e)
	{


		await Navigation.PushAsync(new ModulePage());


    }



	




}	