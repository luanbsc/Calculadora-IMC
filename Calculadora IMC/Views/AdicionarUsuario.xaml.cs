using Calculadora_IMC.ViewModels;
using System.Windows.Controls;

namespace Calculadora_IMC
{
    public partial class AdicionarUsuario : Page
    {
        public AdicionarUsuario(INavigationService navigationService)
        {
            InitializeComponent();
            DataContext = new AdicionarUsuarioViewModel(navigationService);
        }
    }
}
