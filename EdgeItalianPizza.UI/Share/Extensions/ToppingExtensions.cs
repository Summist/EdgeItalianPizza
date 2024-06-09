using EdgeItalianPizza.Application.DTOs.Products;
using EdgeItalianPizza.UI.MVVM.Model.Products;
using EdgeItalianPizza.UI.Share.Values;
using EdgeItalianPizza.UI.Share.Enums;
using EdgeItalianPizza.UI.Share.Mappers;

namespace EdgeItalianPizza.UI.Share.Extensions;

internal static class ToppingExtensions
{
    /// <summary>
    /// Конвертирует <see cref="ToppingResponse"/> в <see cref="ToppingModel"/>.
    /// </summary>
    /// <param name="response">Данные для модели из базы данных.</param>
    /// <returns></returns>
    internal static ToppingModel ToModel(this ToppingResponse response)
    {
        return new ToppingModel(response.Details.GetDetails())
        {
            Name = response.Name,
            PhotoUri = response.PhotoUri
        };
    }

    private static Dictionary<PizzaSize, ToppingDetails> GetDetails(this IEnumerable<ToppingDetailsResponse> response)
    {
        var dictionary = new Dictionary<PizzaSize, ToppingDetails>(3);

        foreach (var item in response)
        {
            var size = item.SizeValue.ToPizzaSize();

            dictionary.Add(size, new ToppingDetails(item.Id, item.Price));
        }

        return dictionary;
    }
}
