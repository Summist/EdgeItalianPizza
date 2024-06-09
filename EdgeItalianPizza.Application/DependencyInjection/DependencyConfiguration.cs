using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EdgeItalianPizza.Application.DependencyInjection;

public static class DependencyConfiguration
{
    /// <summary>
    /// Конфигурация сервисов.
    /// </summary>
    /// <param name="services">Экземпляр класса <see cref="IServiceCollection"/>.</param>
    /// <returns>
    /// Экземпляр класса <see cref="IServiceCollection"/>.
    /// </returns>
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
        => services
            .AddScoped<IRestaurantService, RestaurantService>()
            .AddScoped<IPizzaService, PizzaService>()
            .AddScoped<ICustomerService, CustomerService>()
            .AddScoped<IDrinkService, DrinkService>()
            .AddScoped<IPromoCodeService, PromoCodeService>()
            .AddScoped<IOrderService, OrderService>();
}
