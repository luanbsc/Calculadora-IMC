using Calculadora_IMC.Models;
using Calculadora_IMC.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Calculadora_IMC.Views
{
    public partial class AdicionarUsuario : Page
    {
        public AdicionarUsuario(INavigationService navigationService, SaveLoadService saveLoadService, ObservableCollection<Usuario> usuarios)
        {
            InitializeComponent();
            DataContext = new AdicionarUsuarioViewModel(navigationService, saveLoadService, usuarios);
        }
    }
}
