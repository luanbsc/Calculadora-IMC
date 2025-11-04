using Calculadora_IMC.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

/// <summary>
/// Serviço responsável por salvar e carregar dados de usuários em um arquivo JSON local.
/// </summary>
public class SaveLoadService
{
    private readonly string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    private readonly string folder;
    private readonly string filePath;

    public SaveLoadService()
    {
    folder = Path.Combine(appData, "Calculadora IMC");
    filePath = Path.Combine(folder, "usuarios.json");
    }

    /// <summary>
    /// Carrega os usuários do arquivo JSON.
    /// Se o arquivo ou pasta não existir, cria-os com uma lista vazia.
    /// </summary>
    /// <returns>Uma coleção de <see cref="Usuario"/>.</returns>
    public ObservableCollection<Usuario> CarregarUsuarios()
    {
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        if (!File.Exists(filePath))
        {
            var listaVazia = new ObservableCollection<Usuario>();
            File.WriteAllText(filePath, JsonConvert.SerializeObject(listaVazia, Formatting.Indented));
            return listaVazia;
        }

        string json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<ObservableCollection<Usuario>>(json)
               ?? new ObservableCollection<Usuario>();
    }

    /// <summary>
    /// Salva a coleção de usuários no arquivo JSON.
    /// </summary>
    /// <param name="usuarios">Coleção de usuários a ser salva.</param>
    public void SalvarUsuarios(ObservableCollection<Usuario> usuarios)
    {
        string json = JsonConvert.SerializeObject(usuarios, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
}