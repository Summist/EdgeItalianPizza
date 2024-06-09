using EdgeItalianPizza.Domain.Entities.Customers;
using EdgeItalianPizza.Domain.Entities.Orders;
using EdgeItalianPizza.Domain.Entities.Products;
using EdgeItalianPizza.Domain.Entities.Restaurants;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EdgeItalianPizza.Infrastructure.Database.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Представляет DbSet клиентов в базе данных.
    /// </summary>
    public DbSet<Customer> Customers { get; set; } = null!;
    /// <summary>
    /// Представляет DbSet заказов в базе данных.
    /// </summary>
    public DbSet<Order> Orders { get; set; } = null!;
    /// <summary>
    /// Представляет DbSet напитков в заказе в базе данных.
    /// </summary>
    public DbSet<OrderDrink> OrderDrinks { get; set; } = null!;
    /// <summary>
    /// Представляет DbSet пицц в заказе в базе данных.
    /// </summary>
    public DbSet<OrderPizza> OrderPizzas { get; set; } = null!;
    /// <summary>
    /// Представляет DbSet промокодов в базе данных.
    /// </summary>
    public DbSet<PromoCode> PromoCodes { get; set; } = null!;
    /// <summary>
    /// Представляет DbSet статусов в базе данных.
    /// </summary>
    public DbSet<Status> Statuses { get; set; } = null!;
    /// <summary>
    /// Представляет DbSet напитков в базе данных.
    /// </summary>
    public DbSet<Drink> Drinks { get; set; } = null!;
    /// <summary>
    /// Представляет DbSet пицц в базе данных.
    /// </summary>
    public DbSet<Pizza> Pizzas { get; set; } = null!;
    /// <summary>
    /// Представляет DbSet товаров в базе данных.
    /// </summary>
    public DbSet<Product> Products { get; set; } = null!;
    /// <summary>
    /// Представляет DbSet размеров в базе данных.
    /// </summary>
    public DbSet<Size> Sizes { get; set; } = null!;
    /// <summary>
    /// Представляет DbSet добавок в базе данных.
    /// </summary>
    public DbSet<Topping> Toppings { get; set; } = null!;
    /// <summary>
    /// Представляет DbSet деталей к добавке в базе данных.
    /// </summary>
    public DbSet<ToppingDetails> ToppingDetails { get; set; } = null!;
    /// <summary>
    /// Представляет DbSet городов в базе данных.
    /// </summary>
    public DbSet<City> Cities { get; set; } = null!;
    /// <summary>
    /// Представляет DbSet заведений в базе данных.
    /// </summary>
    public DbSet<Restaurant> Restaurants { get; set; } = null!;
    /// <summary>
    /// Представляет DbSet добавок к пицце в заказе в базе данных.
    /// </summary>
    public DbSet<PizzaToppings> OrderPizzaToppings { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
