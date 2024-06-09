using EdgeItalianPizza.Domain.Entities.Orders;
using EdgeItalianPizza.Domain.Entities.Orders.Interfaces;
using EdgeItalianPizza.Infrastructure.Database.Data;
using Microsoft.EntityFrameworkCore;

namespace EdgeItalianPizza.Infrastructure.Database.Repositories;

public sealed class OrderPizzaRepository(ApplicationDbContext dbContext) : IOrderPizzaRepository
{
    public async Task<bool> AddRangeAsync(IEnumerable<OrderPizza> orderPizzas)
    {
        foreach (var orderPizza in orderPizzas)
        {
            dbContext.Entry(orderPizza).State = EntityState.Added;

            foreach (var topping in orderPizza.Toppings)
            {
                dbContext.Entry(topping).State = EntityState.Added;
            }
        }

        try
        {
            return await dbContext.SaveChangesAsync() > 0;
        }
        catch
        {
            dbContext.ChangeTracker.Clear();

            return false;
        }
        finally
        {
            dbContext.ChangeTracker.Clear();
        }
    }
}
