using EdgeItalianPizza.Domain.Entities.Products;
using EdgeItalianPizza.Domain.Entities.Products.Interfaces;
using EdgeItalianPizza.Infrastructure.Database.Data;
using Microsoft.EntityFrameworkCore;

namespace EdgeItalianPizza.Infrastructure.Database.Repositories;

public sealed class DrinkRepository(ApplicationDbContext dbContext) : IDrinkRepository
{
    private readonly DbSet<Drink> _dbSet = dbContext.Drinks;

    public async Task<IEnumerable<Drink>> GetAllAsync()
    {
        return await _dbSet
            .AsNoTracking()
            .Include(drink => drink.Product)
            .ToListAsync();
    }

    public async Task<Drink?> GetAsync(long id)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(drink => drink.Id == id)
            .Include(drink => drink.Product)
            .FirstOrDefaultAsync();
    }
}
