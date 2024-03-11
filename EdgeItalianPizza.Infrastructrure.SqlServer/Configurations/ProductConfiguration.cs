using EdgeItalianPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Configurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("products");

        #region Настройка полей
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .HasColumnName("product_id")
            .ValueGeneratedOnAdd();

        builder
            .Property(p => p.PizzaSizeId)
            .HasColumnName("pizzas_sizes_id");

        builder
            .Property(p => p.ToppingId)
            .HasColumnName("topping_id");
        #endregion

        #region Настройка связей
        builder
            .HasOne(p => p.PizzaSize)
            .WithMany(ps => ps.Products)
            .HasForeignKey(p => p.PizzaSizeId);

        builder
            .HasOne(p => p.Topping)
            .WithMany(t => t.Products)
            .HasForeignKey(p => p.ToppingId);

        builder
            .HasMany(p => p.Baskets)
            .WithOne(b => b.Product)
            .HasForeignKey(b => b.ProductId);
        #endregion
    }
}
