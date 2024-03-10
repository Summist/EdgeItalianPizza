using EdgeItalianPizza.Domain.Entities;

namespace EdgeItalianPizza.Domain.Interfaces.Repository;

public interface IStatusRepository
{
    Task<IEnumerable<StatusEntity>> GetAllAsync();

    Task<StatusEntity?> GetByIdAsync(long statusId);

    Task<bool> AddAsync(StatusEntity status);

    Task<bool> RemoveAsync(int statusId);

    Task<bool> UpdateAsync(StatusEntity status);
}
