using EdgeItalianPizza.Domain.Entities.Orders;
using EdgeItalianPizza.Domain.Entities.Restaurants.ValueObjects;
using EdgeItalianPizza.Domain.Share.Common;
using EdgeItalianPizza.Domain.ValueObjects;

namespace EdgeItalianPizza.Domain.Entities.Restaurants;

/// <summary>
/// Заведение.
/// </summary>
public sealed partial class Restaurant : DomainEntity
{
    /// <summary>
    /// Город, в котором находится заведение.
    /// </summary>
    public City City { get; private set; }

    /// <summary>
    /// Логин.
    /// </summary>
    public Login Login { get; private set; }
    /// <summary>
    /// Пароль.
    /// </summary>
    public Password Password { get; private set; }
    /// <summary>
    /// Адрес нахождения заведения.
    /// </summary>
    public Address Address { get; private set; }

    /// <summary>
    /// Заказы, которые выполняет или выполнило заведение.
    /// </summary>
    public ICollection<Order> Orders { get; } = [];
}
