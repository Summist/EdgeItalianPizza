using EdgeItalianPizza.Application.DTOs.Products;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Domain.Entities.Products;
using EdgeItalianPizza.Domain.Entities.Products.Interfaces;
using EdgeItalianPizza.Application.Share.Exceptions;

namespace EdgeItalianPizza.Application.Services;

public sealed class DrinkService(IDrinkRepository repository) : IDrinkService
{
    public async Task<IEnumerable<ProductResponse>> GetAllAsync()
    {
        try
        {
            var drinks = await repository.GetAllAsync().ConfigureAwait(false);

            return HandleDrinksForProductResponse(drinks);
        }
        catch
        {
            return [];
        }
    }

    /// <summary>
    /// Метод обработки напитков в <see cref="ProductResponse"/>.
    /// </summary>
    /// <param name="drinks">Напитки из базы данных.</param>
    /// <exception cref="NotUploadedFromDatabaseException"></exception>
    private static IEnumerable<ProductResponse> HandleDrinksForProductResponse(IEnumerable<Drink> drinks)
    {
        if (!drinks.Any())
            throw new NotUploadedFromDatabaseException("Напитки");

        foreach (var item in drinks)
        {
            yield return new ProductResponse(
                item.PhotoUri,
                item.Product.Name,
                item.Product.Description,
                item.Price,
                item.Id);
        }
    }

    public async Task<SelectedDrinkResponse> GetByIdAsync(long id)
    {
        try
        {
            var drink = await repository.GetAsync(id).ConfigureAwait(false);

            return HandleDrinkForSelectedDrinkResponse(drink);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Обработка напитка в <see cref="SelectedDrinkResponse"/>.
    /// </summary>
    /// <param name="drink">Напиток из базы данных.</param>
    private static SelectedDrinkResponse HandleDrinkForSelectedDrinkResponse(Drink drink)
    {
        return new SelectedDrinkResponse(
                drink.Id,
                drink.PhotoUri,
                drink.Product.Name,
                drink.Product.Description,
                drink.Price,
                drink.NutritionalValue.Portion,
                drink.NutritionalValue.Kcal,
                drink.NutritionalValue.Proteins,
                drink.NutritionalValue.Fats,
                drink.NutritionalValue.Carbs);
    }
}
