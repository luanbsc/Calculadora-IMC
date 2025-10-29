namespace Calculadora_IMC.Models
{
    public class Medicao
    {
        public string Data { get; set; } = string.Empty;
        public double Peso { get; set; }
        public double IMC { get; set; }
    }
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public double Altura { get; set; }
        public string Genero { get; set; } = string.Empty;
    }
}