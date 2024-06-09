using EdgeItalianPizza.Application.DTOs.Products;

namespace EdgeItalianPizza.Application.Interfaces;

public interface IDrinkService
{
    /// <summary>
    /// Асинхронное получение необходимых данных о пиццах из базы данных.
    /// </summary>
    /// <returns>
    /// Возвращает <see cref="Task{TResult}"/> содержащий <see cref="IEnumerable{T}"/> с небходимыми данными о пиццах.
    /// </returns>
    Task<IEnumerable<ProductResponse>> GetAllAsync();

    /// <summary>
    /// Асинхронное получение необходимых данных о напитке из базы данных.
    /// </summary>
    /// <returns>
    /// Возвращает <see cref="Task{TResult}"/> с небходимыми данными о напитке.
    /// </returns>
    Task<SelectedDrinkResponse> GetByIdAsync(long id);
}
