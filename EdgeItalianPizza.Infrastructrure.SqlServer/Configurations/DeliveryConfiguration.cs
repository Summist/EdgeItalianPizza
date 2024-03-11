using EdgeItalianPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Configurations;

public sealed class DeliveryConfiguration : IEntityTypeConfiguration<DeliveryEntity>
{
    public void Configure(EntityTypeBuilder<DeliveryEntity> builder)
    {
        builder.ToTable("deliveries");

        #region Настройка полей
        builder.HasKey(d => d.Id);

        builder
            .Property(d => d.Id)
            .HasColumnName("delivery_id")
            .ValueGeneratedOnAdd();

        builder
            .Property(d => d.Address)
            .HasColumnName("address")
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder
            .Property(d => d.CityId)
            .HasColumnName("city_id");
        #endregion

        #region Настройка связей
        builder
            .HasOne(d => d.City)
            .WithMany(c => c.Deliveries)
            .HasForeignKey(d => d.CityId);

        builder
            .HasMany(d => d.Orders)
            .WithOne(o => o.Delivery)
            .HasForeignKey(o => o.DeliveryId);
        #endregion
    }
}
