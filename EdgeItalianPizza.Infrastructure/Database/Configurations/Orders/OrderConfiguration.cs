using EdgeItalianPizza.Domain.Entities.Orders;
using EdgeItalianPizza.Domain.Entities.Orders.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EdgeItalianPizza.Infrastructure.Share.Extensions.ConfigurationsExtensions;

namespace EdgeItalianPizza.Infrastructure.Database.Configurations.Orders;

internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.BuildTable(
            tableName: "orders",
            keyExpression: order => order.Id);

        builder.BuildPrimaryKey(
            propertyExpression: order => order.Id,
            columnName: "order_id");

        builder.OwnsOne(order => order.Code, subbuilder =>
        {
            subbuilder
                .Property(code => code.Value)
                .HasColumnName("code")
                .HasMaxLength(Code.MaxLength);
        });

        builder.BuildPropertyAsDateTime(
            propertyExpression: order => order.DateOfCreated,
            columnName: "date_of_created");

        builder
            .Property(order => order.BonusCoins)
            .HasColumnName("bonus_coins")
            .HasColumnType("tinyint")
            .IsRequired();

        builder
            .HasOne(order => order.Customer)
            .WithMany(customer => customer.Orders)
            .HasForeignKey("customer_id")
            .IsRequired(false);

        builder
            .HasOne(order => order.Restaurant)
            .WithMany(restaurant => restaurant.Orders)
            .HasForeignKey("restaurant_id")
            .IsRequired();

        builder
            .HasOne(order => order.PromoCode)
            .WithMany(promoCode => promoCode.Orders)
            .HasForeignKey("promo_code_id")
            .IsRequired(false);

        builder
            .HasOne(order => order.Status)
            .WithMany(status => status.Orders)
            .HasForeignKey("status_id")
            .IsRequired();
    }
}
