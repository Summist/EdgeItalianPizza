using EdgeItalianPizza.Application.DTOs.Customers;
using EdgeItalianPizza.Share.ResultPattern;

namespace EdgeItalianPizza.Application.Interfaces;

public interface ICustomerService
{
    /// <summary>
    /// Асинхронная авторизация.
    /// </summary>
    /// <param name="request">Данные для авторизации.</param>
    /// <returns>
    /// Возвращает <see cref="Result{TValue}"/> с <see cref="Response"/>.
    /// </returns>
    Task<Result<Response>> AuthorizationAsync(Request request);

    /// <summary>
    /// Асинхронная регистрация.
    /// </summary>
    /// <param name="request">Данные для регистрации.</param>
    /// <returns>
    /// Возвращает <see cref="Result{TValue}"/> с <see cref="Response"/>.
    /// </returns>
    Task<Result<Response>> RegistrationAsync(Request request);

    /// <summary>
    /// Асинхронно устанавливает дату рождения.
    /// </summary>
    /// <param name="request">Необходимые данные.</param>
    Task<Result> SetDateOfBirthAsync(DateOfBirthRequest request);

    /// <summary>
    /// Асинхронная смена пароля.
    /// </summary>
    /// <param name="request">Данные для смены пароля.</param>
    Task<Result> ChangePasswordAsync(ChangePasswordRequest request);

    Task AddBonusCoins(long id, int bonusCoins);

    Task RemoveBonusCoins(long id);
}
