using EdgeItalianPizza.Domain.Entities.Products;
using EdgeItalianPizza.Domain.Share.Common;
using EdgeItalianPizza.Share.ResultPattern;

namespace EdgeItalianPizza.Domain.Entities.Orders;

/// <summary>
/// Информация о напитке и его количестве в определенном заказе.
/// </summary>
public sealed class OrderDrink : DomainEntity
{
    /// <summary>
    /// Заказ, к которому прикрепляется напиток.
    /// </summary>
    public Order Order { get; private set; }
    /// <summary>
    /// Напиток для заказа.
    /// </summary>
    public Drink Drink { get; private set; }

    /// <summary>
    /// Стоимость за единицу на время заказа.
    /// </summary>
    public decimal UnitPrice { get; private set; }
    /// <summary>
    /// Количество напитков.
    /// </summary>
    public int Amount { get; private set; }

    private OrderDrink() { }

    private OrderDrink(Order order, Drink drink, decimal unitPrice, int amount) 
    {
        Order = order;
        Drink = drink;
        UnitPrice = unitPrice;
        Amount = amount;
    }

    public static Result<OrderDrink> Create(Order order, Drink drink, int amount)
    {
        if (order is null)
        {
            return "";
        }

        if (drink is null)
        {
            return "";
        }

        if (drink.Price <= 0)
        {
            return "";
        }

        if (amount <= 0)
        {
            return "";
        }

        return new OrderDrink(order, drink, drink.Price, amount);
    }
}
