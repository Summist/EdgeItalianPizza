namespace EdgeItalianPizza.Application.DTOs.Customers;

/// <summary>
/// Запрос для регистрации/авторизации.
/// </summary>
/// <param name="PhoneNumber">Номер телефона.</param>
/// <param name="Password">Пароль.</param>
public record Request(string PhoneNumber, string Password);
