using EdgeItalianPizza.Domain.Entities.Products;
using EdgeItalianPizza.Domain.Entities.Products.Interfaces;
using EdgeItalianPizza.Infrastructure.Database.Data;
using EdgeItalianPizza.Infrastructure.Share.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EdgeItalianPizza.Infrastructure.Database.Repositories;

public sealed class PizzaRepository(ApplicationDbContext dbContext) : IPizzaRepository
{
    private readonly DbSet<Pizza> _dbSet = dbContext.Pizzas;

    public async Task<IEnumerable<Pizza>> GetAllAsync()
    {
        return await _dbSet
           .AsNoTracking()
           .Include(pizza => pizza.Product)
           .Where(pizza => pizza.Size.Id == 2)
           .SelectMembers(
               nameof(Pizza.PhotoUri),
               nameof(Pizza.Product),
               nameof(Pizza.Price))
           .OrderBy(pizza => pizza.Price)
           .ToListAsync();
    }

    public async Task<IEnumerable<Pizza>> GetAsync(string name)
    {
        return await _dbSet
            .AsNoTracking()
            .AsSplitQuery()
            .Include(pizza => pizza.Product)
            .Include(pizza => pizza.Size)
            .Where(pizza => pizza.Product.Name == name)
            .ToListAsync();
    }

    public async Task<Pizza?> GetAsync(long id)
    {
        return await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(pizza => pizza.Id == id);
    }
}
