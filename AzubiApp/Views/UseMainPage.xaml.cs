using AzubiApp.Resources.Translate;
using AzubiApp.Services;

namespace AzubiApp.Views;

public partial class UseMainPage : ContentPage
{
	private readonly DatabaseService _database;
	private string currentLanguage = "en";
	private readonly string defaultLanguage = "en";
	public UseMainPage()
	{
		InitializeComponent();

		MessagingCenter.Subscribe<object>(this, "LanguageChanged", (sender) =>
		{
			Device.BeginInvokeOnMainThread(() => UpdateUI());
		});
		UpdateUI();
	}

	// Usecaes Button
	private async void OnStartUseCaseClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new UseCasesPage());
	}

	// UseCases to UseMainPage
	private async void OnBackUseMain(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("//MainPage");
    }

	private async void OnModuleClick(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ModulePage());
    }

	private void UpdateUI()
	{
        TopicTitle.Text = AppResources.TopicsTitle;
        LearnApplyMastering.Text = AppResources.LearnApplyMaster;
		BackButtons.Text = AppResources.BackButton;
		LearnSomethingNew.Text = AppResources.LearnSomethingNewButton;
    }
}	