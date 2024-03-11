using EdgeItalianPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Configurations;

public sealed class StatusConfiguration : IEntityTypeConfiguration<StatusEntity>
{
    public void Configure(EntityTypeBuilder<StatusEntity> builder)
    {
        builder.ToTable("statuses");

        #region Настройка полей
        builder.HasKey(s => s.Id);

        builder
            .Property(s => s.Id)
            .HasColumnName("status_id")
            .ValueGeneratedOnAdd();

        builder
            .Property(s => s.Name)
            .IsRequired()
            .HasColumnName("status_name")
            .HasColumnType("varchar(50)");
        #endregion

        #region Настройка связей
        builder
            .HasMany(s => s.Orders)
            .WithOne(o => o.Status)
            .HasForeignKey(o => o.StatusId);
        #endregion
    }
}
