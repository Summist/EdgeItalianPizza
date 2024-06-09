namespace EdgeItalianPizza.Application.DTOs.Restaurants;

/// <summary>
/// Record класс, необходимый для запроса авторизации.
/// </summary>
/// <param name="Login">Логин заведения.</param>
/// <param name="Password">Пароль заведения.</param>
public record class AuthorizationRequest(string Login, string Password);
