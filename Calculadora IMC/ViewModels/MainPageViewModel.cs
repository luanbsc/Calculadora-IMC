using Calculadora_IMC.Core;
using System.Windows;
using System.Windows.Input;

namespace Calculadora_IMC.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ICommand AddUserCommand { get; }

        public MainPageViewModel(INavigationService navigationService)
        {
            AddUserCommand = new RelayCommand(ExecutarAddUser);
            _navigationService = navigationService;
        }

        private void ExecutarAddUser()
        {
            _navigationService.Navigate(new AdicionarUsuario(_navigationService));
        }
    }
}