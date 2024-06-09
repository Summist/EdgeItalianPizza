using EdgeItalianPizza.Domain.Share.Common;

namespace EdgeItalianPizza.Domain.Entities.Orders.ValueObjects;

/// <summary>
/// Скидка.
/// </summary>
public sealed class Discount : ValueObject
{
    /// <summary>
    /// Размер скидки.
    /// </summary>
    public byte Value { get; private set; }

    protected override IEnumerable<object> GetEqualityObjects()
    {
        yield return Value;
    }
}
