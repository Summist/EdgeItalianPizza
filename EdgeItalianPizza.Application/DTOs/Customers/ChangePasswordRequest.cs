namespace EdgeItalianPizza.Application.DTOs.Customers;

/// <summary>
/// Данные для смены пароля.
/// </summary>
/// <param name="CustomerId">Идентификационный номер покупателя.</param>
/// <param name="OldPassword">Старый пароль.</param>
/// <param name="NewPassword">Новый пароль.</param>
public record ChangePasswordRequest(long CustomerId, string OldPassword, string NewPassword);
