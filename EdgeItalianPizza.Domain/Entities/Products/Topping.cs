using EdgeItalianPizza.Domain.Share.Common;

namespace EdgeItalianPizza.Domain.Entities.Products;

/// <summary>
/// Добавки для <see cref="Pizza"/>.
/// </summary>
public sealed class Topping : DomainEntity
{
    /// <summary>
    /// Максимально допустимая длина для названия добавки.
    /// </summary>
    public const int MaxNameLength = 100;

    /// <summary>
    /// Ссылка на изображение.
    /// </summary>
    public string PhotoUri { get; private set; }
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Детали добавки.
    /// </summary>
    public ICollection<ToppingDetails> ToppingDetails { get; } = [];
}
