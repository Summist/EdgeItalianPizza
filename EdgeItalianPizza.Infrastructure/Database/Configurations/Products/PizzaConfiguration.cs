using EdgeItalianPizza.Domain.Entities.Orders;
using EdgeItalianPizza.Domain.Entities.Products;
using EdgeItalianPizza.Domain.Share.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EdgeItalianPizza.Infrastructure.Share.Extensions.ConfigurationsExtensions;

namespace EdgeItalianPizza.Infrastructure.Database.Configurations.Products;

internal sealed class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
{
    public void Configure(EntityTypeBuilder<Pizza> builder)
    {
        builder.BuildTable(
            tableName: "pizzas",
            keyExpression: pizza => pizza.Id);

        builder.BuildPrimaryKey(
            propertyExpression: pizza => pizza.Id,
            columnName: "pizza_id");

        builder.BuildPropertyWithMaxLength(
            propertyExpression: pizza => pizza.PhotoUri,
            columnName: "photo_uri",
            maxLength: Constants.LimitLength.PhotoUri);

        builder.OwnsOne(pizza => pizza.NutritionalValue, subbuilder =>
        {
            subbuilder
                .Property(nutritionalValue => nutritionalValue.Kcal)
                .HasColumnName("kcal")
                .HasColumnType("decimal(4, 1)")
                .IsRequired();

            subbuilder
                .Property(nutritionalValue => nutritionalValue.Proteins)
                .HasColumnName("proteins")
                .HasColumnType("decimal(3, 1)")
                .IsRequired();

            subbuilder
                .Property(nutritionalValue => nutritionalValue.Fats)
                .HasColumnName("fats")
                .HasColumnType("decimal(3, 1)")
                .IsRequired();

            subbuilder
                .Property(nutritionalValue => nutritionalValue.Carbs)
                .HasColumnName("carbs")
                .HasColumnType("decimal(3, 1)")
                .IsRequired();

            subbuilder
                .Property(nutritionalValue => nutritionalValue.Portion)
                .HasColumnName("weight")
                .HasColumnType("decimal(4, 1)")
                .IsRequired();
        });

        builder.BuildPropertyAsSmallMoney(
            propertyExpression: pizza => pizza.Price,
            columnName: "price");

        builder
            .HasOne(pizza => pizza.Product)
            .WithMany(product => product.Pizzas)
            .HasForeignKey("product_id")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .HasOne(pizza => pizza.Size)
            .WithMany(size => size.Pizzas)
            .HasForeignKey("size_id")
            .IsRequired();

        builder
            .HasMany<OrderPizza>()
            .WithOne(orderPizza => orderPizza.Pizza)
            .HasForeignKey("pizza_id")
            .IsRequired();
    }
}
