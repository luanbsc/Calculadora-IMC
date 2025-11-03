using Calculadora_IMC.Models;
using Calculadora_IMC.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calculadora_IMC.Views
{
    public partial class UsuarioPage : Page
    {
        public UsuarioPage(INavigationService navigationService, SaveLoadService saveLoadService, ObservableCollection<Usuario> usuarios, Usuario usuario)
        {
            InitializeComponent();
            DataContext = new UsuarioPageViewModel(navigationService, saveLoadService, usuarios, usuario);
        }
    }
}
