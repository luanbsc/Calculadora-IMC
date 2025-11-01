using System.Windows.Controls;

public interface INavigationService
{
    /// <summary>
    /// Navega para a Page passada como instância.
    /// </summary>
    /// <param name="page">Página já instanciada</param>
    void Navigate(Page page);
    void GoBack();
}

