using EdgeItalianPizza.Domain.Entities.Orders;
using EdgeItalianPizza.Infrastructure.Share.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeItalianPizza.Infrastructure.Database.Configurations.Orders;

internal sealed class PizzaToppingsConfiguration : IEntityTypeConfiguration<PizzaToppings>
{
    public void Configure(EntityTypeBuilder<PizzaToppings> builder)
    {
        builder.BuildTable(
            tableName: "order_pizza_toppings",
            keyExpression: entity => entity.Id);

        builder.BuildPrimaryKey(
            propertyExpression: entity => entity.Id,
            columnName: "order_pizza_topping_id");

        builder
            .HasOne(entity => entity.Pizza)
            .WithMany(orderPizza => orderPizza.Toppings)
            .HasForeignKey("order_pizza_id")
            .IsRequired();

        builder
            .HasOne(entity => entity.Topping)
            .WithMany(topping => topping.Pizzas)
            .HasForeignKey("topping_details_id")
            .IsRequired();
    }
}
