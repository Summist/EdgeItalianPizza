using EdgeItalianPizza.Domain.Entities.Orders;
using EdgeItalianPizza.Domain.Entities.Products;
using EdgeItalianPizza.Domain.Share.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EdgeItalianPizza.Infrastructure.Share.Extensions.ConfigurationsExtensions;

namespace EdgeItalianPizza.Infrastructure.Database.Configurations.Products;

internal sealed class DrinkConfiguration : IEntityTypeConfiguration<Drink>
{
    public void Configure(EntityTypeBuilder<Drink> builder)
    {
        builder.BuildTable(
            tableName: "drinks",
            keyExpression: drink => drink.Id);

        builder.BuildPrimaryKey(
            propertyExpression: drink => drink.Id,
            columnName: "drink_id");

        builder.BuildPropertyWithMaxLength(
            propertyExpression: drink => drink.PhotoUri,
            columnName: "photo_uri",
            maxLength: Constants.LimitLength.PhotoUri);

        builder.OwnsOne(drink => drink.NutritionalValue, subbuilder =>
        {
            subbuilder
                .Property(nutritionalValue => nutritionalValue.Kcal)
                .HasColumnName("kcal")
                .HasColumnType("decimal(4, 1)")
                .IsRequired(false);

            subbuilder
                .Property(nutritionalValue => nutritionalValue.Proteins)
                .HasColumnName("proteins")
                .HasColumnType("decimal(3, 1)")
                .IsRequired(false);

            subbuilder
                .Property(nutritionalValue => nutritionalValue.Fats)
                .HasColumnName("fats")
                .HasColumnType("decimal(3, 1)")
                .IsRequired(false);

            subbuilder
                .Property(nutritionalValue => nutritionalValue.Carbs)
                .HasColumnName("carbs")
                .HasColumnType("decimal(3, 1)")
                .IsRequired(false);

            subbuilder
                .Property(nutritionalValue => nutritionalValue.Portion)
                .HasColumnName("volume")
                .HasColumnType("decimal(4, 1)")
                .IsRequired();
        });

        builder.BuildPropertyAsSmallMoney(
            propertyExpression: drink => drink.Price,
            columnName: "price");

        builder
            .HasOne(drink => drink.Product)
            .WithMany(product => product.Drinks)
            .HasForeignKey("product_id")
            .IsRequired();

        builder
            .HasMany<OrderDrink>()
            .WithOne(orderDrink => orderDrink.Drink)
            .HasForeignKey("drink_id")
            .IsRequired();
    }
}
