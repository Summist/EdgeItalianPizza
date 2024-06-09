using EdgeItalianPizza.Domain.Entities.Products;
using EdgeItalianPizza.Domain.Share.Common;
using EdgeItalianPizza.Share.ResultPattern;

namespace EdgeItalianPizza.Domain.Entities.Orders;

/// <summary>
/// Информация о пицце, ее добавках и количестве в определенном заказе.
/// </summary>
public sealed class OrderPizza : DomainEntity
{
    /// <summary>
    /// Заказ, к которому прикрепляется пицца.
    /// </summary>
    public Order Order { get; private set; }
    /// <summary>
    /// Пицца для заказа.
    /// </summary>
    public Pizza Pizza { get; private set; }

    /// <summary>
    /// Стоимость за единицу на время заказа.
    /// </summary>
    public decimal UnitPrice { get; private set; }
    /// <summary>
    /// Количество пицц.
    /// </summary>
    public int Amount { get; private set; }

    /// <summary>
    /// Добавки для выбранной пиццы.
    /// </summary>
    public ICollection<PizzaToppings> Toppings { get; private set; } = [];

    private OrderPizza() { }

    private OrderPizza(Order order, Pizza drink, decimal unitPrice, int amount)
    {
        Order = order;
        Pizza = drink;
        UnitPrice = unitPrice;
        Amount = amount;
    }

    public static Result<OrderPizza> Create(Order order, Pizza drink, int amount)
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

        return new OrderPizza(order, drink, drink.Price, amount);
    }

    public void AddToppings(IEnumerable<PizzaToppings> toppings)
    {
        if (toppings is null)
        {
            return;
        }

        Toppings = toppings.ToList();
    }
}
