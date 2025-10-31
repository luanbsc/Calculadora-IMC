namespace Calculadora_IMC.Models
{
    public class Medicao
    {
        public DateTime Data { get; set; }
        public double Peso { get; set; }
        public double IMC { get; set; }
    }
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public double Altura { get; set; }
        public string Genero { get; set; } = string.Empty;
        public List<Medicao> Medicoes { get; set; } = [];
    }
}