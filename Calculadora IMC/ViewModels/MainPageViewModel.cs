using Calculadora_IMC.Core;
using Calculadora_IMC.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Calculadora_IMC.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly SaveLoadService _saveLoadService;
        private ObservableCollection<Usuario>  _usuarios;
        public ICommand AddUserCommand { get; }
        public ICommand PageLoadedCommand { get; }

        public MainPageViewModel(INavigationService navigationService, SaveLoadService saveLoadService)
        {
            _navigationService = navigationService;
            _saveLoadService = saveLoadService;
            _usuarios = saveLoadService.CarregarUsuarios();
            AddUserCommand = new RelayCommand(ExecutarAddUser);
            PageLoadedCommand = new RelayCommand(OnPageLoaded);
        }

        private void ExecutarAddUser()
        {
            _navigationService.Navigate(new AdicionarUsuario(_navigationService, _saveLoadService, _usuarios));
        }

        private void OnPageLoaded()
        {
            _saveLoadService.CarregarUsuarios();
        }
    }
}