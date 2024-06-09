using EdgeItalianPizza.Domain.Entities.Restaurants;
using EdgeItalianPizza.Domain.Entities.Restaurants.ValueObjects;
using EdgeItalianPizza.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EdgeItalianPizza.Infrastructure.Share.Extensions.ConfigurationsExtensions;

namespace EdgeItalianPizza.Infrastructure.Database.Configurations.Restaurants;

internal sealed class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.BuildTable(
            tableName: "restaurants",
            keyExpression: restaurant => restaurant.Id);

        builder.BuildPrimaryKey(
            propertyExpression: restaurant => restaurant.Id,
            columnName: "restaurant_id");

        builder.OwnsOne(restaurant => restaurant.Login, subbuilder =>
        {
            subbuilder
                .Property(login => login.Value)
                .HasColumnName("login")
                .HasMaxLength(Login.MaxLength);
        });

        builder.OwnsOne(restaurant => restaurant.Password, subbuilder =>
        {
            subbuilder
                .Property(password => password.HashValue)
                .HasColumnName("password_hash")
                .HasMaxLength(Password.MaxHashLength);
        });

        builder.OwnsOne(restaurant => restaurant.Address, subbuilder =>
        {
            subbuilder
                .Property(address => address.Street)
                .HasColumnName("street")
                .HasMaxLength(Address.MaxStreetLength);

            subbuilder
                .Property(address => address.HouseNumber)
                .HasColumnName("house_number")
                .HasMaxLength(Address.MaxHouseNumberLength)
                .IsRequired(false);
        });

        builder
            .HasOne(restaurant => restaurant.City)
            .WithMany(city => city.Restaurants)
            .HasForeignKey("city_id")
            .IsRequired();

        builder
            .HasMany(restaurant => restaurant.Orders)
            .WithOne(order => order.Restaurant)
            .HasForeignKey("restaurant_id")
            .IsRequired();
    }
}
