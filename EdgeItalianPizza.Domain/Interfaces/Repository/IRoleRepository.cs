using EdgeItalianPizza.Domain.Entities;

namespace EdgeItalianPizza.Domain.Interfaces.Repository;

public interface IRoleRepository
{
    Task<IEnumerable<RoleEntity>> GetAllAsync();

    Task<string> GetNameByIdAsync(int roleId);

    Task<bool> AddAsync(RoleEntity role);

    Task<bool> RemoveAsync(int roleId);

    Task<bool> UpdateAsync(RoleEntity role);
}
