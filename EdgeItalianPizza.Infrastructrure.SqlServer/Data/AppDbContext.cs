using EdgeItalianPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Data;

public sealed class AppDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<RoleEntity> Roles { get; set; } = null!;
    public DbSet<BasketEntity> Baskets { get; set; } = null!;
    public DbSet<CityEntity> Cities { get; set; } = null!;
    public DbSet<DeliveryEntity> Deliveries { get; set; } = null!;
    public DbSet<OrderEntity> Orders { get; set; } = null!;
    public DbSet<PizzaEntity> Pizzas { get; set; } = null!;
    public DbSet<PizzaSizeEntity> PizzasSizes { get; set; } = null!;
    public DbSet<ProductEntity> Products { get; set; } = null!;
    public DbSet<RestarauntEntity> Restaraunts { get; set; } = null!;
    public DbSet<SizeEntity> Sizes { get; set; } = null!;
    public DbSet<StatusEntity> Statuses { get; set; } = null!;
    public DbSet<ToppingEntity> Toppings { get; set; } = null!;

    public AppDbContext() { }/*=> Database.EnsureCreated();*/

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
