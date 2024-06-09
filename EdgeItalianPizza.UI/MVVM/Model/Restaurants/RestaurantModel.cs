using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Abstractions.Interfaces;

namespace EdgeItalianPizza.UI.MVVM.Model.Restaurants;

internal sealed class RestaurantModel : ValidatableModel
{
    private readonly ILoginValidator _loginValidator;
    private readonly IPasswordValidator _passwordValidator;

    private string _login = string.Empty;
    /// <summary>
    /// Логин.
    /// </summary>
    public string Login
    {
        get => _login;
        set
        {
            _login = value;
            OnPropertyChanged(nameof(Login));
        }
    }

    private string _password = string.Empty;
    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    public RestaurantModel(ILoginValidator loginValidator, IPasswordValidator passwordValidator)
    {
        _loginValidator = loginValidator;
        _passwordValidator = passwordValidator;

        _columnNames =
        [
            nameof(Login),
            nameof(Password)
        ];
    }

    protected override string IsValid(string columnName) => columnName switch
    {
        nameof(Login) => _loginValidator.Validate(Login),
        nameof(Password) => _passwordValidator.Validate(Password),
        _ => throw new NotImplementedException()
    };
}
