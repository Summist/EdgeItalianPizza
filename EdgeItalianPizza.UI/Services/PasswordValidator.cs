using EdgeItalianPizza.Domain.Share.Utilities;
using EdgeItalianPizza.Domain.ValueObjects;
using EdgeItalianPizza.Share.FluentValidation;
using EdgeItalianPizza.UI.Abstractions.Interfaces;

namespace EdgeItalianPizza.UI.Services;

internal sealed class PasswordValidator : IPasswordValidator
{
    private const int MinLength = Constants.LimitLength.MinPassword;
    private const int MaxLength = Password.MaxLength;

    public string Validate(string content)
    {
        var validator = new FluentValidator(content);

        validator
            .NotEmpty("Поле обязательно для заполнения")
            .IsMatch(@"[A-Z]", "Пароль должен содержать заглавные буквы")
            .IsMatch(@"[a-z]", "Пароль должен содержать строчные буквы")
            .IsMatch("[0-9]", "Пароль должен содержать цифры")
            .IsMatch("(?=.*[#$^+=!*()@%&])", "Пароль должен содержать специальные символы")
            .Length(MinLength, MaxLength)
            .IsMatch(Constants.RegexPattern.Password, "Невозможный пароль")
            .Validate();

        return validator.ErrorMessage;
    }
}
