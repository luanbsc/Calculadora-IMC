using Calculadora_IMC.Core;
using Calculadora_IMC.Models;
using Calculadora_IMC.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
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
        private ICollectionView _usuariosView = null!;
        public ICollectionView UsuariosView
        {
            get => _usuariosView;
            set { _usuariosView = value; OnPropertyChanged(nameof(UsuariosView)); }
        }

        private string _searchText = "";
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    UsuariosView.Refresh(); // atualiza o filtro
                }
            }
        }
        public ICommand AddUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand ViewUserCommand { get; }

        public MainPageViewModel(INavigationService navigationService, SaveLoadService saveLoadService)
        {
            _navigationService = navigationService;
            _saveLoadService = saveLoadService;
            Usuarios = saveLoadService.CarregarUsuarios();
            UsuariosView = CollectionViewSource.GetDefaultView(Usuarios);
            UsuariosView.Filter = FilterUsuarios;
            AddUserCommand = new RelayCommand(_ => ExecutarAddUser());
            DeleteUserCommand = new RelayCommand(obj => ExecutarDeleteUser(obj));
            ViewUserCommand = new RelayCommand(obj => ExecutarViewUser(obj));
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

        private void ExecutarViewUser(object? obj)
        {
            if (obj is not Usuario usuario)
                return;
            _navigationService.Navigate(new UsuarioPage(_navigationService, _saveLoadService, Usuarios, usuario));
        }

        private bool FilterUsuarios(object obj)
        {
            if (obj is not Usuario usuario)
                return false;

            if (string.IsNullOrEmpty(SearchText))
                return true;

            return usuario.Nome.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}