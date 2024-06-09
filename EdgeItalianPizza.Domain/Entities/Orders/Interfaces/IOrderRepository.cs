namespace EdgeItalianPizza.Domain.Entities.Orders.Interfaces;

/// <summary>
/// Интерфейс репозитория для <see cref="Order"/>. Необходим для взаимодействия с базой данных. 
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// Асинхронное добавления нового заказа в базу данных.
    /// </summary>
    /// <param name="order">Заказ, который необходимо добавить в базу данных.</param>
    /// <returns>
    /// Возвращает <see langword="true"/>, если операция прошла успешно. В противном случае <see langword="false"/>.
    /// </returns>
    Task<bool> AddAsync(Order order);

    /// <summary>
    /// Асинхронная проверка на применяемость промокода.
    /// </summary>
    /// <param name="customerId">Идентификационный номер покупателя.</param>
    /// <param name="promoCode">Промокод.</param>
    /// <returns>
    /// Возвращает <see langword="true"/>, если промокод был использован, в противном случае <see langword="false"/>.
    /// </returns>
    Task<bool> IsPromoCodeAppliedAsync(long customerId, string promoCode);
}
