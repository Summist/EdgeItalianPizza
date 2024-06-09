using EdgeItalianPizza.Domain.Entities.Products.ValueObjects;
using EdgeItalianPizza.Domain.Share.Common;

namespace EdgeItalianPizza.Domain.Entities.Products;

/// <summary>
/// Напиток.
/// </summary>
public sealed class Drink : DomainEntity
{
    /// <summary>
    /// Название и описание напитка.
    /// </summary>
    public Product Product { get; private set; }

    /// <summary>
    /// Ссылка на изображение.
    /// </summary>
    public string PhotoUri { get; private set; }
    /// <summary>
    /// Энергетическая ценность.
    /// </summary>
    public NutritionalValue NutritionalValue { get; private set; }
    /// <summary>
    /// Стоимость.
    /// </summary>
    public decimal Price { get; private set; }
}
