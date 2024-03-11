using EdgeItalianPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Configurations;

public sealed class RestarauntConfiguration : IEntityTypeConfiguration<RestarauntEntity>
{
    public void Configure(EntityTypeBuilder<RestarauntEntity> builder)
    {
        builder.ToTable("restaraunts");

        #region Настройка полей
        builder.HasKey(r => r.Id);

        builder
            .Property(r => r.Id)
            .HasColumnName("restaraunt_id")
            .ValueGeneratedOnAdd();

        builder
            .Property(r => r.Address)
            .HasColumnName("address")
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder
            .Property(r => r.CityId)
            .HasColumnName("city_id");
        #endregion

        #region Настройка связей
        builder
            .HasOne(r => r.City)
            .WithMany(c => c.Restaraunts)
            .HasForeignKey(r => r.CityId);

        builder
            .HasMany(r => r.Orders)
            .WithOne(o => o.Restaraunt)
            .HasForeignKey(o => o.RestarauntId);
        #endregion
    }
}
