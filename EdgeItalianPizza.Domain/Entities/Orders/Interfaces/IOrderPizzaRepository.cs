
namespace EdgeItalianPizza.Domain.Entities.Orders.Interfaces;

public interface IOrderPizzaRepository
{
    Task<bool> AddRangeAsync(IEnumerable<OrderPizza> orderPizzas);
}
