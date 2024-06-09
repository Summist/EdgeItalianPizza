namespace EdgeItalianPizza.Application.DTOs.Restaurants;

/// <summary>
/// Record класс для ответа на запрос о привязке.
/// </summary>
/// <param name="Id">Идентификационный номер заведения в базе даных.</param>
public record class AuthorizationResponse(long Id);
