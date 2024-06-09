namespace EdgeItalianPizza.Domain.Entities.Orders.Interfaces;

public interface IPromoCodeRepository
{
    /// <summary>
    /// Асинхронное получение промокода по имени.
    /// </summary>
    /// <param name="code">Промокод.</param>
    /// <param name="memberNames">Свойства, которые необходимо получить.</param>
    /// <returns>
    /// Возвращает тип <see cref="PromoCode"/>, если операция прошла успешно, в противно случае <see langword="null"/>.
    /// </returns>
    Task<PromoCode?> GetAsync(string code, params string[] memberNames);

    PromoCode? Get(string code);
}
