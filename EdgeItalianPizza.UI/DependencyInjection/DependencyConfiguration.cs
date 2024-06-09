using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Abstractions.Interfaces;
using EdgeItalianPizza.UI.MVVM.Model.Customers;
using EdgeItalianPizza.UI.MVVM.Model.Restaurants;
using EdgeItalianPizza.UI.MVVM.View;
using EdgeItalianPizza.UI.MVVM.ViewModel;
using EdgeItalianPizza.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EdgeItalianPizza.UI.DependencyInjection;

internal static class DependencyConfiguration
{
    /// <summary>
    /// Конфигурация Models, Views, ViewModels, Services.
    /// </summary>
    /// <param name="services">Экземпляр класса <see cref="IServiceCollection"/>.</param>
    /// <returns>
    /// Экземпляр класса <see cref="IServiceCollection"/>.
    /// </returns>
    internal static IServiceCollection ConfigureUI(this IServiceCollection services)
        => services
            .ConfigureServices()
            .ConfigureModels()
            .ConfigureViews()
            .ConfigureViewModels();

    /// <summary>
    /// Конфигурация Models.
    /// </summary>
    /// <param name="services">Экземпляр класса <see cref="IServiceCollection"/>.</param>
    /// <returns>
    /// Экземпляр класса <see cref="IServiceCollection"/>.
    /// </returns>
    private static IServiceCollection ConfigureModels(this IServiceCollection services)
        => services
            .AddSingleton<RestaurantModel>()
            .AddSingleton<CustomerModel>()
            .AddSingleton<NewPasswordModel>();

    /// <summary>
    /// Конфигурация Views.
    /// </summary>
    /// <param name="services">Экземпляр класса <see cref="IServiceCollection"/>.</param>
    /// <returns>
    /// Экземпляр класса <see cref="IServiceCollection"/>.
    /// </returns>
    private static IServiceCollection ConfigureViews(this IServiceCollection services)
        => services
            .AddSingleton(provider => new MainWindow
            { 
                DataContext = provider.GetRequiredService<MainViewModel>()
            })
            .AddSingleton<RestaurantAttach>()
            .AddSingleton<Menu>()
            .AddSingleton<Pizzas>()
            .AddSingleton<PizzaCard>()
            .AddSingleton<Customer>()
            .AddSingleton<CustomerAuth>()
            .AddSingleton<CustomerReg>()
            .AddSingleton<PersonalCabinet>()
            .AddSingleton<Drinks>()
            .AddSingleton<DrinkCard>()
            .AddSingleton<Basket>()
            .AddSingleton<Order>()
            .AddSingleton<Empty>()
            .AddSingleton<Error>()
            .AddSingleton<NewPassword>()
            .AddSingleton<Code>();

    /// <summary>
    /// Конфигурация ViewModels.
    /// </summary>
    /// <param name="services">Экземпляр класса <see cref="IServiceCollection"/>.</param>
    /// <returns>
    /// Экземпляр класса <see cref="IServiceCollection"/>.
    /// </returns>
    private static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        => services
            .AddScoped<MainViewModel>()
            .AddScoped<RestaurantAttachViewModel>()
            .AddScoped<MenuViewModel>()
            .AddScoped<PizzasViewModel>()
            .AddScoped<INotifySelected<string>>(provider => provider.GetRequiredService<PizzasViewModel>())
            .AddScoped<INotifySelected<long>>(provider => provider.GetRequiredService<DrinksViewModel>())
            .AddScoped<PizzaCardViewModel>()
            .AddScoped(provider => new CustomerViewModel(
                provider.GetService<INavigationService>(),
                provider.GetRequiredService<CustomerAuthViewModel>(),
                provider.GetRequiredService<CustomerRegViewModel>()))
            .AddScoped<CustomerAuthViewModel>()
            .AddScoped<CustomerRegViewModel>()
            .AddScoped<INotifyNavigation>(provider => provider.GetRequiredService<CustomerAuthViewModel>())
            .AddScoped<INotifyNavigation>(provider => provider.GetRequiredService<CustomerRegViewModel>())
            .AddScoped<PersonalCabinetViewModel>()
            .AddScoped<DrinksViewModel>()
            .AddScoped<DrinkCardViewModel>()
            .AddScoped<BasketViewModel>()
            .AddScoped<OrderViewModel>()
            .AddScoped<EmptyViewModel>()
            .AddScoped<ErrorViewModel>()
            .AddScoped<NewPasswordViewModel>()
            .AddScoped<CodeViewModel>();

    /// <summary>
    /// Конфигурация Services.
    /// </summary>
    /// <param name="services">Экземпляр класса <see cref="IServiceCollection"/>.</param>
    /// <returns>
    /// Экземпляр класса <see cref="IServiceCollection"/>.
    /// </returns>
    private static IServiceCollection ConfigureServices(this IServiceCollection services)
        => services
            .AddTransient<INavigationService, NavigationService>()
            .AddTransient<Func<Type, ViewModelBase>>(provider => viewModelBase =>
                (ViewModelBase)provider.GetRequiredService(viewModelBase))
            .AddSingleton<ILoginValidator, LoginValidator>()
            .AddSingleton<IPasswordValidator, PasswordValidator>()
            .AddSingleton<IPhoneNumberValidator, PhoneNumberValidator>()
            .AddSingleton<IBonusCoinsCalculator, BonusCoinsCalculator>();
}
