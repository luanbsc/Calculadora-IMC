using Calculadora_IMC.ViewModels;
using System.Windows;

namespace Calculadora_IMC
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var navigationService = new NavigationService(MainFrame);
            DataContext = new MainViewModel(navigationService);
        }
    }
}