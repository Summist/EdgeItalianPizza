using EdgeItalianPizza.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdgeItalianPizza.Infrastructrure.SqlServer.Configurations;

public sealed class PizzaConfiguration : IEntityTypeConfiguration<PizzaEntity>
{
    public void Configure(EntityTypeBuilder<PizzaEntity> builder)
    {
        builder.ToTable("pizzas");

        #region Настройка полей
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .HasColumnName("pizza_id")
            .ValueGeneratedOnAdd();

        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasColumnName("pizza_name")
            .HasColumnType("varchar(50)");

        builder
            .Property(p => p.Description)
            .IsRequired()
            .HasColumnName("description")
            .HasColumnType("varchar(100)");
        #endregion

        #region Настройка связей
        builder
            .HasMany(p => p.PizzasSizes)
            .WithOne(ps => ps.Pizza)
            .HasForeignKey(ps => ps.PizzaId);

        builder
            .HasMany(p => p.Toppings)
            .WithMany(t => t.Pizzas)
            .UsingEntity(
                "pizzas_toppings",
                pt =>
                {
                    pt.HasKey("PizzaId", "ToppingId");
                    pt.Property("PizzaId").HasColumnName("pizza_id");
                    pt.Property("ToppingId").HasColumnName("ToppingId");
                });
        #endregion
    }
}
