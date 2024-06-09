using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Abstractions.Interfaces;

namespace EdgeItalianPizza.UI.MVVM.Model.Customers;

internal sealed class CustomerModel : ValidatableModel
{
    private readonly IPhoneNumberValidator _phoneNumberValidator;
    private readonly IPasswordValidator _passwordValidator;

    private string _phoneNumber = string.Empty;
    /// <summary>
    /// Логин.
    /// </summary>
    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            _phoneNumber = value;
            OnPropertyChanged(nameof(PhoneNumber));
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

    public CustomerModel(IPhoneNumberValidator phoneNumberValidator, IPasswordValidator passwordValidator)
    {
        _phoneNumberValidator = phoneNumberValidator;
        _passwordValidator = passwordValidator;

        _columnNames =
        [
            nameof(PhoneNumber),
            nameof(Password)
        ];
    }

    public void Clear()
    {
        PhoneNumber = string.Empty;
        Password = string.Empty;
    }

    protected override string IsValid(string columnName) => columnName switch
    {
        nameof(PhoneNumber) => _phoneNumberValidator.Validate(PhoneNumber),
        nameof(Password) => _passwordValidator.Validate(Password),
        _ => throw new NotImplementedException()
    };
}
