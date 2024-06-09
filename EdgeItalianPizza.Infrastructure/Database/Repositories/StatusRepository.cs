using EdgeItalianPizza.Domain.Entities.Orders;
using EdgeItalianPizza.Domain.Entities.Orders.Interfaces;
using EdgeItalianPizza.Infrastructure.Database.Data;
using Microsoft.EntityFrameworkCore;

namespace EdgeItalianPizza.Infrastructure.Database.Repositories;

public sealed class StatusRepository(ApplicationDbContext dbContext) : IStatusRepository
{
    private readonly DbSet<Status> _dbSet = dbContext.Statuses;

    public Status GetStatusToNewOrder()
    {
        return _dbSet
            .AsNoTracking()
            .FirstOrDefault(status => status.Id == 1);
    }
}
