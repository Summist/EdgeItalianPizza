using EdgeItalianPizza.Domain.Entities.Restaurants.ValueObjects;
using EdgeItalianPizza.Domain.Share.Utilities;
using EdgeItalianPizza.Share.FluentValidation;
using EdgeItalianPizza.UI.Abstractions.Interfaces;

namespace EdgeItalianPizza.UI.Services;

internal sealed class LoginValidator : ILoginValidator
{
    private const int MinLength = Constants.LimitLength.MinLogin;
    private const int MaxLength = Login.MaxLength;

    /// <summary>
    /// Валидация пароля.
    /// </summary>
    /// <param name="login">Пароль</param>
    /// <returns>Возвращает строку с сообщением об ошибке</returns>
    public string Validate(string login)
    {
        var validator = new FluentValidator(login);

        validator
           .NotEmpty("Поле обязательно для заполения")
           .IsMatch(@"[A-Za-z]", "Пароль должен содержать латинские буквы")
           .Length(MinLength, MaxLength)
           .IsMatch(Login.Regex(), "Невозможный логин")
           .Validate();

        return validator.ErrorMessage;
    }
}
