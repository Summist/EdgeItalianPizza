using EdgeItalianPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Configurations;

public sealed class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.ToTable("roles");

        #region Настройка полей
        builder.HasKey(r => r.Id);

        builder
            .Property(r => r.Id)
            .HasColumnName("role_id")
            .ValueGeneratedOnAdd();

        builder
            .Property(r => r.Name)
            .IsRequired()
            .HasColumnName("role_name")
            .HasColumnType("varchar(50)");
        #endregion

        #region Настройка связей
        builder
            .HasMany(r => r.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId);
        #endregion
    }
}
