using EdgeItalianPizza.Domain.Share.Common;

namespace EdgeItalianPizza.Domain.Entities.Orders;

/// <summary>
/// Статус заказ.
/// </summary>
public sealed class Status : DomainEntity
{
    /// <summary>
    /// Максимально допустимая длина статуса.
    /// </summary>
    public const int MaxLength = 100;

    /// <summary>
    /// Название статуса.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Заказы, в которых использован статус.
    /// </summary>
    public ICollection<Order> Orders { get; } = [];
}
