﻿using EdgeItalianPizza.Domain.Entities;
using EdgeItalianPizza.Infrastructrure.SqlServer.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Data;

public sealed class AppDbContext : DbContext
{
    public DbSet<CustomerEntity> Customers { get; set; } = null!;
    public DbSet<CourierEntity> Couriers { get; set; } = null!;
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

    public AppDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=EdgeItalianPizza;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new CustomerConfiguration())
            .ApplyConfiguration(new CourierConfiguration())
            .ApplyConfiguration(new StatusConfiguration())
            .ApplyConfiguration(new SizeConfiguration())
            .ApplyConfiguration(new PizzaConfiguration())
            .ApplyConfiguration(new ToppingConfiguration())
            .ApplyConfiguration(new CityConfiguration())
            .ApplyConfiguration(new DeliveryConfiguration())
            .ApplyConfiguration(new RestarauntConfiguration())
            .ApplyConfiguration(new PizzaSizeConfiguration())
            .ApplyConfiguration(new OrderConfiguration())
            .ApplyConfiguration(new BasketConfiguration())
            .ApplyConfiguration(new ProductConfiguration());

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);
    }
}
