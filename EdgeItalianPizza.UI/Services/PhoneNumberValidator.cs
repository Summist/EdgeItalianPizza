using EdgeItalianPizza.Domain.Entities.Customers.ValueObjects;
using EdgeItalianPizza.Domain.Share.Utilities;
using EdgeItalianPizza.Share.FluentValidation;
using EdgeItalianPizza.UI.Abstractions.Interfaces;

namespace EdgeItalianPizza.UI.Services;

internal sealed class PhoneNumberValidator : IPhoneNumberValidator
{
    private const int MinLength = Constants.LimitLength.MinPhoneNumber;
    private const int MaxLength = PhoneNumber.MaxLength;

    public string Validate(string content)
    {
        var validator = new FluentValidator(content);

        validator
            .NotEmpty("Поле обязательно для заполнения")
            .Length(MinLength, MaxLength)
            .IsMatch(Constants.RegexPattern.PhoneNumber, "Невозможный номер телефона")
            .Validate();

        return validator.ErrorMessage;
    }
}
