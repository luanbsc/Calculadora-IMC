using Calculadora_IMC.Core;
using System.Collections.ObjectModel;

namespace Calculadora_IMC.Models
{
    public class Medicao
    {
        public DateTime Data { get; set; }
        public double Peso { get; set; }
        public double IMC { get; set; }
    }
    public class Usuario : ViewModelBase
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        private string _nome = string.Empty;
        public string Nome
        {
            get => _nome;
            set { _nome = value; OnPropertyChanged(); }
        }

        private int _idade;
        public int Idade
        {
            get => _idade;
            set { _idade = value; OnPropertyChanged(); }
        }

        private double _altura;
        public double Altura
        {
            get => _altura;
            set { _altura = value; OnPropertyChanged(); }
        }

        private string _genero = string.Empty;
        public string Genero
        {
            get => _genero;
            set { _genero = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Medicao> _medicoes = new ObservableCollection<Medicao>();
        public ObservableCollection<Medicao> Medicoes
        {
            get => _medicoes;
            set { _medicoes = value; OnPropertyChanged(); }
        }

        private double _pesoUltimaMedicao;
        public double PesoUltimaMedicao
        {
            get => _pesoUltimaMedicao;
            set { _pesoUltimaMedicao = value; OnPropertyChanged(); }
        }

        private double _imcUltimaMedicao;
        public double IMCUltimaMedicao
        {
            get => _imcUltimaMedicao;
            set { _imcUltimaMedicao = value; OnPropertyChanged(); }
        }
    }
}