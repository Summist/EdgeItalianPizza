using EdgeItalianPizza.Domain.Entities;

namespace EdgeItalianPizza.Domain.Interfaces.Repository;

public interface IUserRepository
{
    Task<IEnumerable<UserEntity>> GetAllAsync();

    Task<UserEntity?> GetByIdAsync(int id);

    Task<UserEntity?> GetByLoginAndPasswordAsync(string login, string password);

    Task<bool> AddAsync(UserEntity user, int roleId);

    Task<bool> RemoveAsync(long userId);

    Task<bool> UpdateAsync(UserEntity user);
}
