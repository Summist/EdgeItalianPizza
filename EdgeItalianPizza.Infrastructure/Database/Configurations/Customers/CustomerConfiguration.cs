using EdgeItalianPizza.Domain.Entities.Customers;
using EdgeItalianPizza.Domain.Entities.Customers.ValueObjects;
using EdgeItalianPizza.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EdgeItalianPizza.Infrastructure.Share.Extensions.ConfigurationsExtensions;

namespace EdgeItalianPizza.Infrastructure.Database.Configurations.Customers;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.BuildTable(
            tableName: "customers",
            keyExpression: customer => customer.Id);

        builder.BuildPrimaryKey(
            propertyExpression: customer => customer.Id,
            columnName: "customer_id");

        builder.OwnsOne(customer => customer.PhoneNumber, subbuilder =>
        {
            subbuilder
                .Property(phoneNumber => phoneNumber.Number)
                .HasColumnName("phone_number")
                .HasMaxLength(PhoneNumber.MaxLength);
        });

        builder.OwnsOne(customer => customer.Password, subbuilder =>
        {
            subbuilder
                .Property(password => password.HashValue)
                .HasColumnName("password_hash")
                .HasMaxLength(Password.MaxHashLength);
        });

        builder.BuildPropertyAsDate(
            propertyExpression: customer => customer.DateOfBirth,
            columnName: "date_of_birth",
            isRequired: false);

        builder.BuildPropertyAsInt(
            propertyExpression: customer => customer.BonusCoins,
            columnName: "bonus_coins");

        builder
            .HasMany(customer => customer.Orders)
            .WithOne(order => order.Customer)
            .HasForeignKey("customer_id")
            .IsRequired(false);
    }
}
