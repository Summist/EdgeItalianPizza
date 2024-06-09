using EdgeItalianPizza.Domain.Entities.Customers.ValueObjects;
using EdgeItalianPizza.Domain.ValueObjects;
using EdgeItalianPizza.Share.ResultPattern;
using System.Text.RegularExpressions;

namespace EdgeItalianPizza.Domain.Entities.Customers;

/// <summary>
/// Покупатель.
/// </summary>
public sealed partial class Customer
{
    /// <summary>
    /// Метод создания покупателя.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="password">Пароль.</param>
    public static Result<Customer> Create(PhoneNumber phoneNumber, Password password)
    {
        Result resultOfVerification = DataValidVerification(phoneNumber, password);

        if (resultOfVerification.IsFailure)
            return resultOfVerification.ErrorMessage;

        return new Customer(phoneNumber, password);
    }

    /// <summary>
    /// Метод для создания нового покупателя.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="phoneNumbers">Все использованные номера телефонов.</param>
    /// <param name="password">Пароль.</param>
    public static Result<Customer> Create(PhoneNumber phoneNumber, IEnumerable<string> phoneNumbers, Password password)
    {
        Result verificationResult = DataValidVerification(phoneNumber, password);

        if (verificationResult.IsFailure)
            return verificationResult.ErrorMessage;

        if (!IsPhoneNumberAvailable(phoneNumber.Number, phoneNumbers))
            return "Номер телефона уже занят";

        return new Customer(phoneNumber, password);
    }

    /// <summary>
    /// Метод устанавливающий дату рождения.
    /// </summary>
    /// <param name="dateOfBirth">Желаемая дата.</param>
    /// <returns>
    /// Возвращает <see langword="true"/>, если операция прошла успешно, в противном случае <see langword="false"/>.
    /// </returns>
    public bool SetDateOfBirth(DateOnly? dateOfBirth)
    {
        if (DateOfBirth.HasValue)
            return false;

        if (!IsAgeAppropriate(dateOfBirth))
            return false;

        DateOfBirth = dateOfBirth;
        return true;
    }

    /// <summary>
    /// Смена пароля.
    /// </summary>
    /// <param name="customer">Покупатель, чей пароль должен быть сменен</param>
    /// <param name="oldPassword">Старый пароль.</param>
    /// <param name="newPassword">Новый пароль.</param>
    /// <returns></returns>
    public Result ChangePassword(Password oldPassword, Password newPassword)
    {
        if (Password != oldPassword)
            return "Новый или старый пароль не верно заполнен";

        if (oldPassword == null || newPassword == null)
            return "Новый или старый пароль не верно заполнен";

        if (oldPassword == newPassword)
            return "Новый пароль не должен совпадать со старым паролем";

        Password = newPassword;
        return Result.Success();
    }

    /// <summary>
    /// Метод проверки данных на валидность.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="password">Пароль.</param>
    /// <returns>
    /// Возвращает <see cref="Result"/> c <see cref="Result.IsSuccess"/> равное <see langword="true"/>, если данные прошли проверку,
    /// в противном случае <see cref="Result"/> с <see cref="Result.IsFailure"/> равное <see langword="true"/> и <see cref="Result.ErrorMessage"/> 
    /// с сообщением об ошибке.
    /// </returns>
    private static Result DataValidVerification(PhoneNumber phoneNumber, Password password)
    {
        if (phoneNumber == null)
            return "Номер телефона обязателен для заполнения";

        if (password == null)
            return "Пароль обязателен для заполнения";

        return Result.Success();
    }

    /// <summary>
    /// Свободен ли номер телефона.
    /// </summary>
    /// <param name="phoneNumber">Желаемый номер телефона.</param>
    /// <param name="phoneNumbers">Все существующие номера телефонов.</param>
    /// <returns>
    /// Возвращает <see langword="true"/>, если среди всех существующих номеров телефонов не оказалось желаемого,
    /// в противном случае <see langword="false"/>.
    /// </returns>
    private static bool IsPhoneNumberAvailable(string phoneNumber, IEnumerable<string> phoneNumbers)
    {
        string formattedPhoneNumber = FormatPhoneNumber(phoneNumber);

        return !phoneNumbers.Any(number => FormatPhoneNumber(number) == formattedPhoneNumber);
    }

    /// <summary>
    /// Метод приведения номера телефона к единому формату.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <returns>
    /// Возвращает номер телефона в формате "+7 (000) 000-00-00".
    /// </returns>
    private static string FormatPhoneNumber(string phoneNumber)
    {
        const string pattern = @"[^\d]";

        string standardizedNumber = Regex.Replace(phoneNumber, pattern, string.Empty);

        return $"+7 ({standardizedNumber.Substring(1, 3)})" +
               $" {standardizedNumber.Substring(4, 3)}" +
               $"-{standardizedNumber.Substring(7, 2)}" +
               $"-{standardizedNumber.Substring(9, 2)}";
    }

    /// <summary>
    /// Метод проверки валидный ли возраст.
    /// </summary>
    /// <param name="dateOfBirth">Желаемая дата рождения.</param>
    /// <returns>
    /// Возвращает <see langword="true"/>, если возраст подходит всем необходимым критериям,
    /// в противном случае <see langword="false"/>.
    /// </returns>
    private static bool IsAgeAppropriate(DateOnly? dateOfBirth)
    {
        if (!dateOfBirth.HasValue)
            return false;

        DateOnly currentDate = DateOnly.FromDateTime(DateTime.UtcNow);
        int age = currentDate.Year - dateOfBirth.Value.Year;

        if (currentDate.Month < dateOfBirth.Value.Month ||
            (currentDate.Month == dateOfBirth.Value.Month && currentDate.Day < dateOfBirth.Value.Day))
            age--;

        return age >= MinimumAge && age <= MaximumAge;
    }

    public void AddBonusCoins(int bonusCoins)
    {
        if (bonusCoins < 0)
        {
            return;
        }

        BonusCoins += bonusCoins;
    }

    public void RemoveBonusCoins()
    {
        BonusCoins = 0;
    }
}
