using EdgeItalianPizza.Domain.Entities;
using EdgeItalianPizza.Domain.Interfaces.Repository;
using EdgeItalianPizza.Infrastructrure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext) => _dbContext = dbContext;

    public Task<bool> AddAsync(UserEntity user, int roleId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await _dbContext.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<UserEntity?> GetByIdAsync(int id)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<UserEntity?> GetByLoginAndPasswordAsync(string login, string password)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u =>
                u.Login == login ||
                u.Password == password
            );
    }

    public Task<bool> RemoveAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(UserEntity user)
    {
        throw new NotImplementedException();
    }
}
