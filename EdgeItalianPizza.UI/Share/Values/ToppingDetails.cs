namespace EdgeItalianPizza.UI.Share.Values;

/// <summary>
/// Информация о деталях добавки.
/// </summary>
/// <param name="Id">Идентификационный номер детали добавки.</param>
/// <param name="Price">Стоимость добавки.</param>
internal record ToppingDetails(
    long Id,
    decimal Price);
