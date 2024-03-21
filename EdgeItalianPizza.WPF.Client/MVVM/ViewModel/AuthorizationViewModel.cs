using EdgeItalianPizza.Application.DTOs;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Application.Services;
using EdgeItalianPizza.Domain.Enums;
using EdgeItalianPizza.Infrastructrure.SqlServer.Data;
using EdgeItalianPizza.Infrastructrure.SqlServer.Repositories;
using EdgeItalianPizza.WPF.Client.MVVM.Model;
using EdgeItalianPizza.WPF.Client.MVVM.View;
using EdgeItalianPizza.WPF.Client.Services;
using EdgeItalianPizza.WPF.Client.Utilities;
using System.Windows.Input;

namespace EdgeItalianPizza.WPF.Client.MVVM.ViewModel;

internal sealed class AuthorizationViewModel(ILoggerService logger, NavigationViewModel navigationVM) : ViewModelBase(logger)
{
    private readonly AppDbContext _dbContext = new();

    private string _loginError = string.Empty;
    private string _passwordError = string.Empty;
    private string _entryError = string.Empty;

    public string Login { get; set; }
    public string Password { get; set; }
    public string LoginError
    {
        get { return _loginError; }
        set
        {
            _loginError = value;
            OnPropertyChanged("LoginError");
        }
    }
    public string PasswordError
    {
        get { return _passwordError; }
        set
        {
            _passwordError = value;
            OnPropertyChanged("PasswordError");
        }
    }
    public string EntryError
    {
        get { return _entryError; }
        set
        {
            _entryError = value;
            OnPropertyChanged("EntryError");
        }
    }

    public ICommand EntryCommand => new RelayCommand(EntryButton_Click);
    public ICommand RegistrationCommand => new RelayCommand(RegistrationButton_Click);

    private async void EntryButton_Click(object obj)
    {
        EntryError = string.Empty;

        var customerRepository = new CustomerRepository(_dbContext);

        var loginValidator = new LoginValidateService();
        var passwordValidator = new PasswordValidateService();

        var customerService = new CustomerService(customerRepository, _logger);

        var hashService = new HashService();

        ResultDto<AuthCustomerDto> request = await customerService.GetAuthorization(
            Login,
            Password,
            loginValidator,
            passwordValidator,
            hashService);

        LoginError = loginValidator.ErrorMessage;
        PasswordError = passwordValidator.ErrorMessage;

        if (request.Status == Status.Success)
        {
            var userModel = new UserModel()
            {
                Id = request.Body.Id,
                FirstName = request.Body.FirstName,
                LastName = request.Body.LastName,
                DateOfBirth = request.Body.DateOfBirth
            };

            navigationVM.UserModel = userModel;

            navigationVM.CurrentView = new PersonalCabinet(_logger);
        }
        else if (request.Status == Status.Filure)
        {
            EntryError = "Пользователь не найден";
        }
    }

    private void RegistrationButton_Click(object obj)
    {
        navigationVM.CurrentView = new Registration(_logger);
    }
}
