using EdgeItalianPizza.Domain.Share.Common;

namespace EdgeItalianPizza.Domain.Entities.Products;

/// <summary>
/// Название и описание товаров.
/// </summary>
public sealed class Product : DomainEntity
{
    /// <summary>
    /// Максимально допустимая длина для названия.
    /// </summary>
    public const int MaxNameLength = 100;
    /// <summary>
    /// Максимально допустимая длина для описания.
    /// </summary>
    public const int MaxDescriptionLength = 200;

    /// <summary>
    /// Название товара.
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// Описание товара.
    /// </summary>
    public string? Description { get; private set; } = null!;

    /// <summary>
    /// Пиццы, которе используют данные о товаре.
    /// </summary>
    public ICollection<Pizza> Pizzas { get; } = [];
    /// <summary>
    /// Напитки, которые используют данные о товаре.
    /// </summary>
    public ICollection<Drink> Drinks { get; } = [];
}
