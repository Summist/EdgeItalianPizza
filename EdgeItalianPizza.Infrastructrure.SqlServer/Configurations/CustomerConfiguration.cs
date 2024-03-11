using EdgeItalianPizza.Domain;
using EdgeItalianPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Configurations;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.ToTable("users");

        #region Настройка полей
        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .IsRequired()
            .HasColumnName("user_id")
            .ValueGeneratedOnAdd();

        builder
            .Property(u => u.FisrtName)
            .IsRequired()
            .HasColumnName("first_name")
            .HasColumnType("varchar(50)");

        builder
            .Property(u => u.LastName)
            .IsRequired()
            .HasColumnName("last_name")
            .HasColumnType("varchar(50)");

        builder
            .Property(c => c.Login)
            .IsRequired()
            .HasColumnName("login")
            .HasColumnType($"varchar({Constants.LOGIN_MAX_LENGTH})");

        builder
            .Property(c => c.Password)
            .IsRequired()
            .HasColumnName("password")
            .HasColumnType($"varchar({Constants.PASSWORD_MAX_LENGTH})");

        builder
            .Property(u => u.DateOfBirth)
            .IsRequired()
            .HasColumnName("date_of_birth");
        #endregion

        #region Настройка связей
        builder
            .HasMany(u => u.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);
        #endregion
    }
}
