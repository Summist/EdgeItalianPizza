using EdgeItalianPizza.Application.DTOs.Products;
using EdgeItalianPizza.Domain.Entities.Products;

namespace EdgeItalianPizza.Application.Share.Mappers;

internal static class ToppingMapper
{
    /// <summary>
    /// Метод "маппинга" в <see cref="ToppingResponse"/>.
    /// </summary>
    /// <param name="toppings">Коллекция деталей добавки.</param>
    internal static ToppingResponse Map(List<ToppingDetails> toppings)
    {
        return new(
            toppings[0].Topping.PhotoUri,
            toppings[0].Topping.Name,
            toppings.ToDetailsResponses());
    }

    private static IEnumerable<ToppingDetailsResponse> ToDetailsResponses(this IEnumerable<ToppingDetails> details)
    {
        foreach (var item in details)
        {
            yield return item.ToDetailsResponse();
        }
    }

    private static ToppingDetailsResponse ToDetailsResponse(this ToppingDetails details)
    {
        return new(
            details.Id,
            details.Size.Value,
            details.Price);
    }
}
