using Calculadora_IMC.ViewModels;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Calculadora_IMC
{
    public partial class MainPage : Page
    {
        public MainPage(INavigationService navigationService, SaveLoadService saveLoadService)
        {
            InitializeComponent();
            DataContext = new MainPageViewModel(navigationService, saveLoadService);
        }
    }
}
