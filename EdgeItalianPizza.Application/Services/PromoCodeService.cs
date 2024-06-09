using EdgeItalianPizza.Application.DTOs.Orders;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Domain.Entities.Orders;
using EdgeItalianPizza.Domain.Entities.Orders.Interfaces;
using EdgeItalianPizza.Domain.Entities.Orders.ValueObjects;
using EdgeItalianPizza.Share.ResultPattern;

namespace EdgeItalianPizza.Application.Services;

public sealed class PromoCodeService(
    IOrderRepository orderRepository,
    IPromoCodeRepository promoCodeRepository) : IPromoCodeService
{
    public async Task<Result<PromoCodeResponse>> ApplyAsync(PromoCodeRequest request)
    {
        try
        {
            bool IsApplied = await orderRepository.IsPromoCodeAppliedAsync(request.CustomerId, request.Code).ConfigureAwait(false);

            if (IsApplied)
                return "Данный промокод был использован на этом аккаунте";

            var memberNames = new string[]
            {
                nameof(PromoCode.Id),
                nameof(PromoCode.Code),
                nameof(PromoCode.Period),
                nameof(PromoCode.Discount)
            };

            var promoCode = await promoCodeRepository.GetAsync(request.Code, memberNames).ConfigureAwait(false);

            if (promoCode is null)
                return "Вы ввели несуществующий промокод";

            if (!DateRange.IsDateInRange(promoCode.Period, request.DateNow))
                return "Срок действия промокода истек";

            return new PromoCodeResponse(
                promoCode.Id,
                promoCode.Discount.Value);
        }
        catch
        {
            return "Вы ввели несуществующий промокод";
        }
    }
}
