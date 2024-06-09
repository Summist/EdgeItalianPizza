using EdgeItalianPizza.Domain.Entities.Restaurants;
using EdgeItalianPizza.Domain.Entities.Restaurants.Interfaces;
using EdgeItalianPizza.Domain.Entities.Restaurants.ValueObjects;
using EdgeItalianPizza.Domain.ValueObjects;
using EdgeItalianPizza.Infrastructure.Database.Data;
using EdgeItalianPizza.Infrastructure.Share.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EdgeItalianPizza.Infrastructure.Database.Repositories;

public sealed class RestaurantRepository(ApplicationDbContext dbContext) : IRestaurantRepository
{
    private readonly DbSet<Restaurant> _dbSet = dbContext.Restaurants;

    public async Task<Restaurant?> GetAsync(Login login, Password password, params string[] memberNames)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(restaurant =>
                       restaurant.Login.Value == login.Value &&
                       restaurant.Password.HashValue == password.HashValue)
            .SelectMembers(memberNames)
            .SingleOrDefaultAsync();
    }

    public Task<Restaurant?> GetAsync(long id)
    {
        return _dbSet
            .AsNoTracking()
            .Where(restaurant => restaurant.Id == id)
            .SingleAsync();
    }
}
