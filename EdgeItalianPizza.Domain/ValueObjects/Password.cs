using EdgeItalianPizza.Domain.Share.Common;
using EdgeItalianPizza.Share.FluentValidation;
using EdgeItalianPizza.Share.HashServices;
using EdgeItalianPizza.Share.ResultPattern;
using static EdgeItalianPizza.Domain.Share.Utilities.Constants;

namespace EdgeItalianPizza.Domain.ValueObjects;

/// <summary>
/// Пароль.
/// </summary>
public sealed partial class Password : ValueObject
{
    /// <summary>
    /// Максимальная длина для пароля.
    /// </summary>
    public const int MaxLength = 32;
    /// <summary>
    /// Максимальная длина для захешированного пароля.
    /// </summary>
    public const int MaxHashLength = 50;

    /// <summary>
    /// Захершированный пароль.
    /// </summary>
    public string HashValue { get; private set; }

    /// <summary>
    /// Стандартный, приватный конструктор.
    /// </summary>
    private Password() { }

    /// <summary>
    /// Приватный конструктор для создания.
    /// </summary>
    /// <param name="hashValue">Захешированный пароль.</param>
    private Password(string hashValue)
    {
        HashValue = hashValue;
    }

    /// <summary>
    /// Метод создания пароля.
    /// </summary>
    /// <param name="password">Пароль.</param>
    public static Result<Password> Create(string password)
    {
        if (!IsValid(password, out string errorMessage))
            return errorMessage;

        string passwordHash = HashService.Hash(password);

        return new Password(passwordHash);
    }

    /// <summary>
    /// Метод проверки пароля на валидность.
    /// </summary>
    /// <param name="password">Пароль.</param>
    /// <param name="errorMessage">Сообщение об ошибке.</param>
    /// <returns>
    /// Возвращает <see langword="true"/>, если пароль прошел все необходимые проверки,
    /// в противном случае <see langword="false"/>.
    /// </returns>
    private static bool IsValid(string password, out string errorMessage)
    {
        var fluentValidator = new FluentValidator(password);

        bool isValid = fluentValidator
            .NotEmpty("Пароль обязателен для заполнения")
            .Length(LimitLength.MinPassword, MaxLength)
            .IsMatch(RegexPattern.Password, "Невозможный пароль")
            .Validate();

        errorMessage = fluentValidator.ErrorMessage;

        return isValid;
    }

    /// <summary>
    /// Метод проверки пароля на валидность.
    /// </summary>
    /// <param name="password">Пароль.</param>
    /// <returns>
    /// Возвращает <see langword="true"/>, если пароль прошел все необходимые проверки,
    /// в противном случае <see langword="false"/>.
    /// </returns>
    private static bool IsValid(string password)
    {
        return IsValid(password, out _);
    }

    protected override IEnumerable<object> GetEqualityObjects()
    {
        yield return HashValue;
    }
}
