using EdgeItalianPizza.Domain.Entities.Products.ValueObjects;
using EdgeItalianPizza.Domain.Share.Common;

namespace EdgeItalianPizza.Domain.Entities.Products;

/// <summary>
/// Пицца.
/// </summary>
public sealed class Pizza() : DomainEntity
{
    /// <summary>
    /// Название и описание пиццы.
    /// </summary>
    public Product Product { get; private set; }
    /// <summary>
    /// Размер пиццы.
    /// </summary>
    public Size Size { get; private set; }

    /// <summary>
    /// Ссылка на изображение.
    /// </summary>
    public string PhotoUri { get; private set; }
    /// <summary>
    /// Энергетическая ценность + вес.
    /// </summary>
    public NutritionalValue NutritionalValue { get; private set; }
    /// <summary>
    /// Стоимость.
    /// </summary>
    public decimal Price { get; private set; }
}
