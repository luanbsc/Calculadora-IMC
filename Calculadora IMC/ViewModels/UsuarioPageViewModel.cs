using Calculadora_IMC.Core;
using Calculadora_IMC.Models;
using Calculadora_IMC.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculadora_IMC.ViewModels
{
    /// <summary>
    /// ViewModel responsável por gerenciar a visualização detalhada de um <see cref="Calculadora_IMC.Models.Usuario"/>,
    /// incluindo histórico de medições e navegação para adicionar novas medições ou visualizar gráficos.
    /// </summary>
    internal class UsuarioPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly SaveLoadService _saveLoadService;
        private Usuario _usuario = new();
        public Usuario Usuario
        {
            get => _usuario;
            set
            {
                if (_usuario != value)
                {
                    _usuario = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Usuario> Usuarios;
        public ICommand AddMedicaoCommand { get; }
        public ICommand OpenChartCommand { get; }
        public ICommand GoBackCommand { get; }
        public UsuarioPageViewModel(INavigationService navigationService, SaveLoadService saveLoadService, ObservableCollection<Usuario> usuarios, Usuario usuario)
        {
            _navigationService = navigationService;
            _saveLoadService = saveLoadService;
            Usuario = usuario;
            Usuarios = usuarios;
            AddMedicaoCommand = new RelayCommand(_ => ExecutarAddMedicao());
            OpenChartCommand = new RelayCommand(_ => ExecutarOpenChart());
            GoBackCommand = new RelayCommand(_ => ExecutarGoBack());
        }

        /// <summary>
        /// Executa a abertura da janela de gráficos com o histórico de medições do usuário.
        /// </summary>
        private void ExecutarOpenChart()
        {
            ChartWindow chartWindow = new ChartWindow(Usuario.Medicoes);
            chartWindow.Show();
        }

        /// <summary>
        /// Navega para a página anterior.
        /// </summary>
        private void ExecutarGoBack()
        {
            _navigationService.GoBack();
        }

        /// <summary>
        /// Navega para a página de adição de medição para o usuário atual.
        /// </summary>
        private void ExecutarAddMedicao()
        {
            _navigationService.Navigate(new AdicionarMedicao(_navigationService, _saveLoadService, Usuarios, Usuario));
        }
    }
}
