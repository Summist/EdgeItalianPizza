using EdgeItalianPizza.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EdgeItalianPizza.Infrastructure.Share.Extensions.ConfigurationsExtensions;

namespace EdgeItalianPizza.Infrastructure.Database.Configurations.Products;

internal sealed class ToppingDetailConfiguration : IEntityTypeConfiguration<ToppingDetails>
{
    public void Configure(EntityTypeBuilder<ToppingDetails> builder)
    {
        builder.BuildTable(
            tableName: "topping_details",
            keyExpression: toppingDetails => toppingDetails.Id);

        builder.BuildPrimaryKey(
            propertyExpression: toppingDetails => toppingDetails.Id,
            columnName: "topping_details_id");

        builder.BuildPropertyAsSmallMoney(
            propertyExpression: toppingDetails => toppingDetails.Price,
            columnName: "price");

        builder
            .HasOne(toppingDetails => toppingDetails.Size)
            .WithMany(size => size.ToppingDetails)
            .HasForeignKey("size_id")
            .IsRequired();

        builder
            .HasOne(toppingDetails => toppingDetails.Topping)
            .WithMany(topping => topping.ToppingDetails)
            .HasForeignKey("topping_id")
            .IsRequired();

        builder
            .HasMany(toppingDetails => toppingDetails.Pizzas)
            .WithOne(entity => entity.Topping)
            .HasForeignKey("topping_details_id")
            .IsRequired();
    }
}
