using EdgeItalianPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Configurations;

public sealed class CityConfiguration : IEntityTypeConfiguration<CityEntity>
{
    public void Configure(EntityTypeBuilder<CityEntity> builder)
    {
        builder.ToTable("cities");

        #region Настройка полей
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .HasColumnName("city_id")
            .ValueGeneratedOnAdd();

        builder
            .Property(c => c.Name)
            .HasColumnName("city_name")
            .IsRequired()
            .HasColumnType("varchar(50)");
        #endregion

        #region Настройка связей
        builder
            .HasMany(c => c.Restaraunts)
            .WithOne(r => r.City)
            .HasForeignKey(r => r.CityId);

        builder
            .HasMany(c => c.Deliveries)
            .WithOne(d => d.City)
            .HasForeignKey(d => d.CityId);

        builder
            .HasMany(c => c.Couriers)
            .WithOne(c => c.City)
            .HasForeignKey(c => c.CityId);
        #endregion
    }
}
