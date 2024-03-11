using EdgeItalianPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Configurations;

public sealed class BasketConfiguration : IEntityTypeConfiguration<BasketEntity>
{
    public void Configure(EntityTypeBuilder<BasketEntity> builder)
    {
        builder.ToTable("baskets");

        #region Настройка полей
        builder.HasKey(b => b.Id);

        builder
            .Property(b => b.Id)
            .HasColumnName("basket_id")
            .ValueGeneratedOnAdd();

        builder
            .Property(b => b.ProductId)
            .HasColumnName("product_id");

        builder
            .Property(b => b.Amount)
            .HasColumnName("amount");

        builder
            .Property(b => b.Price)
            .HasColumnName("price")
            .HasColumnType("smallmoney");
        #endregion

        #region Настройка связей
        builder
            .HasOne(b => b.Product)
            .WithMany(p => p.Baskets)
            .HasForeignKey(b => b.ProductId);

        builder
            .HasMany(b => b.Orders)
            .WithMany(o => o.Baskets)
            .UsingEntity(
                "orders_baskets",
                ob =>
                {
                    //ob.HasKey("BaskestId", "OrdersId");
                    ob.Property("BasketsId").HasColumnName("basket_id");
                    ob.Property("OrdersId").HasColumnName("order_id");
                }
            );
        #endregion
    }
}
