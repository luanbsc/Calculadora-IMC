namespace Calculadora_IMC.Models
{
    public interface IMedicao
    {
        DateTime Data { get; set; }
        double Peso { get; set; }
        double IMC { get; set; }
    }
    public interface IUsuario
    {
        Guid Id { get; set; }
        string Nome { get; set; }
        int Idade { get; set; }
        double Altura { get; set; }
        string Genero { get; set; }
        List<IMedicao> Medicoes { get; set; }
    }
}