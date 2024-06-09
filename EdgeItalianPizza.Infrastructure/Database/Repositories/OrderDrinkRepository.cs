using EdgeItalianPizza.Domain.Entities.Orders;
using EdgeItalianPizza.Domain.Entities.Orders.Interfaces;
using EdgeItalianPizza.Infrastructure.Database.Data;

namespace EdgeItalianPizza.Infrastructure.Database.Repositories;

public sealed class OrderDrinkRepository(ApplicationDbContext dbContext) : IOrderDrinkRepository
{
    public async Task<bool> AddRangeAsync(IEnumerable<OrderDrink> orderDrinks)
    {
        foreach (var item in orderDrinks)
        {
            dbContext.Attach(item);
        }

        await dbContext.OrderDrinks.AddRangeAsync(orderDrinks);

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
