using EdgeItalianPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Configurations;

public sealed class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable("orders");

        #region Настройка полей
        builder.HasKey(o => o.Id);

        builder
            .Property(o => o.Id)
            .HasColumnName("order_id")
            .ValueGeneratedOnAdd();

        builder
            .Property(o => o.CustomerId)
            .HasColumnName("customer_id");

        builder
            .Property(o => o.CourierId)
            .HasColumnName("courier_id");

        builder
            .Property(o => o.DateCreated)
            .HasColumnName("date_created");

        builder
            .Property(o => o.StatusId)
            .HasColumnName("status_id");

        builder
            .Property(o => o.RestarauntId)
            .HasColumnName("restaraunt_id");

        builder
            .Property(o => o.DeliveryId)
            .HasColumnName("delivery_id");
        #endregion

        #region Настройка связей
        builder
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

        builder
            .HasOne(o => o.Courier)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CourierId);

        builder
            .HasMany(o => o.Baskets)
            .WithMany(b => b.Orders)
            .UsingEntity(
                "orders_baskets",
                ob =>
                {
                    ob.HasKey("OrderId", "BasketId");
                    ob.Property("OrderId").HasColumnName("order_id");
                    ob.Property("BasketId").HasColumnName("basket_id");
                });

        builder
            .HasOne(o => o.Restaraunt)
            .WithMany(r => r.Orders)
            .HasForeignKey(o => o.RestarauntId);

        builder
            .HasOne(o => o.Delivery)
            .WithMany(d => d.Orders)
            .HasForeignKey(o => o.DeliveryId);
        #endregion
    }
}
