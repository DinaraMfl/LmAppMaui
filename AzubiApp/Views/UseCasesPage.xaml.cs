namespace AzubiApp.Views;


public partial class UseCasesPage : ContentPage
{
    public UseCasesPage()
    {
        InitializeComponent();
    }



    private async void OnBackUseClicked(object sender, EventArgs e)
    {

        await Navigation.PopAsync();

    }




}