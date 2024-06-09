using EdgeItalianPizza.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EdgeItalianPizza.Infrastructure.Share.Extensions.ConfigurationsExtensions;

namespace EdgeItalianPizza.Infrastructure.Database.Configurations.Products;

internal sealed class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        builder.BuildTable(
            tableName: "sizes",
            keyExpression: size => size.Id);

        builder.BuildPrimaryKey(
            propertyExpression: size => size.Id,
            columnName: "size_id");

        builder.BuildPropertyWithMaxLength(
            propertyExpression: size => size.Name,
            columnName: "size_name",
            maxLength: Size.MaxNameLength);

        builder.BuildPropertyAsSmallInt(
            propertyExpression: size => size.Value,
            columnName: "size_value");

        builder
            .HasMany(size => size.Pizzas)
            .WithOne(pizza => pizza.Size)
            .HasForeignKey("size_id")
            .IsRequired();

        builder
            .HasMany(size => size.ToppingDetails)
            .WithOne(toppingDetails => toppingDetails.Size)
            .HasForeignKey("size_id")
            .IsRequired();
    }
}
