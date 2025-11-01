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
        private ObservableCollection<Usuario> _usuarios = new();
        public ObservableCollection<Usuario> Usuarios
        {
            get => _usuarios;
            set
            {
                _usuarios = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddUserCommand { get; }
        public ICommand PageLoadedCommand { get; }

        public MainPageViewModel(INavigationService navigationService, SaveLoadService saveLoadService)
        {
            _navigationService = navigationService;
            _saveLoadService = saveLoadService;
            Usuarios = saveLoadService.CarregarUsuarios();
            AddUserCommand = new RelayCommand(ExecutarAddUser);
            PageLoadedCommand = new RelayCommand(OnPageLoaded);
        }

        private void ExecutarAddUser()
        {
            _navigationService.Navigate(new AdicionarUsuario(_navigationService, _saveLoadService, Usuarios));
        }

        private void OnPageLoaded()
        {
            var usuariosCarregados = _saveLoadService.CarregarUsuarios();
            Usuarios.Clear();
            foreach (var u in usuariosCarregados)
                Usuarios.Add(u);
        }
    }
}