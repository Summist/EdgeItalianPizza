using EdgeItalianPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Configurations;

public sealed class PizzaSizeConfiguration : IEntityTypeConfiguration<PizzaSizeEntity>
{
    public void Configure(EntityTypeBuilder<PizzaSizeEntity> builder)
    {
        builder.ToTable("pizzas_sizes");

        #region Настрой полей
        builder.HasKey(ps => ps.Id);

        builder
            .Property(ps => ps.Id)
            .HasColumnName("pizzas_sizes_id")
            .ValueGeneratedOnAdd();

        builder
            .Property(ps => ps.PizzaId)
            .HasColumnName("pizza_id");

        builder
            .Property(ps => ps.SizeId)
            .HasColumnName("size_id");

        builder
            .Property(ps => ps.Price)
            .HasColumnName("price")
            .HasColumnType("smallmoney");

        builder
            .Property(ps => ps.PhotoName)
            .HasColumnName("photo_name")
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder
            .Property(ps => ps.Energy)
            .HasColumnName("energy")
            .HasColumnType("decimal(5,2)");

        builder
            .Property(ps => ps.Proteins)
            .HasColumnName("proteins")
            .HasColumnType("decimal(5,2)");

        builder
            .Property(ps => ps.Fats)
            .HasColumnName("fats")
            .HasColumnType("decimal(5,2)");

        builder
            .Property(ps => ps.Carbohydrates)
            .HasColumnName("carbohydrates")
            .HasColumnType("decimal(5,2)");

        builder
            .Property(ps => ps.Weight)
            .HasColumnName("weigth")
            .HasColumnType("decimal(5,2)");
        #endregion

        #region Настройка связей
        builder
            .HasOne(ps => ps.Pizza)
            .WithMany(p => p.PizzasSizes)
            .HasForeignKey(ps => ps.PizzaId);

        builder
            .HasOne(ps => ps.Size)
            .WithMany(s => s.PizzasSizes)
            .HasForeignKey(ps => ps.SizeId);

        builder
            .HasMany(ps => ps.Products)
            .WithOne(p => p.PizzaSize)
            .HasForeignKey(p => p.PizzaSizeId);
        #endregion
    }
}
