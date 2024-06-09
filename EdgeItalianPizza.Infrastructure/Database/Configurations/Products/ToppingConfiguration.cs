using EdgeItalianPizza.Domain.Entities.Products;
using EdgeItalianPizza.Domain.Share.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EdgeItalianPizza.Infrastructure.Share.Extensions.ConfigurationsExtensions;

namespace EdgeItalianPizza.Infrastructure.Database.Configurations.Products;

internal sealed class ToppingConfiguration : IEntityTypeConfiguration<Topping>
{
    public void Configure(EntityTypeBuilder<Topping> builder)
    {
        builder.BuildTable(
            tableName: "toppings",
            keyExpression: topping => topping.Id);

        builder.BuildPrimaryKey(
            propertyExpression: topping => topping.Id,
            columnName: "topping_id");

        builder.BuildPropertyWithMaxLength(
            propertyExpression: topping => topping.PhotoUri,
            columnName: "photo_uri",
            maxLength: Constants.LimitLength.PhotoUri);

        builder.BuildPropertyWithMaxLength(
            propertyExpression: topping => topping.Name,
            columnName: "topping_name",
            maxLength: Topping.MaxNameLength);

        builder
            .HasMany(topping => topping.ToppingDetails)
            .WithOne(toppingDetails => toppingDetails.Topping)
            .HasForeignKey("topping_id")
            .IsRequired();
    }
}
