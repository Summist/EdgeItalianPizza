using EdgeItalianPizza.Domain.Entities;

namespace EdgeItalianPizza.Domain.Interfaces.Repository;

public interface IPizzaRepository
{
    Task<IEnumerable<PizzaEntity>> GetAllAsync();

    Task<PizzaEntity?> GetByIdAsync(int pizzaId);

    Task<bool> AddAsync(PizzaEntity pizza);

    Task<bool> RemoveAsync(int pizzaId);

    Task<bool> UpdateAsync(PizzaEntity pizza);
}
