using EdgeItalianPizza.Domain.Entities;

namespace EdgeItalianPizza.Domain.Interfaces.Repository;

public interface ISizeRepository
{
    Task<IEnumerable<SizeEntity>> GetAllAsync();

    Task<SizeEntity?> GetByIdAsync(int sizeId);

    Task<bool> AddAsync(SizeEntity size);

    Task<bool> RemoveAsync(int sizeId);

    Task<bool> UpdateAsync(SizeEntity size);
}
