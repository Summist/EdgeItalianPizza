namespace EdgeItalianPizza.Application.DTOs.Orders;

/// <summary>
/// Запрос на проверку доступности промокода для пользователя.
/// </summary>
/// <param name="CustomerId">Идентификационный номер пользователя.</param>
/// <param name="Code">Код промокода.</param>
public record PromoCodeRequest(
    long CustomerId,
    string Code,
    DateOnly DateNow);
