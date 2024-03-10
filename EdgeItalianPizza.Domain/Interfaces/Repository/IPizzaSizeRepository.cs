using EdgeItalianPizza.Domain.Entities;

namespace EdgeItalianPizza.Domain.Interfaces.Repository;

public interface IPizzaSizeRepository
{
    Task<IEnumerable<PizzaSizeEntity>> GetAllAsync();

    Task<PizzaSizeEntity?> GetByIdAsync(int pizzaSizeId);

    Task<bool> AddAsync(PizzaSizeEntity pizzaSize);

    Task<bool> RemoveAsync(int pizzaSizeId);

    Task<bool> UpdateAsync(PizzaSizeEntity pizzaSize);
}
