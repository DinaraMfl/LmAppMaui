using AzubiApp.Resources.Translate;
using AzubiApp.Services;

namespace AzubiApp.Views;

public partial class UseCasesPage : ContentPage
{
    private readonly DatabaseService _database;
    private string currentLanguage = "en";
    private readonly string defaultLanguage = "en";
    public UseCasesPage()
    {
        InitializeComponent();
        MessagingCenter.Subscribe<object>(this, "LanguageChanged", (sender) =>
        {
            MainThread.BeginInvokeOnMainThread(() => UpdateUI());
        });
        UpdateUI();

    }

    private async void OnUseCaseClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UseCasePage());
    }


    private async void OnBackUseClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();   
    }


    private void UpdateUI()
    {
        UseCaseAutoStoreButton.Text = AppResources.UseCaseAutoStoreButton;
        UseCaseTransferButton.Text = AppResources.UseCaseTransferButton;
        UseCaseContainerOptimizationButton.Text = AppResources.UseCaseContainerOptimizationButton;
        UseCaseSplitConditionsButton.Text = AppResources.UseCaseSplitConditionsButton;
        UseCasePartitionButton.Text = AppResources.UseCasePartitionButton;
        UseCaseFilterClassesButton.Text = AppResources.UseCaseFilterClassesButton;
        UseCaseContractsButton.Text = AppResources.UseCaseContractsButton;
        UseCaseSftTypesButton.Text = AppResources.UseCaseSftTypesButton;
        UseCaseOrderRhythmButton.Text = AppResources.UseCaseOrderRhythmButton;
        UseCaseResubmissionButton.Text = AppResources.UseCaseResubmissionButton;
        UseCaseGeneralHandlingButton.Text = AppResources.UseCaseGeneralHandlingButton;
        UseCasePrecursorButton.Text = AppResources.UseCasePrecursorButton;
        UseCaseBufferStoreButton.Text = AppResources.UseCaseBufferStoreButton;
        UseCaseAbcAnalysisButton.Text =AppResources.UseCaseAbcAnalysisButton;
        UseCaseInheritanceButton.Text = AppResources.UseCaseInheritanceButton;
        UseCasePromotionsButton.Text = AppResources.UseCasePromotionsButton;
        UseCaseCompositeOrderButton.Text = AppResources.UseCaseCompositeOrderButton;
        UseCaseSporadicProcedureButton.Text = AppResources.UseCaseSporadicProcedureButton;
        UseCaseDueDatesButton.Text = AppResources.UseCaseDueDatesButton;
        UseCaseBackButton.Text = AppResources.UseCaseBackButton;
    }

}