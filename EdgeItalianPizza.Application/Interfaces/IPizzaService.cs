using EdgeItalianPizza.Application.DTOs.Products;

namespace EdgeItalianPizza.Application.Interfaces;

public interface IPizzaService
{
    /// <summary>
    /// Асинхронное получение необходимых данных о пиццах из базы данных.
    /// </summary>
    /// <returns>
    /// Возвращает <see cref="Task{TResult}"/> содержащий <see cref="IEnumerable{T}"/> с небходимыми данными о пиццах.
    /// </returns>
    Task<IEnumerable<ProductResponse>> GetAllAsync();

    /// <summary>
    /// Асинхронное получение всех возможных данных о пицце по названию товара.
    /// </summary>
    /// <param name="name">Название пиццыю</param>
    /// <returns>
    /// Возвращает <see cref="Task{TResult}"/> содержащий <see cref="IEnumerable{T}"/> с небходимыми данными о пиццах.
    /// </returns>
    Task<SelectedPizzaResponse> GetByNameAsync(string name);
}
