using EdgeItalianPizza.Domain.Entities.Customers.Interfaces;
using EdgeItalianPizza.Domain.Entities.Orders.Interfaces;
using EdgeItalianPizza.Domain.Entities.Products.Interfaces;
using EdgeItalianPizza.Domain.Entities.Restaurants.Interfaces;
using EdgeItalianPizza.Infrastructure.Database.Data;
using EdgeItalianPizza.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EdgeItalianPizza.Infrastructure.DependencyInjection;

public static class DependencyConfiguration
{
    /// <summary>
    /// Конфигурация <see cref="DbContext"/> и репозиториев.
    /// </summary>
    /// <param name="services">Экземпляр класса <see cref="IServiceCollection"/>.</param>
    /// <returns>
    /// Экземпляр класса <see cref="IServiceCollection"/>.
    /// </returns>
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfigurationRoot configuration)
        => services
            .ConfigureDbContext(configuration)
            .ConfigureRepository();

    /// <summary>
    /// Конфигурация <see cref="DbContext"/>.
    /// </summary>
    /// <param name="services">Экземпляр класса <see cref="IServiceCollection"/>.</param>
    /// <returns>
    /// Экземпляр класса <see cref="IServiceCollection"/>.
    /// </returns>
    private static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfigurationRoot configuration)
        => services.AddDbContextPool<ApplicationDbContext>(options => options
            .EnableThreadSafetyChecks(false)
            .UseSqlServer(
                configuration.GetConnectionString("Database"),
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

    /// <summary>
    /// Конфигурация репозиториев.
    /// </summary>
    /// <param name="services">Экземпляр класса <see cref="IServiceCollection"/>.</param>
    /// <returns>
    /// Экземпляр класса <see cref="IServiceCollection"/>.
    /// </returns>
    private static IServiceCollection ConfigureRepository(this IServiceCollection services)
        => services
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IDrinkRepository, DrinkRepository>()
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IPizzaRepository, PizzaRepository>()
            .AddScoped<IRestaurantRepository, RestaurantRepository>()
            .AddScoped<IToppingDetailsRepository, ToppingDetailsRepository>()
            .AddScoped<IPromoCodeRepository, PromoCodeRepository>()
            .AddScoped<IStatusRepository, StatusRepository>()
            .AddScoped<IOrderDrinkRepository, OrderDrinkRepository>()
            .AddScoped<IOrderPizzaRepository, OrderPizzaRepository>();
}
