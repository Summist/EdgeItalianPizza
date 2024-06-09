using EdgeItalianPizza.Domain.Share.Common;

namespace EdgeItalianPizza.Domain.Entities.Restaurants.ValueObjects;

/// <summary>
/// Информация о местонахождении.
/// </summary>
public sealed class Address : ValueObject
{
    /// <summary>
    /// Максимально допустимая длина для названия улицы.
    /// </summary>
    public const int MaxStreetLength = 100;
    /// <summary>
    /// Максимально допустимая длина для номера дома.
    /// </summary>
    public const int MaxHouseNumberLength = 50;

    /// <summary>
    /// Название улицы.
    /// </summary>
    public string Street { get; private set; }
    /// <summary>
    /// Номер дома.
    /// </summary>
    public string? HouseNumber { get; private set; }

    protected override IEnumerable<object> GetEqualityObjects()
    {
        yield return Street;
        yield return HouseNumber;
    }
}
