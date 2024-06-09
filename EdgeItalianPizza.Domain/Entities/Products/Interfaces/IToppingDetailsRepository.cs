namespace EdgeItalianPizza.Domain.Entities.Products.Interfaces;

/// <summary>
/// Репозиторий для <see cref="ToppingDetails"/>. Необходим для взаимодействия с базой данных.
/// </summary>
public interface IToppingDetailsRepository
{
    /// <summary>
    /// Асинхронное получение всех добавок из базы данных.
    /// </summary>
    /// <returns>
    /// Возвращает <see cref="Task{TResult}"/>, содержащий <see cref="IEnumerable{T}"/> с добавками.
    /// </returns>
    Task<IEnumerable<ToppingDetails>> GetAllAsync();

    Task<ToppingDetails> GetAsync(long id);
}
