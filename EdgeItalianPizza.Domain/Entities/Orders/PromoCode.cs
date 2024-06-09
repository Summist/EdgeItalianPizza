using EdgeItalianPizza.Domain.Entities.Orders.ValueObjects;
using EdgeItalianPizza.Domain.Share.Common;

namespace EdgeItalianPizza.Domain.Entities.Orders;

/// <summary>
/// Промокод.
/// </summary>
public sealed class PromoCode : DomainEntity
{
    /// <summary>
    /// Максимально допустимая длина промокода.
    /// </summary>
    public const int MaxCodeLength = 100;

    /// <summary>
    /// Код.
    /// </summary>
    public string Code { get; private set; }
    /// <summary>
    /// Период действия.
    /// </summary>
    public DateRange Period { get; private set; }

    /// <summary>
    /// Размер скидки.
    /// </summary>
    public Discount Discount { get; private set; }

    /// <summary>
    /// Заказы, в которых использован промокод.
    /// </summary>
    public ICollection<Order> Orders { get; } = [];
}
