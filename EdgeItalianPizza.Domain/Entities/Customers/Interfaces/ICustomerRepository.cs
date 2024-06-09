using EdgeItalianPizza.Domain.Entities.Customers.ValueObjects;
using EdgeItalianPizza.Domain.ValueObjects;

namespace EdgeItalianPizza.Domain.Entities.Customers.Interfaces;

/// <summary>
/// Репозиторий для <see cref="Customer"/>. Необходим для взаимодействия с базой данных. 
/// </summary>
public interface ICustomerRepository
{
    /// <summary>
    /// Асинхронное получение покупателя из базы данных.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона покупателя.</param>
    /// <param name="password">Пароль покупателя.</param>
    /// <param name="memberNames">Названий свойств, которые нужно получить.</param>
    /// <returns>
    /// Тип <see cref="Customer"/>, если покупатель с вводимым id был найден. В противном случае возвращает <see langword="null"/>.
    /// </returns>
    Task<Customer?> GetAsync(PhoneNumber phoneNumber, Password password, params string[] memberNames);

    /// <summary>
    /// Асинхронное получение покупателя из базы данных по идентификационному номеру.
    /// </summary>
    /// <param name="id">Идентификационный номер.</param>
    /// <param name="memberNames">Названий свойств, которые нужно получить.</param>
    /// <returns>
    /// Тип <see cref="Customer"/>, если покупатель с вводимым id был найден. В противном случае возвращает <see langword="null"/>.
    /// </returns>
    Task<Customer?> GetAsync(long id, params string[] memberNames); 

    /// <summary>
    /// Асинхронное добавление нового покупателя в базу данных.
    /// </summary>
    /// <param name="customer">Покупатель, которого необходимо добавить.</param>
    /// <returns>
    /// Тип <see cref="Customer"/>, если покупатель был успешно добавлен. В противном случае возвращает <see langword="null"/>.
    /// </returns>
    Task<Customer?> AddAsync(Customer customer);

    /// <summary>
    /// Асинхронное плучение всех номеров телефонов из базы данных.
    /// </summary>
    /// <returns>
    /// Возвращает коллекцию строк с номерами телефонов.
    /// </returns>
    Task<IEnumerable<string>> GetAllPhoneNumbersAsync();

    /// <summary>
    /// Асинхронное обновление покупателя.
    /// </summary>
    /// <param name="customer">Покупатель для обновления.</param>
    /// <returns>
    /// Возвращает <see langword="true"/>, если операция прошла успешно,
    /// в противном случае <see langword="false"/>.
    /// </returns>
    Task<bool> UpdateAsync(Customer customer);

    Customer? Get(long id);
}
