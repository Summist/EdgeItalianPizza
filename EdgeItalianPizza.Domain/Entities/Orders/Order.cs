using EdgeItalianPizza.Domain.Entities.Customers;
using EdgeItalianPizza.Domain.Entities.Orders.ValueObjects;
using EdgeItalianPizza.Domain.Entities.Restaurants;
using EdgeItalianPizza.Domain.Share.Common;
using EdgeItalianPizza.Share.ResultPattern;

namespace EdgeItalianPizza.Domain.Entities.Orders;

/// <summary>
/// Заказ.
/// </summary>
public sealed class Order : DomainEntity
{
    /// <summary>
    /// Код.
    /// </summary>
    public Code Code { get; private set; }
    /// <summary>
    /// Покупатель, совершивший заказ.
    /// </summary>
    public Customer? Customer { get; private set; } = null!;
    /// <summary>
    /// Заведение, исполняющее заказ.
    /// </summary>
    public Restaurant Restaurant { get; private set; }
    /// <summary>
    /// Промокод.
    /// </summary>
    public PromoCode? PromoCode { get; private set; } = null!;
    /// <summary>
    /// Статус заказа.
    /// </summary>
    public Status Status { get; private set; }
    /// <summary>
    /// Время создания.
    /// </summary>
    public DateTime DateOfCreated { get; private set; }
    /// <summary>
    /// Количество бонусных монет.
    /// </summary>
    public int BonusCoins { get; private set; }

    private Order() { }

    private Order(Restaurant restaurant, Customer customer, PromoCode promoCode, DateTime dateOfCreated, int bonusCoins, Status status)
    {
        Restaurant = restaurant;
        Customer = customer;
        PromoCode = promoCode;
        DateOfCreated = dateOfCreated;
        BonusCoins = bonusCoins;
        Status = status;
    }

    public static Result<Order> Create(Restaurant restaurant, Customer customer, PromoCode promoCode, DateTime dateOfCreated, int bonusCoins, Status status)
    {
        if (restaurant is null)
        {
            return "";
        }

        if (customer is null && promoCode is not null)
        {
            return "";
        }

        if (bonusCoins < 0)
        {
            return "";
        }

        if (status is null)
        {
            return "";
        }

        return new Order(restaurant, customer, promoCode, dateOfCreated, bonusCoins, status);
    }

    public void SetCode(Code code)
    {
        if (code is null)
        {
            return;
        }

        Code = code;
    }
}
