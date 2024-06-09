namespace EdgeItalianPizza.Domain.Entities.Products.Interfaces;

/// <summary>
/// Репозиторий для <see cref="Drink"/>. Необходим для взаимодействия с базой данных.
/// </summary>
public interface IDrinkRepository
{
    /// <summary>
    /// Асинхронное получение всех напитков из базы данных.
    /// </summary>
    /// <returns>
    /// Возвращает <see cref="Task{IEnumerable{Drink}}"/>, содержащий <see cref="IEnumerable{Drink}"/> с напитками.
    /// </returns>
    Task<IEnumerable<Drink>> GetAllAsync();

    /// <summary>
    /// Асинхронное получение всех данных о напитке.
    /// </summary>
    /// <param name="id">Идентификационный номер.</param>
    /// <returns>
    /// Возвращает все данные о напитке.
    /// </returns>
    Task<Drink?> GetAsync(long id);
}
