using EdgeItalianPizza.Application.DTOs.Restaurants;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Domain.Entities.Restaurants;
using EdgeItalianPizza.Domain.Entities.Restaurants.Interfaces;
using EdgeItalianPizza.Domain.Entities.Restaurants.ValueObjects;
using EdgeItalianPizza.Domain.ValueObjects;
using EdgeItalianPizza.Share.ResultPattern;
using EdgeItalianPizza.Share.ResultPattern.Extensions;

namespace EdgeItalianPizza.Application.Services;

public sealed class RestaurantService(IRestaurantRepository repository) : IRestaurantService
{
    public async Task<Result<AuthorizationResponse>> Authorization(AuthorizationRequest request)
    {
        try
        {
            string errorMessage = "Неверный логин или пароль";

            if (!AttemptHandleAuthorizationRequest(request, out Login login, out Password password))
                return errorMessage;

            string memberName = nameof(Restaurant.Id);

            var restaurant = await repository.GetAsync(login, password, memberName);

            return restaurant.Match(
                () => new AuthorizationResponse(restaurant.Id),
                () => errorMessage);
        }
        catch
        {
            return "Ошибка при привязке к ресторану";
        }
    }

    /// <summary>
    /// Попытка обработать <see cref="AuthorizationRequest"/>.
    /// </summary>
    /// <param name="request">Данные запроса.</param>
    /// <param name="login">Логин.</param>
    /// <param name="passwordHash">Захешированный пароль.</param>
    /// <returns>
    /// Возвращает <see langword="true"/>, если данные запроса прошли валидацию,
    /// в противном случае <see langword="false"/>.
    /// </returns>
    private static bool AttemptHandleAuthorizationRequest(AuthorizationRequest request, out Login login, out Password password)
    {
        var creationLogin = Login.Create(request.Login);
        var creationPassword = Password.Create(request.Password);

        login = creationLogin.Value;
        password = creationPassword.Value;

        return creationLogin.IsSuccess && creationPassword.IsSuccess;
    }
}
