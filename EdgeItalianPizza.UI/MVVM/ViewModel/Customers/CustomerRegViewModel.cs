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

internal class CustomerRegViewModel(
    CustomerModel model,
    ICustomerService service) : ViewModelBase, INotifyNavigation
{
    /// <summary>
    /// Событие, при срабатывании которого возращаемся на экран авторизации.
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

    private string _registrationErrorMessage = string.Empty;
    /// <summary>
    /// Сообщение об ошибке при входе.
    /// </summary>
    public string RegistrationErrorMessage
    {
        get => _registrationErrorMessage;
        set
        {
            _registrationErrorMessage = value;
            OnPropertyChanged(nameof(RegistrationErrorMessage));
        }
    }

    /// <summary>
    /// Команда при загрузке.
    /// </summary>
    public ICommand LoadCommand { get; private set; }
    /// <summary>
    /// Асинхронная команда регистрации.
    /// </summary>
    public IAsyncCommand RegistrationAsyncCommand { get; private set; }
    /// <summary>
    /// Перейти обратно к авторизации.
    /// </summary>
    public ICommand BackCommand { get; private set; }

    protected override void InitializeComponents()
    {
        LoadCommand = new RelayCommand(LoadCommandExecute);
        RegistrationAsyncCommand = new AsyncCommand(RegistrationAsyncCommandExecute);
        BackCommand = new RelayCommand(BackCommandExecute);
    }

    private void LoadCommandExecute(object obj)
    {
        Model.Clear();
        RegistrationErrorMessage = string.Empty;
    }

    private async Task RegistrationAsyncCommandExecute()
    {
        if (!Model.IsValid())
            return;

        var request = new Request(Model.PhoneNumber, Model.Password);

        Result<Response> response = await Task.Run(() => service.RegistrationAsync(request));

        if (response.IsFailure)
        {
            RegistrationErrorMessage = response.ErrorMessage;
            return;
        }

        var value = response.Value;

        CustomerSessionInfo.Customer = new CustomerSession(value.DateOfBirth)
        { 
            Id = value.Id,
            PhoneNumber = value.PhoneNumber,
            DateOfBirth = value.DateOfBirth,
            BonusCoins = value.BonusCoins
        };
    }

    private void BackCommandExecute(object obj)
    {
        OnButtonClick?.Invoke();
    }
}
