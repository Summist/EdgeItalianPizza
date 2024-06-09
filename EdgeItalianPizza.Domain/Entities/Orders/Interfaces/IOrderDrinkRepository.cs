
namespace EdgeItalianPizza.Domain.Entities.Orders.Interfaces;

public interface IOrderDrinkRepository
{
    Task<bool> AddRangeAsync(IEnumerable<OrderDrink> orderDrinks);
}
