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
            var saveLoadService = new SaveLoadService();
            DataContext = new MainViewModel(navigationService, saveLoadService);
        }
    }
}