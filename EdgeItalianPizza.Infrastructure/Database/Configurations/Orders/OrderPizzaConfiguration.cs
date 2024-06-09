using EdgeItalianPizza.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EdgeItalianPizza.Infrastructure.Share.Extensions.ConfigurationsExtensions;

namespace EdgeItalianPizza.Infrastructure.Database.Configurations.Orders;

internal sealed class OrderPizzaConfiguration : IEntityTypeConfiguration<OrderPizza>
{
    public void Configure(EntityTypeBuilder<OrderPizza> builder)
    {
        builder.BuildTable(
            tableName: "orders_pizzas",
            keyExpression: orderPizza => orderPizza.Id);

        builder.BuildPrimaryKey(
            propertyExpression: orderPizza => orderPizza.Id,
            columnName: "order_pizza_id");

        builder.BuildPropertyAsSmallMoney(
            propertyExpression: orderPizza => orderPizza.UnitPrice,
            columnName: "unit_price");

        builder.BuildPropertyAsTinyInt(
            propertyExpression: orderPizza => orderPizza.Amount,
            columnName: "amount");

        builder
            .HasOne(orderPizza => orderPizza.Order)
            .WithMany()
            .HasForeignKey("order_id")
            .IsRequired();

        builder
            .HasOne(orderPizza => orderPizza.Pizza)
            .WithMany()
            .HasForeignKey("pizza_id")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .HasMany(orderPizza => orderPizza.Toppings)
            .WithOne(entity => entity.Pizza)
            .HasForeignKey("order_pizza_id")
            .IsRequired();
    }
}
