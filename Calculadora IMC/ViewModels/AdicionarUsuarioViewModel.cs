using Calculadora_IMC.Core;
using Calculadora_IMC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calculadora_IMC.ViewModels
{
    public class AdicionarUsuarioViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly INavigationService _navigationService;
        public ICommand GoBackCommand { get; }
        public ICommand CadastrarCommand { get; }
        public ObservableCollection<Usuario> _usuarios;
        public List<string> Generos { get; } = ["Masculino", "Feminino", "Outro"];
        public Usuario Usuario { get; set; }
        public Medicao Medicao { get; set; }
        private readonly SaveLoadService _saveLoadService;

        #region Variáveis de erros (para exibir na view)
        public string ErroNome
        {
            get
            {
                var erros = GetErrors(nameof(Usuario.Nome)) as List<string>;
                return erros != null && erros.Count > 0 ? erros[0] : string.Empty;
            }
        }

        public string ErroIdade
        {
            get
            {
                var erros = GetErrors(nameof(Usuario.Idade)) as List<string>;
                return erros != null && erros.Count > 0 ? erros[0] : string.Empty;
            }
        }

        public string ErroAltura
        {
            get
            {
                var erros = GetErrors(nameof(Usuario.Altura)) as List<string>;
                return erros != null && erros.Count > 0 ? erros[0] : string.Empty;
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

        public string ErroGenero
        {
            get
            {
                var erros = GetErrors(nameof(Usuario.Genero)) as List<string>;
                return erros != null && erros.Count > 0 ? erros[0] : string.Empty;
            }
        }
        #endregion

        private string _idadeTexto = "";
        public string IdadeTexto
        {
            get => _idadeTexto;
            set
            {
                _idadeTexto = value;
                OnPropertyChanged(nameof(IdadeTexto));
            }
        }

        private string _alturaTexto = "";
        public string AlturaTexto
        {
            get => _alturaTexto;
            set
            {
                _alturaTexto = value;
                OnPropertyChanged(nameof(AlturaTexto));
            }
        }

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
        public AdicionarUsuarioViewModel(INavigationService navigationService, SaveLoadService saveLoadService, ObservableCollection<Usuario> usuarios)
        {
            _navigationService = navigationService;
            _saveLoadService = saveLoadService;
            GoBackCommand = new RelayCommand(ExecutarGoBack);
            CadastrarCommand = new RelayCommand(ExecutarCadastrar);
            Usuario = new Usuario();
            Medicao = new Medicao();
            _usuarios = usuarios;
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
            // Nome
            ClearErrors(nameof(Usuario.Nome));
            if (string.IsNullOrWhiteSpace(Usuario.Nome))
                AddError(nameof(Usuario.Nome), "Informe o nome!");

            // Idade
            ClearErrors(nameof(Usuario.Idade));
            if (!int.TryParse(IdadeTexto, out int idade))
                AddError(nameof(Usuario.Idade), "Idade inválida!");
            else
                Usuario.Idade = idade;
                if (Usuario.Idade <= 0)
                    AddError(nameof(Usuario.Idade), "Idade deve ser maior que zero!");

            // Altura
            ClearErrors(nameof(Usuario.Altura));
            if (string.IsNullOrWhiteSpace(AlturaTexto))
            {
                AddError(nameof(Usuario.Altura), "Informe a altura!");
            }
            else
            {
                // Regex para número positivo, opcionalmente com decimal
                var regex = new System.Text.RegularExpressions.Regex(@"^-?\d+([.,]\d+)?$");

                if (!regex.IsMatch(AlturaTexto))
                {
                    AddError(nameof(Usuario.Altura), "Altura inválida!");
                }
                else
                {
                    // Substitui vírgula por ponto para converter corretamente
                    var valor = AlturaTexto.Replace(',', '.');

                    if (double.TryParse(valor, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double altura))
                    {
                        if (altura <= 0)
                            AddError(nameof(Usuario.Altura), "Altura deve ser maior que zero!");
                        else
                            Usuario.Altura = altura;
                    }
                    else
                    {
                        AddError(nameof(Usuario.Altura), "Altura inválida!");
                    }
                }
            }

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
                            Medicao.Peso = peso;
                    }
                    else
                    {
                        AddError(nameof(Medicao.Peso), "Peso inválida!");
                    }
                }
            }

            // Gênero
            ClearErrors(nameof(Usuario.Genero));
            if (string.IsNullOrWhiteSpace(Usuario.Genero))
                AddError(nameof(Usuario.Genero), "Selecione um gênero!");
        }
        #endregion

        private void ExecutarGoBack()
        {
            _navigationService.GoBack();
        }

        private void ExecutarCadastrar()
        {
            Validate();
            if (HasErrors)
                return;

            var result = MessageBox.Show(
            "Tem certeza que deseja cadastrar este usuário?\n\n" +
            $"Nome: {Usuario.Nome}\n" +
            $"Idade: {Usuario.Idade}\n" +
            $"Altura: {Usuario.Altura}\n" +
            $"Peso: {Medicao.Peso}\n" +
            $"Gênero: {Usuario.Genero}",
            "Confirmar cadastro",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question
            );

            if (result != MessageBoxResult.Yes)
                return;

            Medicao.Data = DateTime.Now;
            Medicao.IMC = Medicao.Peso / (Usuario.Altura * Usuario.Altura);
            Usuario.Medicoes.Add(Medicao);
            Usuario.Id = Guid.NewGuid();

            _usuarios.Add(Usuario);
            _saveLoadService.SalvarUsuarios(_usuarios);

            MessageBox.Show(
                $"Usuário {Usuario.Nome} cadastrado!"
            );

            ExecutarGoBack();
        }
    }
}
