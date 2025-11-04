using Calculadora_IMC.Core;
using Calculadora_IMC.Models;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using System.Windows;
using System.Windows.Input;
using Calculadora_IMC.Views;

namespace Calculadora_IMC.ViewModels
{
    /// <summary>
    /// ViewModel responsável por inicializar a aplicação e navegar para a página principal (<see cref="MainPage"/>).
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService, SaveLoadService saveLoadService)
        {
            _navigationService = navigationService;
            _navigationService.Navigate(new MainPage(_navigationService, saveLoadService));
        }
    }
}