namespace EdgeItalianPizza.Application.DTOs.Products;

/// <summary>
/// Данные о выбранной пицце.
/// </summary>
/// <param name="Pizzas">Данные о пицце при размере.</param>
/// <param name="Toppings">Добавки.</param>
public record SelectedPizzaResponse(
    IEnumerable<PizzaResponse> Pizzas,
    IEnumerable<ToppingResponse> Toppings);

/// <summary>
/// Данные о пицце.
/// </summary>
/// <param name="Id">Идентификационный номер пиццы.</param>
/// <param name="PhotoUri">Ссылка на изображение.</param>
/// <param name="Name">Название.</param>
/// <param name="Description">Описание.</param>
/// <param name="Price">Стоимость.</param>
/// <param name="SizeValue">Размер пиццы.</param>
/// <param name="Kcal">Ккал.</param>
/// <param name="Proteins">Количество белков.</param>
/// <param name="Fats">Количество жиров.</param>
/// <param name="Carbs">Количество углеводов.</param>
/// <param name="Portion">Вес.</param>
public record PizzaResponse(
    long Id,
    string PhotoUri,
    string Name,
    string Description,
    decimal Price,
    int SizeValue,
    double Kcal,
    double Proteins,
    double Fats,
    double Carbs,
    double Portion);

/// <summary>
/// Данные о добавке.
/// </summary>
/// <param name="PhotoUri">Ссылка на изображение.</param>
/// <param name="Name">Название.</param>
/// <param name="Details">Детали добавки.</param>
public record ToppingResponse(
    string PhotoUri,
    string Name,
    IEnumerable<ToppingDetailsResponse> Details);

/// <summary>
/// Данные о деталях добавки.
/// </summary>
/// <param name="Id">Идентификационный номер детали добавки.</param>
/// <param name="SizeValue">Размер пиццы.</param>
/// <param name="Price">Стоимость добавки.</param>
public record ToppingDetailsResponse(
    long Id,
    int SizeValue,
    decimal Price);
