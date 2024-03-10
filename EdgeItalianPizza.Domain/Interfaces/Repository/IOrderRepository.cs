using EdgeItalianPizza.Domain.Entities;

namespace EdgeItalianPizza.Domain.Interfaces.Repository;

public interface IOrderRepository
{
    Task<IEnumerable<OrderEntity>> GetAllAsync();

    Task<OrderEntity?> GetByIdAsync(long orderId);

    Task<bool> AddAsync(OrderEntity order);

    Task<bool> RemoveAsync(int orderId);

    Task<bool> UpdateAsync(OrderEntity order);
}
