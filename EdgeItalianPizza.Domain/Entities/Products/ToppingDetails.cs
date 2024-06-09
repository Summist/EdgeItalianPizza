using EdgeItalianPizza.Domain.Entities.Orders;
using EdgeItalianPizza.Domain.Share.Common;

namespace EdgeItalianPizza.Domain.Entities.Products;

/// <summary>
/// Детали о добавке при размере.
/// </summary>
public sealed class ToppingDetails : DomainEntity
{
    /// <summary>
    /// Информация о добавке.
    /// </summary>
    public Topping Topping { get; private set; }
    /// <summary>
    /// Размер.
    /// </summary>
    public Size Size { get; private set; }

    /// <summary>
    /// Стоимость при размере.
    /// </summary>
    public decimal Price { get; private set; }
    /// <summary>
    /// Пиццы в заказе, которые используют добавку.
    /// </summary>
    public ICollection<PizzaToppings> Pizzas { get; } = [];
}
