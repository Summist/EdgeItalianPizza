namespace EdgeItalianPizza.UI.Share.Values;

/// <summary>
/// Кбжу + размер порции (вес/объем).
/// </summary>
/// <param name="Kcal">Ккал.</param>
/// <param name="Proteins">Количество белков.</param>
/// <param name="Fats">Количество жиров.</param>
/// <param name="Carbs">Количество углеводов.</param>
/// <param name="Portion">Размер порции (вес/объем).</param>
internal record class NutritionalValue(
    double? Kcal,
    double? Proteins,
    double? Fats,
    double? Carbs,
    double Portion);
