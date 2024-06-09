using EdgeItalianPizza.Domain.Share.Common;
using EdgeItalianPizza.Domain.Share.Utilities;
using EdgeItalianPizza.Share.FluentValidation;
using EdgeItalianPizza.Share.ResultPattern;
using System.Text.RegularExpressions;

namespace EdgeItalianPizza.Domain.Entities.Restaurants.ValueObjects;

/// <summary>
/// Логин.
/// </summary>
public sealed partial class Login : ValueObject
{
    /// <summary>
    /// Максимально допустимая длина для логина.
    /// </summary>
    public const int MaxLength = 25;

    /// <summary>
    /// Значение логина.
    /// </summary>
    public string Value { get; private set; } = string.Empty;

    /// <summary>
    /// Приватный, стандартный конструктор.
    /// </summary>
    private Login() { }

    /// <summary>
    /// Приватный конструктор для создания сущности.
    /// </summary>
    /// <param name="value"></param>
    private Login(string value)
    {
        Value = value;
    }
    
    [GeneratedRegex(@"[A-Za-z0-9]")]
    public static partial Regex Regex();

    /// <summary>
    /// Метод создания логина.
    /// </summary>
    /// <param name="login">Логин</param>
    /// <returns>
    /// Возвращает <see cref="Result{TValue}"/> с <see cref="Result.IsFailure"/> <see langword="true"/> и <see cref="Result.ErrorMessage"/>
    /// с сообщением об ошибке, если не удалось создать, в противном случае <see cref="Result{TValue}"/> с <see cref="Result{TValue}.Value"/>
    /// с <see cref="Login"/>.
    /// </returns>
    public static Result<Login> Create(string login)
    {
        var fluentValidator = new FluentValidator(login);

        bool isValid = fluentValidator
            .NotEmpty("Логин обязателен для заполнения")
            .Length(Constants.LimitLength.MinLogin, MaxLength)
            .IsMatch(Regex(), "Невозможное значение для логина")
            .Validate();

        if (!isValid)
            return fluentValidator.ErrorMessage;

        return new Login(login);
    }

    protected override IEnumerable<object> GetEqualityObjects()
    {
        yield return Value;
    }
}
