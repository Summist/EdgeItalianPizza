using EdgeItalianPizza.Domain.Share.Common;

namespace EdgeItalianPizza.Domain.Entities.Products;

/// <summary>
/// Размер пиццы и добавок.
/// </summary>
public sealed class Size : DomainEntity
{
    /// <summary>
    /// Максимально допустимая длина для названия размера.
    /// </summary>
    public const int MaxNameLength = 100;

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// Значение.
    /// </summary>
    public int Value { get; private set; }

    /// <summary>
    /// Пиццы, имеющие данный размер.
    /// </summary>
    public ICollection<Pizza> Pizzas { get; } = [];
    /// <summary>
    /// Детали добавок, имеющие данный размер.
    /// </summary>
    public ICollection<ToppingDetails> ToppingDetails { get; } = [];
}
