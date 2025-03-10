using System.Threading.Tasks;
using AzubiApp.Views;

namespace AzubiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(QuizPage), typeof(QuizPage)); //´Register the route


        }



   }

}



