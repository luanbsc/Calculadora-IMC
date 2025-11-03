using Calculadora_IMC.Models;
using Calculadora_IMC.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace Calculadora_IMC.Views
{
    public partial class ChartWindow : Window
    {
        public ChartWindow(ObservableCollection<Medicao> Medicoes)
        {
            InitializeComponent();
            DataContext = new ChartViewModel(Medicoes);
        }
    }
}
