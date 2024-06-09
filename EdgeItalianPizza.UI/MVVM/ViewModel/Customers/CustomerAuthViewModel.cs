using AsyncAwaitBestPractices.MVVM;
using EdgeItalianPizza.Application.DTOs.Customers;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Share.ResultPattern;
using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Abstractions.Interfaces;
using EdgeItalianPizza.UI.MVVM.Model.Customers;
using EdgeItalianPizza.UI.Share.Informations;
using EdgeItalianPizza.UI.Share.Utilities;
using System.Windows.Input;

namespace EdgeItalianPizza.UI.MVVM.ViewModel;

internal class CustomerAuthViewModel(
    CustomerModel model,
    ICustomerService service) : ViewModelBase, INotifyNavigation
{
    /// <summary>
    /// Событие, срабатываемое при нажатии кнопки "Зарегистрироваться".
    /// </summary>
    public event Action OnButtonClick;

    private CustomerModel _model = model;
    /// <summary>
    /// Модель покупателя.
    /// </summary>
    public CustomerModel Model
    {
        get => _model;
        set
        {
            _model = value;
            OnPropertyChanged(nameof(Model));
        }
    }

    private string _loginErrorMessage = string.Empty;
    /// <summary>
    /// Сообщение об ошибке при входе.
    /// </summary>
    public string LoginErrorMessage
    {
        get => _loginErrorMessage;
        set
        {
            _loginErrorMessage = value;
            OnPropertyChanged(nameof(LoginErrorMessage));
        }
    }

    /// <summary>
    /// Команда при загрузке.
    /// </summary>
    public ICommand LoadCommand { get; private set; }
    /// <summary>
    /// Асинхронная команда входа.
    /// </summary>
    public IAsyncCommand LoginAsyncCommand { get; private set; }
    /// <summary>
    /// Команда для перехода на форму регистрации.
    /// </summary>
    public ICommand RegistrationCommand { get; private set; }

    protected override void InitializeComponents()
    {
        LoadCommand = new RelayCommand(LoadCommandExecute);
        LoginAsyncCommand = new AsyncCommand(LoginAsyncCommandExecute);
        RegistrationCommand = new RelayCommand(RegistrationCommandExecute);
    }

    private void LoadCommandExecute(object obj)
    {
        Model.Clear();
        LoginErrorMessage = string.Empty;
    }

    private async Task LoginAsyncCommandExecute()
    {
        if (!Model.IsValid())
            return;

        var request = new Request(Model.PhoneNumber, Model.Password);

        Result<Response> response = await Task.Run(() => service.AuthorizationAsync(request));

        if (response.IsFailure)
        {
            LoginErrorMessage = response.ErrorMessage;
            return;
        }

        var value = response.Value;

        CustomerSessionInfo.Customer = new CustomerSession
        { 
            Id = value.Id,
            PhoneNumber = value.PhoneNumber,
            DateOfBirth = value.DateOfBirth,
            BonusCoins = value.BonusCoins
        };
    }

    private void RegistrationCommandExecute(object obj)
    {
        OnButtonClick?.Invoke();
    }
}
