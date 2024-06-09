namespace EdgeItalianPizza.Application.DTOs.Products;

/// <summary>
/// Получение стандартных данных для товара.
/// </summary>
/// <param name="PhotoUri">Ссылка на изображение.</param>
/// <param name="Name">Название.</param>
/// <param name="Description">Описание.</param>
/// <param name="Price">Стоимость.</param>
/// <param name="Id">Идентификационный номер товара.</param>
public record ProductResponse(
    string PhotoUri,
    string Name,
    string Description,
    decimal Price,
    long Id = -1
    );
