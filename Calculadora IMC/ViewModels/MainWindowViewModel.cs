using Calculadora_IMC.Core;
using System.Windows.Input;

namespace Calculadora_IMC.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand SalvarCommand { get; }

        public MainWindowViewModel()
        {
            SalvarCommand = new RelayCommand(ExecutarSalvar);
        }
    }
}