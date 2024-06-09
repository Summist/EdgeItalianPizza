using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Abstractions.Interfaces;

namespace EdgeItalianPizza.UI.MVVM.Model.Customers;

internal sealed class NewPasswordModel : ValidatableModel
{
    private readonly IPasswordValidator _passwordValidator;

    private string _oldPassword;
    /// <summary>
    /// Старый пароль.
    /// </summary>
    public string OldPassword
    {
        get => _oldPassword;
        set
        {
            _oldPassword = value;
            OnPropertyChanged(nameof(OldPassword));
        }
    }

    private string _newPassword;
    /// <summary>
    /// Новый пароль.
    /// </summary>
    public string NewPassword
    {
        get => _newPassword;
        set
        {
            _newPassword = value;
            OnPropertyChanged(nameof(NewPassword));
        }
    }

    public NewPasswordModel(IPasswordValidator passwordValidator)
    {
        _passwordValidator = passwordValidator;

        _columnNames =
        [
            nameof(OldPassword),
            nameof(NewPassword) 
        ];
    }

    public void Clear()
    {
        OldPassword = string.Empty;
        NewPassword = string.Empty;
    }

    protected override string IsValid(string columnName) => columnName switch
    {
        nameof(OldPassword) => _passwordValidator.Validate(OldPassword),
        nameof(NewPassword) => _passwordValidator.Validate(NewPassword),
        _ => throw new NotImplementedException()
    };
}
