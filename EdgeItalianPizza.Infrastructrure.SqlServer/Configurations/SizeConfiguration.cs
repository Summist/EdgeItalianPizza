using EdgeItalianPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Configurations;

public sealed class SizeConfiguration : IEntityTypeConfiguration<SizeEntity>
{
    public void Configure(EntityTypeBuilder<SizeEntity> builder)
    {
        builder.ToTable("sizes");

        #region Настройка полей
        builder.HasKey(s => s.Id);

        builder
            .Property(s => s.Id)
            .HasColumnName("size_id")
            .ValueGeneratedOnAdd();

        builder
            .Property(s => s.Radius)
            .HasColumnName("radius")
            .HasColumnType("tinyint");
        #endregion

        #region Настройка связей
        builder
            .HasMany(s => s.PizzasSizes)
            .WithOne(ps => ps.Size)
            .HasForeignKey(ps => ps.SizeId);
        #endregion
    }
}
