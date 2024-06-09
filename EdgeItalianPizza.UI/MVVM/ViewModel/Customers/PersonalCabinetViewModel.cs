using AsyncAwaitBestPractices.MVVM;
using EdgeItalianPizza.Application.DTOs.Customers;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.MVVM.Model.Customers;
using EdgeItalianPizza.UI.Share.Informations;
using EdgeItalianPizza.UI.Share.Utilities;
using System.Windows.Input;

namespace EdgeItalianPizza.UI.MVVM.ViewModel;

internal class PersonalCabinetViewModel(
    ICustomerService service) : ViewModelBase
{
    public static event Action OnNewPasswordClick;

    private AuthCustomerModel _model;
    /// <summary>
    /// Модель данных личного кабинета.
    /// </summary>
    public AuthCustomerModel Model
    {
        get => _model;
        set
        {
            _model = value;
            OnPropertyChanged(nameof(Model));
        }
    }

    private string _dateOfBirthErrorMessage = string.Empty;
    public string DateOfBirthErrorMessage
    {
        get => _dateOfBirthErrorMessage;
        set
        {
            _dateOfBirthErrorMessage = value;
            OnPropertyChanged(nameof(DateOfBirthErrorMessage));
        }
    }

    /// <summary>
    /// Команда при загрузке.
    /// </summary>
    public ICommand LoadedCommand { get; private set; }
    /// <summary>
    /// Команда выхода из аккаунта.
    /// </summary>
    public ICommand LogOutCommand { get; private set; }
    /// <summary>
    /// Асинхронная команда сохранения даты рождения.
    /// </summary>
    public IAsyncCommand SaveDateOfBirthAsyncCommand { get; private set; }
    /// <summary>
    /// Команда для перехода на форму восстановления пароля.
    /// </summary>
    public ICommand NewPasswordCommand { get; private set; }

    protected override void InitializeComponents()
    {
        LoadedCommand = new RelayCommand(LoadedCommandExecute);
        LogOutCommand = new RelayCommand(LogOutCommandExecute);
        SaveDateOfBirthAsyncCommand = new AsyncCommand(SaveDateOfBirthAsyncCommandExecute);
        NewPasswordCommand = new RelayCommand(NewPasswordCommandExecute);
    }

    private void LoadedCommandExecute(object obj)
    {
        Model = new AuthCustomerModel
        {
            Id = CustomerSessionInfo.Customer.Id,
            PhoneNumber = CustomerSessionInfo.Customer.PhoneNumber,
            DateOfBirth = CustomerSessionInfo.Customer.DateOfBirth,
            BonusCoins = CustomerSessionInfo.Customer.BonusCoins,
            DateOfBirthHasValue = CustomerSessionInfo.Customer.DateOfBirthHasValue,
            NotDateOfBirthHasValue = CustomerSessionInfo.Customer.NotDateOfBirthHasValue
        };

        DateOfBirthErrorMessage = string.Empty;
    }

    private void LogOutCommandExecute(object obj)
    {
        CustomerSessionInfo.Customer = null;
    }

    private async Task SaveDateOfBirthAsyncCommandExecute()
    {
        if (Model.DateOfBirth is null)
        {
            DateOfBirthErrorMessage = "Неверно указанная дата рождения, необходимый формат: День-Месяц-Год";
            return;
        }

        var request = new DateOfBirthRequest(Model.Id, Model.DateOfBirth);

        var response = await service.SetDateOfBirthAsync(request);

        if (response.IsFailure)
        {
            DateOfBirthErrorMessage = response.ErrorMessage;
            return;
        }

        CustomerSessionInfo.Customer.DateOfBirth = Model.DateOfBirth;
        CustomerSessionInfo.Customer.NotDateOfBirthHasValue = Model.NotDateOfBirthHasValue;
        CustomerSessionInfo.Customer.DateOfBirthHasValue = Model.DateOfBirthHasValue;
    }

    private void NewPasswordCommandExecute(object obj)
    {
        OnNewPasswordClick?.Invoke();
    }
}
