using EdgeItalianPizza.Domain.Entities;
using EdgeItalianPizza.Domain.Interfaces.Repository;
using EdgeItalianPizza.Infrastructrure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext) => _dbContext = dbContext;

    public Task<bool> AddAsync(CustomerEntity user)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await _dbContext.Customers
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<CustomerEntity?> GetByIdAsync(int id)
    {
        return await _dbContext.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<CustomerEntity?> GetByLoginAndPasswordAsync(string login, string password)
    {
        return await _dbContext.Customers
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

    public Task<bool> UpdateAsync(CustomerEntity user)
    {
        throw new NotImplementedException();
    }
}
