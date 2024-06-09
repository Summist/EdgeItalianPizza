using EdgeItalianPizza.Domain.Share.Common;

namespace EdgeItalianPizza.Domain.Entities.Products.ValueObjects;

/// <summary>
/// Энергетическая ценность + размер порции (вес/объем).
/// </summary>
public sealed class NutritionalValue : ValueObject
{
    /// <summary>
    /// Килокалории.
    /// </summary>
    public double? Kcal { get; private set; }
    /// <summary>
    /// Белки.
    /// </summary>
    public double? Proteins { get; private set; }
    /// <summary>
    /// Жиры.
    /// </summary>
    public double? Fats { get; private set; }
    /// <summary>
    /// Углеводы.
    /// </summary>
    public double? Carbs { get; private set; }
    /// <summary>
    /// Размер порции.
    /// </summary>
    public double Portion { get; private set; }

    protected override IEnumerable<object> GetEqualityObjects()
    {
        yield return Kcal;
        yield return Proteins;
        yield return Fats;
        yield return Carbs;
        yield return Portion;
    }
}
