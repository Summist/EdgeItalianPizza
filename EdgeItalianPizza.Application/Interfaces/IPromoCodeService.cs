using EdgeItalianPizza.Application.DTOs.Orders;
using EdgeItalianPizza.Share.ResultPattern;

namespace EdgeItalianPizza.Application.Interfaces;

public interface IPromoCodeService
{
    /// <summary>
    /// Асинхронная проверка на доступность промокода.
    /// </summary>
    /// <param name="request">Данные для проверки.</param>
    Task<Result<PromoCodeResponse>> ApplyAsync(PromoCodeRequest request);
}
