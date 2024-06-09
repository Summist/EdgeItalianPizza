using EdgeItalianPizza.Domain.Entities.Orders;
using EdgeItalianPizza.Domain.Entities.Orders.Interfaces;
using EdgeItalianPizza.Infrastructure.Database.Data;
using Microsoft.EntityFrameworkCore;

namespace EdgeItalianPizza.Infrastructure.Database.Repositories;

public sealed class OrderRepository(ApplicationDbContext dbContext) : IOrderRepository
{
    private readonly DbSet<Order> _dbSet = dbContext.Orders;

    public async Task<bool> AddAsync(Order order)
    {
        try
        {
            dbContext.Attach(order.Restaurant);

            if (order.PromoCode is not null)
                dbContext.Attach(order.PromoCode);

            if (order.Customer is not null)
                dbContext.Attach(order.Customer);

            dbContext.Attach(order.Status);

            await _dbSet.AddAsync(order);

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

    public async Task<bool> IsPromoCodeAppliedAsync(long customerId, string promoCode)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(order => order.Customer)
            .Include(order => order.PromoCode)
            .AnyAsync(order => order.Customer.Id == customerId &&
                               order.PromoCode.Code == promoCode);
    }
}
