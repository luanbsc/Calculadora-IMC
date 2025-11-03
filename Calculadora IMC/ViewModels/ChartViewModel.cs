using Calculadora_IMC.Core;
using Calculadora_IMC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_IMC.ViewModels
{
    public class ChartViewModel : ViewModelBase
    {
        public ObservableCollection<Medicao> _medicoes;
        public ChartViewModel(ObservableCollection<Medicao> Medicoes)
        {
            _medicoes = Medicoes;
        }
    }
}
