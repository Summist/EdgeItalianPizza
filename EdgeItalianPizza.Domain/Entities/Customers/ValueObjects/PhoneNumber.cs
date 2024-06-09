using EdgeItalianPizza.Domain.Share.Common;
using EdgeItalianPizza.Share.FluentValidation;
using EdgeItalianPizza.Share.ResultPattern;
using static EdgeItalianPizza.Domain.Share.Utilities.Constants;

namespace EdgeItalianPizza.Domain.Entities.Customers.ValueObjects;

/// <summary>
/// Номер телефона.
/// </summary>
public sealed partial class PhoneNumber : ValueObject
{
    /// <summary>
    /// Максимально допустимая длина для номера телефона.
    /// </summary>
    public const int MaxLength = 25;

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public string Number { get; private set; }

    /// <summary>
    /// Стандартный, приватный конструктор.
    /// </summary>
    private PhoneNumber() { }

    /// <summary>
    /// Приватный конструктор для создания сущности.
    /// </summary>
    /// <param name="number">Номер телефона.</param>
    private PhoneNumber(string number)
    {
        Number = number;
    }

    /// <summary>
    /// Метод по созданию номера телефона.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <returns>
    /// Возвращает тип <see cref="Result{TValue}"/>.
    /// </returns>
    public static Result<PhoneNumber> Create(string phoneNumber)
    {
        var fluentValidator = new FluentValidator(phoneNumber);

        bool isValid = fluentValidator
            .NotEmpty("Номер телефона обязателен для заполнения")
            .Length(LimitLength.MinPhoneNumber, MaxLength)
            .IsMatch(RegexPattern.PhoneNumber, "Невозможный номер телефона")
            .Validate();

        if (!isValid)
            return fluentValidator.ErrorMessage;

        return new PhoneNumber(phoneNumber);
    }

    protected override IEnumerable<object> GetEqualityObjects()
    {
        yield return Number;
    }
}
