namespace AzubiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            LanguageManager.InitializeLanguage();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}