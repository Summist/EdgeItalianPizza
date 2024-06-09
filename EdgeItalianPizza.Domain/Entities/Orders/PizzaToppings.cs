using EdgeItalianPizza.Domain.Entities.Products;
using EdgeItalianPizza.Domain.Share.Common;
using EdgeItalianPizza.Share.ResultPattern;

namespace EdgeItalianPizza.Domain.Entities.Orders;

/// <summary>
/// Информация о пицце в заказе и ее добавке.
/// </summary>
public sealed class PizzaToppings : DomainEntity
{
    /// <summary>
    /// Привязка к пицце в конкретном заказе.
    /// </summary>
    public OrderPizza Pizza { get; set; } 
    /// <summary>
    /// Добавка для пиццы.
    /// </summary>
    public ToppingDetails Topping { get; set; }

    private PizzaToppings() { }

    private PizzaToppings(OrderPizza orderPizza, ToppingDetails toppingDetails)
    {
        Pizza = orderPizza;
        Topping = toppingDetails;
    }

    public static Result<PizzaToppings> Create(OrderPizza orderPizza, ToppingDetails toppingDetails)
    {
        if (orderPizza == null)
        {
            return "";
        }

        if (toppingDetails is null)
        {
            return "";
        }

        return new PizzaToppings(orderPizza, toppingDetails);  
    }
}
