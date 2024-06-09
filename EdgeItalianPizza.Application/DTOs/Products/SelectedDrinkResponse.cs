namespace EdgeItalianPizza.Application.DTOs.Products;

/// <summary>
/// Получение даннных для выбранного напитка.
/// </summary>
/// <param name="Id">Идентификационный номер напитка.</param>
/// <param name="PhotoUri">Ссылка на изображение.</param>
/// <param name="Name">Название.</param>
/// <param name="Description">Описание.</param>
/// <param name="Price">Стоимость.</param>
/// <param name="Volume">Объем.</param>
/// <param name="Kcal">Ккал.</param>
/// <param name="Proteins">Количество белков.</param>
/// <param name="Fats">Количество жиров.</param>
/// <param name="Carbs">Количество углеводов.</param>
public record SelectedDrinkResponse(
    long Id,
    string PhotoUri,
    string Name,
    string Description,
    decimal Price,
    double Volume,
    double? Kcal,
    double? Proteins,
    double? Fats,
    double? Carbs);
