using EdgeItalianPizza.Domain.Entities.Restaurants.ValueObjects;
using EdgeItalianPizza.Domain.ValueObjects;

namespace EdgeItalianPizza.Domain.Entities.Restaurants.Interfaces;

/// <summary>
/// Репозиторий для <see cref="Restaurant"/>. Необходим для взаимодействия с базой данных.
/// </summary>
public interface IRestaurantRepository
{
    /// <summary>
    /// Асинхронное получение заведение из базы данных.
    /// </summary>
    /// <param name="login">Логин заведения.</param>
    /// <param name="password">Пароль заведения.</param>
    /// <param name="memberNames">Название полей необходимых при получении.</param>
    /// <returns>
    /// Возращает тип <see cref="Task{TResult}"/> содержащий <see cref="Restaurant"/> при успешной операции. В противном случае <see langword="null"/>.
    /// </returns>
    Task<Restaurant?> GetAsync(Login login, Password password, params string[] memberNames);

    Task<Restaurant?> GetAsync(long id);
}
