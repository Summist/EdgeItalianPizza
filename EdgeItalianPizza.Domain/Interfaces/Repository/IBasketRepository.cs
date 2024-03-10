using EdgeItalianPizza.Domain.Entities;

namespace EdgeItalianPizza.Domain.Interfaces.Repository;

public interface IBasketRepository
{
    Task<IEnumerable<BasketEntity>> GetAllAsync();

    Task<BasketEntity?> GetByIdAsync(long basketId);

    Task<bool> AddAsync(BasketEntity basket);

    Task<bool> RemoveAsync(int basketId);

    Task<bool> UpdateAsync(BasketEntity basket);
}
