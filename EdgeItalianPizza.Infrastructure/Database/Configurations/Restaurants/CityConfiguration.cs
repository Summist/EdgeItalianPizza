using EdgeItalianPizza.Domain.Entities.Restaurants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EdgeItalianPizza.Infrastructure.Share.Extensions.ConfigurationsExtensions;

namespace EdgeItalianPizza.Infrastructure.Database.Configurations.Restaurants;

internal sealed class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.BuildTable(
            tableName: "cities",
            keyExpression: city => city.Id);

        builder.BuildPrimaryKey(
            propertyExpression: city => city.Id,
            columnName: "city_id");

        builder.BuildPropertyWithMaxLength(
            propertyExpression: city => city.Name,
            columnName: "city_name",
            maxLength: City.MaxNameLength);

        builder
            .HasMany(city => city.Restaurants)
            .WithOne(restaurant => restaurant.City)
            .HasForeignKey("city_id")
            .IsRequired();
    }
}
