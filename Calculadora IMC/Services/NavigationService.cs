using System.Windows.Controls;

/// <summary>
/// Implementa um serviço de navegação simples para gerenciar a navegação entre páginas em um Frame do WPF.
/// </summary>
public class NavigationService : INavigationService
{
    private readonly Frame _frame;

    /// <summary>
    /// Inicializa uma nova instância do NavigationService com o Frame fornecido.
    /// </summary>
    /// <param name="frame">O Frame onde as páginas serão navegadas.</param>
    public NavigationService(Frame frame)
    {
        _frame = frame;
    }

    /// <summary>
    /// Navega para a página especificada.
    /// </summary>
    /// <param name="page">A página de destino.</param>
    public void Navigate(Page page)
    {
        _frame.Navigate(page);
    }

    /// <summary>
    /// Volta para a página anterior se houver uma disponível no histórico do Frame.
    /// </summary>
    public void GoBack()
    {
        if (_frame.CanGoBack)
        {
            _frame.GoBack();
        }
    }
}

