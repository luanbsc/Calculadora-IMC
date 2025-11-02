using Calculadora_IMC.Models;
using Calculadora_IMC.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Calculadora_IMC.Views
{
    public partial class AdicionarMedicao : Page
    {
        public AdicionarMedicao(INavigationService navigationService, SaveLoadService saveLoadService, ObservableCollection<Usuario> usuarios, Usuario usuario)
        {
            InitializeComponent();
            DataContext = new AdicionarMedicaoViewModel(navigationService, saveLoadService, usuarios, usuario);
        }
    }
}
