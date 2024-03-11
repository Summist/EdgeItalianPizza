using EdgeItalianPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Configurations;

public sealed class ToppingConfiguration : IEntityTypeConfiguration<ToppingEntity>
{
    public void Configure(EntityTypeBuilder<ToppingEntity> builder)
    {
        builder.ToTable("toppings");

        #region Настройка полей
        builder.HasKey(t => t.Id);

        builder
            .Property(t => t.Id)
            .HasColumnName("topping_id")
            .ValueGeneratedOnAdd();

        builder
            .Property(t => t.Name)
            .HasColumnName("topping_name")
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder
            .Property(t => t.PhotoName)
            .IsRequired()
            .HasColumnName("photo_name")
            .HasColumnType("varchar(50)");

        builder
            .Property(t => t.Price)
            .HasColumnName("price")
            .HasColumnType("smallmoney");
        #endregion

        #region Настройка связей
        builder
            .HasMany(t => t.Pizzas)
            .WithMany(p => p.Toppings)
            .UsingEntity(
                "pizzas_toppings",
                pt =>
                {
                    //pt.HasKey("ToppingsId", "PizzasId");
                    pt.Property("ToppingsId").HasColumnName("topping_id");
                    pt.Property("PizzasId").HasColumnName("pizza_id");
                });

        builder
            .HasMany(t => t.Products)
            .WithOne(p => p.Topping)
            .HasForeignKey(p => p.ToppingId);
        #endregion
    }
}
