using AsyncAwaitBestPractices.MVVM;
using EdgeItalianPizza.Application.DTOs.Customers;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.MVVM.Model.Customers;
using EdgeItalianPizza.UI.Share.Informations;
using EdgeItalianPizza.UI.Share.Utilities;
using System.Windows.Input;

namespace EdgeItalianPizza.UI.MVVM.ViewModel;

internal sealed class NewPasswordViewModel(
    NewPasswordModel model,
    ICustomerService service) : ViewModelBase
{
    public static event Action OnBack;

    private NewPasswordModel _model = model;
    /// <summary>
    /// Новый и старый пароли.
    /// </summary>
    public NewPasswordModel Model
    {
        get => _model;
        set
        {
            _model = value;
            OnPropertyChanged(nameof(Model));
        }
    }

    private string _changePasswordErrorMessage = string.Empty;
    /// <summary>
    /// Сообщение об ошибке при смене пароля.
    /// </summary>
    public string ChangePasswordErrorMessage
    {
        get => _changePasswordErrorMessage;
        set
        {
            _changePasswordErrorMessage = value;
            OnPropertyChanged(nameof(ChangePasswordErrorMessage));
        }
    }

    /// <summary>
    /// Команда при загрузке.
    /// </summary>
    public ICommand LoadedCommand { get; private set; }
    /// <summary>
    /// Команда возвращающая назад.
    /// </summary>
    public ICommand BackCommand { get; private set; }
    /// <summary>
    /// Асинхронная смена пароля.
    /// </summary>
    public IAsyncCommand ChangePasswordAsyncCommand { get; private set; }

    protected override void InitializeComponents()
    {
        LoadedCommand = new RelayCommand(LoadedCommandExecute);
        BackCommand = new RelayCommand(BackCommandExecute);
        ChangePasswordAsyncCommand = new AsyncCommand(ChangePasswordAsyncCommandExecute);
    }

    private void LoadedCommandExecute(object obj)
    {
        Model.Clear();
        ChangePasswordErrorMessage = string.Empty;
    }

    private void BackCommandExecute(object obj)
    {
        OnBack?.Invoke();
    }

    private async Task ChangePasswordAsyncCommandExecute()
    {
        if (!Model.IsValid())
            return;

        long customerId = CustomerSessionInfo.Customer.Id;

        var request = new ChangePasswordRequest(customerId, Model.OldPassword, Model.NewPassword);

        var response = await service.ChangePasswordAsync(request);

        if (response.IsFailure)
        {
            ChangePasswordErrorMessage = response.ErrorMessage;
            return;
        }

        OnBack?.Invoke();
    }
}
