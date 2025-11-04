using Calculadora_IMC.Core;
using Calculadora_IMC.Models;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;

namespace Calculadora_IMC.ViewModels
{
    public class ChartViewModel : ViewModelBase
    {
        public ObservableCollection<Medicao> Medicoes { get; set; }
        public ISeries[] Series { get; set; }
        public Axis[] XAxes { get; set; }

        public ChartViewModel(ObservableCollection<Medicao> medicoes)
        {
            Medicoes = medicoes;

            double[] pesos = Medicoes.Select(medicao => medicao.Peso).ToArray();
            double[] imcs = Medicoes.Select(medicao => Math.Round(medicao.IMC, 2)).ToArray();
            string[] datas = Medicoes.Select(medicao => medicao.Data.ToString("dd/MM HH:mm")).ToArray();

            Series =
            [
                new ColumnSeries<double>
                {
                    Values = pesos,
                    Name = "Peso (kg)"
                },
                new LineSeries<double>
                {
                    Values = imcs,
                    Name = "IMC",
                    GeometrySize = 10, // bolinhas nos pontos
                    LineSmoothness = 0 // linha reta
                }
            ];

            XAxes =
            [
                new Axis
                {
                    Labels = datas
                }
            ];
        }
    }
}
