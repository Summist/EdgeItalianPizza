using EdgeItalianPizza.Domain.Entities;

namespace EdgeItalianPizza.Domain.Interfaces.Repository;

public interface IToppingRepository
{
    Task<IEnumerable<ToppingEntity>> GetAllAsync();

    Task<ToppingEntity?> GetByIdAsync(int toppingId);

    Task<bool> AddAsync(ToppingEntity topping);

    Task<bool> RemoveAsync(int toppingId);

    Task<bool> UpdateAsync(ToppingEntity topping);
}
