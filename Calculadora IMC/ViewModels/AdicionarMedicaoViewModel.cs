using Calculadora_IMC.Core;
using Calculadora_IMC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calculadora_IMC.ViewModels
{
    public class AdicionarMedicaoViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly INavigationService _navigationService;
        private readonly SaveLoadService _saveLoadService;
        public ObservableCollection<Usuario> _usuarios;
        public Usuario _usuario;
        public Medicao novaMedicao { get; set; } = new Medicao();
        public ICommand AdicionarMedicaoCommand { get; }
        public ICommand GoBackCommand { get; }
        private string _pesoTexto = "";
        public string PesoTexto
        {
            get => _pesoTexto;
            set
            {
                _pesoTexto = value;
                OnPropertyChanged(nameof(PesoTexto));
            }
        }
        public string ErroPeso
        {
            get
            {
                var erros = GetErrors(nameof(Medicao.Peso)) as List<string>;
                return erros != null && erros.Count > 0 ? erros[0] : string.Empty;
            }
        }
        public AdicionarMedicaoViewModel(INavigationService navigationService, SaveLoadService saveLoadService, ObservableCollection<Usuario> usuarios, Usuario usuario)
        {
            _navigationService = navigationService;
            _saveLoadService = saveLoadService;
            _usuarios = usuarios;
            _usuario = usuario;
            AdicionarMedicaoCommand = new RelayCommand(_ => ExecutarAdicionarMedicao());
            GoBackCommand = new RelayCommand(_ => ExecutarGoBack());
        }

        #region INotifyDataErrorInfo
        private readonly Dictionary<string, List<string>> _errors = new();

        public bool HasErrors => _errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            if (propertyName != null && _errors.ContainsKey(propertyName))
                return _errors[propertyName];
            return Enumerable.Empty<string>();
        }

        private void AddError(string propertyName, string error)
        {
            if (!_errors.ContainsKey(propertyName))
                _errors[propertyName] = new List<string>();

            if (!_errors[propertyName].Contains(error))
            {
                _errors[propertyName].Add(error);
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

                // Dispara atualização da propriedade de erro correspondente
                OnPropertyChanged($"Erro{propertyName}");
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

                // Dispara atualização da propriedade de erro correspondente
                OnPropertyChanged($"Erro{propertyName}");
            }
        }

        private void Validate()
        {
            // Peso
            ClearErrors(nameof(Medicao.Peso));
            if (string.IsNullOrWhiteSpace(PesoTexto))
            {
                AddError(nameof(Medicao.Peso), "Informe o peso!");
            }
            else
            {
                // Regex para número positivo, opcionalmente com decimal
                var regex = new System.Text.RegularExpressions.Regex(@"^-?\d+([.,]\d+)?$");

                if (!regex.IsMatch(PesoTexto))
                {
                    AddError(nameof(Medicao.Peso), "Peso inválido!");
                }
                else
                {
                    // Substitui vírgula por ponto para converter corretamente
                    var valor = PesoTexto.Replace(',', '.');

                    if (double.TryParse(valor, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double peso))
                    {
                        if (peso <= 0)
                            AddError(nameof(Medicao.Peso), "Peso deve ser maior que zero!");
                        else
                            novaMedicao.Peso = peso;
                    }
                    else
                    {
                        AddError(nameof(Medicao.Peso), "Peso inválida!");
                    }
                }
            }
        }
        #endregion

        private void ExecutarGoBack()
        {
            _navigationService.GoBack();
        }

        private void ExecutarAdicionarMedicao()
        {
            Validate();
            if (HasErrors)
                return;

            var result = MessageBox.Show(
            $"Tem certeza que deseja adicionar esta nova medição ao usuário {_usuario.Nome}?\n\n",
            "Nova Medição",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question
            );

            if (result != MessageBoxResult.Yes)
                return;

            // Calcula IMC
            novaMedicao.IMC = novaMedicao.Peso / (_usuario.Altura * _usuario.Altura);
            novaMedicao.Data = DateTime.Now;
            // Adiciona a medição ao usuário
            _usuario.Medicoes.Add(novaMedicao);
            _usuario.PesoUltimaMedicao = novaMedicao.Peso;
            _usuario.IMCUltimaMedicao = novaMedicao.IMC;
            // Salva os dados
            _saveLoadService.SalvarUsuarios(_usuarios);
            // Navega de volta
            ExecutarGoBack();
        }
    }
}
