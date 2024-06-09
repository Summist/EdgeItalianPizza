namespace EdgeItalianPizza.Domain.Entities.Products.Interfaces;

/// <summary>
/// Репозиторий для <see cref="Pizza"/>. Необходим для взаимодействия с базой данных.
/// </summary>
public interface IPizzaRepository
{
    /// <summary>
    /// Асинхронное получение всех пицц из базы данных.
    /// </summary>
    /// <returns>
    /// Возращает <see cref="Task{TResult}"/>, содерщащий <see cref="IEnumerable{T}"/> с пиццами.
    /// </returns>
    Task<IEnumerable<Pizza>> GetAllAsync();

    /// <summary>
    /// Асинхронное получение всех пицц из базы данных по <see cref="Product.Name"/>.
    /// </summary>
    /// <param name="name">Название пиццы.</param>
    /// <returns>
    /// Возращает <see cref="Task{TResult}"/>, содерщащий <see cref="IEnumerable{T}"/> с найдеными пиццами.
    /// </returns>
    Task<IEnumerable<Pizza>> GetAsync(string name);

    Task<Pizza> GetAsync(long id);
}
