using Calculadora_IMC.ViewModels;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Calculadora_IMC
{
    public partial class MainPage : Page
    {
        public MainPage(INavigationService navigationService)
        {
            InitializeComponent();
            DataContext = new MainPageViewModel(navigationService);
        }
    }
}
