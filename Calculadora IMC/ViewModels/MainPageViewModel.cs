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
        public ICommand DeleteUserCommand { get; }

        public MainPageViewModel(INavigationService navigationService, SaveLoadService saveLoadService)
        {
            _navigationService = navigationService;
            _saveLoadService = saveLoadService;
            Usuarios = saveLoadService.CarregarUsuarios();
            AddUserCommand = new RelayCommand(_ => ExecutarAddUser());
            PageLoadedCommand = new RelayCommand(_ => OnPageLoaded());
            DeleteUserCommand = new RelayCommand(obj => ExecutarDeleteUser(obj));
        }

        private void ExecutarAddUser()
        {
            _navigationService.Navigate(new AdicionarUsuario(_navigationService, _saveLoadService, Usuarios));
        }

        private void ExecutarDeleteUser(object? obj)
        {
            if (obj is not Usuario usuario)
                return;

            var result = MessageBox.Show(
            "Tem certeza que deseja deletar este usuário?\n\n" +
            $"Nome: {usuario.Nome}\n" +
            $"Idade: {usuario.Idade}\n" +
            $"Altura: {usuario.Altura} m\n" +
            $"Peso: {usuario.PesoUltimaMedicao} kg\n" +
            $"Gênero: {usuario.Genero}\n" +
            $"IMC: {usuario.IMCUltimaMedicao:F2}",
            "Deletar Usuário",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question
            );

            if (result != MessageBoxResult.Yes)
                return;

            Usuarios.Remove(usuario);
            _saveLoadService.SalvarUsuarios(Usuarios);
        }

        private void OnPageLoaded()
        {
            Usuarios = _saveLoadService.CarregarUsuarios();
        }
    }
}