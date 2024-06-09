namespace EdgeItalianPizza.Application.DTOs.Customers;

/// <summary>
/// Данные для установления даты рождения.
/// </summary>
/// <param name="CustomerId">Идентификационный номер покупателя.</param>
/// <param name="DateOfBirth">Желаемая дата рождения.</param>
public record DateOfBirthRequest(long CustomerId, DateOnly? DateOfBirth);
