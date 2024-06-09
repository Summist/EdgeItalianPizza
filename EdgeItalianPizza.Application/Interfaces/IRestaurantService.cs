using EdgeItalianPizza.Application.DTOs.Restaurants;
using EdgeItalianPizza.Share.ResultPattern;

namespace EdgeItalianPizza.Application.Interfaces;

public interface IRestaurantService
{
    /// <summary>
    /// Прикрепление заведения в терминалу.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<Result<AuthorizationResponse>> Authorization(AuthorizationRequest request);
}
