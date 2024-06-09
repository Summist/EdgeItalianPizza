using EdgeItalianPizza.Domain.Entities.Customers.ValueObjects;
using EdgeItalianPizza.Domain.Entities.Orders;
using EdgeItalianPizza.Domain.Share.Common;
using EdgeItalianPizza.Domain.ValueObjects;

namespace EdgeItalianPizza.Domain.Entities.Customers;

/// <summary>
/// Покупатель.
/// </summary>
public sealed partial class Customer : DomainEntity
{
    /// <summary>
    /// Минимально допустимый возвраст.
    /// </summary>
    private const int MinimumAge = 12;
    /// <summary>
    /// Максимально допустимый возраст.
    /// </summary>
    private const int MaximumAge = 100;

    /// <summary>
    /// Номер телефона.
    /// </summary>
    public PhoneNumber PhoneNumber { get; private set; }
    /// <summary>
    /// Пароль.
    /// </summary>
    public Password Password { get; private set; }
    /// <summary>
    /// Дата рождения.
    /// </summary>
    public DateOnly? DateOfBirth { get; private set; } = null!;
    /// <summary>
    /// Количество бонусных монет.
    /// </summary>
    public int BonusCoins { get; private set; } = 0;

    /// <summary>
    /// Совершенные заказы.
    /// </summary>
    public ICollection<Order> Orders { get; } = [];

    /// <summary>
    /// Стандартный, приватный конструктор.
    /// </summary>
    private Customer() { }

    /// <summary>
    /// Приватный конструктор для создания сущности.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона.</param>
    /// <param name="password">Пароль.</param>
    private Customer(PhoneNumber phoneNumber, Password password)
    {
        PhoneNumber = phoneNumber;
        Password = password;
    }
}
