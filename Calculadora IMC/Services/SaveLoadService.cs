using Calculadora_IMC.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

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

    public void SalvarArquivo(ObservableCollection<Usuario> usuarios)
    {
        string json = JsonConvert.SerializeObject(usuarios, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
}