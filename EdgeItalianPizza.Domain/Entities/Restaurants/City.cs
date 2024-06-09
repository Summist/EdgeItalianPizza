using EdgeItalianPizza.Domain.Share.Common;

namespace EdgeItalianPizza.Domain.Entities.Restaurants;

/// <summary>
/// Город.
/// </summary>
public sealed class City : DomainEntity
{
    /// <summary>
    /// Максимально допустимая длина для названия города.
    /// </summary>
    public const int MaxNameLength = 100;

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Заведения, которые находятся в городе.
    /// </summary>
    public ICollection<Restaurant> Restaurants { get; } = [];
}
