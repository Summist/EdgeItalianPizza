using EdgeItalianPizza.Domain.Entities.Orders;
using EdgeItalianPizza.Infrastructure.Share.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EdgeItalianPizza.Infrastructure.Share.Extensions.ConfigurationsExtensions;

namespace EdgeItalianPizza.Infrastructure.Database.Configurations.Orders;

internal sealed class OrderDrinkConfiguration : IEntityTypeConfiguration<OrderDrink>
{
    public void Configure(EntityTypeBuilder<OrderDrink> builder)
    {
        builder.BuildTable(
            tableName: "orders_drinks",
            keyExpression: orderDrink => orderDrink.Id);

        builder.BuildPrimaryKey(
            propertyExpression: orderDrink => orderDrink.Id,
            columnName: "order_drink_id");

        builder.BuildPropertyAsSmallMoney(
            propertyExpression: orderDrink => orderDrink.UnitPrice,
            columnName: "unit_price");

        builder.BuildPropertyAsTinyInt(
            propertyExpression: orderDrink => orderDrink.Amount,
            columnName: "amount");

        builder
            .HasOne(orderDrink => orderDrink.Order)
            .WithMany()
            .HasForeignKey("order_id")
            .IsRequired();

        builder
            .HasOne(orderDrink => orderDrink.Drink)
            .WithMany()
            .HasForeignKey("drink_id")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}
