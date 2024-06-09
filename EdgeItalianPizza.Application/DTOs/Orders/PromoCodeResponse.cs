namespace EdgeItalianPizza.Application.DTOs.Orders;

/// <summary>
/// Ответ на применение промокода.
/// </summary>
/// <param name="Id">Идентификационный номер промокода.</param>
/// <param name="Discount">Скидка в %.</param>
public record PromoCodeResponse(
    long Id,
    int Discount);
