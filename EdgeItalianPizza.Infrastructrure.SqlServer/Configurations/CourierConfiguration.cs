using EdgeItalianPizza.Domain;
using EdgeItalianPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Configurations;

public sealed class CourierConfiguration : IEntityTypeConfiguration<CourierEntity>
{
    public void Configure(EntityTypeBuilder<CourierEntity> builder)
    {
        builder.ToTable("couriers");

        #region Настройка полей
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .HasColumnName("courier_id")
            .ValueGeneratedOnAdd();

        builder
            .Property(c => c.FirstName)
            .HasColumnName("first_name")
            .HasColumnType("varchar(50)");

        builder
            .Property(c => c.LastName)
            .HasColumnName("last_name")
            .HasColumnType("varchar(50)");

        builder
            .Property(c => c.Login)
            .HasColumnName("login")
            .HasColumnType($"varchar({Constants.LOGIN_MAX_LENGTH})");

        builder
            .Property(c => c.Password)
            .HasColumnName("password")
            .HasColumnType($"varchar({Constants.PASSWORD_MAX_LENGTH})");

        builder
            .Property(c => c.INN)
            .HasColumnName("inn")
            .HasColumnType("varchar(12)");

        builder
            .Property(c => c.PassportNumber)
            .HasColumnName("passport_number")
            .HasColumnType("varchar(10)");

        builder
            .Property(c => c.CityId)
            .HasColumnName("city_id");
        #endregion

        #region Настройка связей
        builder
            .HasOne(c => c.City)
            .WithMany(c => c.Couriers)
            .HasForeignKey(c => c.CityId);

        builder
            .HasMany(c => c.Orders)
            .WithOne(o => o.Courier)
            .HasForeignKey(o => o.CourierId);
        #endregion
    }
}
