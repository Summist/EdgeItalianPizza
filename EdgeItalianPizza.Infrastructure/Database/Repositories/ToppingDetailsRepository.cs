using EdgeItalianPizza.Domain.Entities.Products;
using EdgeItalianPizza.Domain.Entities.Products.Interfaces;
using EdgeItalianPizza.Infrastructure.Database.Data;
using Microsoft.EntityFrameworkCore;

namespace EdgeItalianPizza.Infrastructure.Database.Repositories;

public sealed class ToppingDetailsRepository(ApplicationDbContext dbContext) : IToppingDetailsRepository
{
    private readonly DbSet<ToppingDetails> _dbSet = dbContext.ToppingDetails;

    public async Task<IEnumerable<ToppingDetails>> GetAllAsync()
    {
        return await _dbSet
            .AsNoTracking()
            .AsSplitQuery()
            .Include(toppingDetails => toppingDetails.Size)
            .Include(toppingDetails => toppingDetails.Topping)
            .ToListAsync();
    }

    public async Task<ToppingDetails> GetAsync(long id)
    {
        return await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(toppingDetails => toppingDetails.Id == id);
    }
}
