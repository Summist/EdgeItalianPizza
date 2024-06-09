namespace EdgeItalianPizza.Application.DTOs.Customers;

/// <summary>
/// Ответ при регистрации/авторизации.
/// </summary>
/// <param name="Id">Идентификационный номер покупателя.</param>
/// <param name="PhoneNumber">Номер телефона покупателя.</param>
/// <param name="DateOfBirth">Дата рождения покупателя.</param>
/// <param name="BonusCoins">Количество бонусных монет покупателя.</param>
public record Response(
    long Id,
    string PhoneNumber,
    DateOnly? DateOfBirth,
    int BonusCoins
    );
