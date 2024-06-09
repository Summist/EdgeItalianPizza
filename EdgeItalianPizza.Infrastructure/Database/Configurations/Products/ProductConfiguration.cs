using EdgeItalianPizza.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EdgeItalianPizza.Infrastructure.Share.Extensions.ConfigurationsExtensions;

namespace EdgeItalianPizza.Infrastructure.Database.Configurations.Products;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.BuildTable(
            tableName: "products",
            keyExpression: product => product.Id);

        builder.BuildPrimaryKey(
            propertyExpression: product => product.Id,
            columnName: "product_id");

        builder.BuildPropertyWithMaxLength(
            propertyExpression: product => product.Name,
            columnName: "product_name",
            maxLength: Product.MaxNameLength);

        builder.BuildPropertyWithMaxLength(
            propertyExpression: product => product.Description,
            columnName: "description",
            maxLength: Product.MaxDescriptionLength,
            false);

        builder
            .HasMany(product => product.Pizzas)
            .WithOne(pizza => pizza.Product)
            .HasForeignKey("product_id")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder
            .HasMany(product => product.Drinks)
            .WithOne(drink => drink.Product)
            .HasForeignKey("product_id")
            .IsRequired();
    }
}
