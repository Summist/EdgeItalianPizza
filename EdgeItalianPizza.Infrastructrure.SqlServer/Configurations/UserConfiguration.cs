using EdgeItalianPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
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
            .Property(u => u.DateOfBirth)
            .IsRequired()
            .HasColumnName("date_of_birth");

        builder
            .Property(u => u.RoleId)
            .IsRequired()
            .HasColumnName("role_id");
        #endregion

        #region Настройка связей
        builder
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

        builder
            .HasMany(u => u.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);

        builder
            .HasMany(u => u.Orders)
            .WithOne(o => o.Courier)
            .HasForeignKey(o => o.CourierId);
        #endregion
    }
}
