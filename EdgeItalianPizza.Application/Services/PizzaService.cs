using EdgeItalianPizza.Application.DTOs.Products;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Application.Share.Exceptions;
using EdgeItalianPizza.Application.Share.Mappers;
using EdgeItalianPizza.Domain.Entities.Products;
using EdgeItalianPizza.Domain.Entities.Products.Interfaces;

namespace EdgeItalianPizza.Application.Services;

public sealed class PizzaService(IPizzaRepository pizzaRepository, IToppingDetailsRepository toppingRepository) : IPizzaService
{
    public async Task<IEnumerable<ProductResponse>> GetAllAsync()
    {
        try
        {
            var pizzas = await pizzaRepository.GetAllAsync().ConfigureAwait(false);

            return HandlePizzasForProductResponse(pizzas);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Обработка пицц в <see cref="ProductResponse"/>.
    /// </summary>
    /// <param name="pizzas">Пиццы из базы данных.</param>
    private static IEnumerable<ProductResponse> HandlePizzasForProductResponse(IEnumerable<Pizza> pizzas)
    {
        if (!pizzas.Any())
            throw new NotUploadedFromDatabaseException("пицца");

        foreach (var item in pizzas)
        {
            yield return new ProductResponse(
                item.PhotoUri,
                item.Product.Name,
                item.Product.Description,
                item.Price);
        }
    }

    public async Task<SelectedPizzaResponse?> GetByNameAsync(string name)
    {
        try
        {
            var pizzas = await pizzaRepository.GetAsync(name).ConfigureAwait(false);

            var toppings = await toppingRepository.GetAllAsync().ConfigureAwait(false);

            return HandleDatasForSelectedPizzaResponse(pizzas, toppings);
        }
        catch (NotUploadedFromDatabaseException)
        {
            return null;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Обработка данных в <see cref="SelectedPizzaResponse"/>.
    /// </summary>
    /// <param name="pizzas">Пиццы из базы данных.</param>
    /// <param name="toppings">Добавки из базы данных.</param>
    /// <exception cref="NotUploadedFromDatabaseException"></exception>
    private static SelectedPizzaResponse HandleDatasForSelectedPizzaResponse(IEnumerable<Pizza> pizzas, IEnumerable<ToppingDetails> toppings)
    {
        if (!pizzas.Any())
            throw new NotUploadedFromDatabaseException("Пиццы");

        if (!toppings.Any())
            throw new NotUploadedFromDatabaseException("Добавки");

        var pizzasResponse = GetPizzasResponse(pizzas);

        var toppingsResponse = GetToppingsResponse(toppings);

        return new SelectedPizzaResponse(pizzasResponse, toppingsResponse);
    }

    /// <summary>
    /// Метод получения <see cref="PizzaResponse"/>.
    /// </summary>
    /// <param name="pizzas">Пиццы.</param>
    private static IEnumerable<PizzaResponse> GetPizzasResponse(IEnumerable<Pizza> pizzas)
    {
        foreach (var item in pizzas)
        {
            yield return new PizzaResponse(
                item.Id,
                item.PhotoUri,
                item.Product.Name,
                item.Product.Description,
                item.Price,
                item.Size.Value,
                (double)item.NutritionalValue.Kcal,
                (double)item.NutritionalValue.Proteins,
                (double)item.NutritionalValue.Fats,
                (double)item.NutritionalValue.Carbs,
                item.NutritionalValue.Portion);
        }
    }

    private static IEnumerable<ToppingResponse> GetToppingsResponse(IEnumerable<ToppingDetails> toppings)
    {
        var dictionary = new Dictionary<string, List<ToppingDetails>>();

        foreach (var topping in toppings)
        {
            string toppingName = topping.Topping.Name;

            if (dictionary.TryGetValue(toppingName, out List<ToppingDetails> value))
            {
                value.Add(topping);
            }
            else
            {
                dictionary.Add(toppingName, new List<ToppingDetails>(3) { topping });
            }
        }

        foreach (var item in dictionary)
        {
            yield return ToppingMapper.Map(item.Value);
        }
    }
}
