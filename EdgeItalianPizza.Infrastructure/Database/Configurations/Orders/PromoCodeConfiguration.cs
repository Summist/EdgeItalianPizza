using EdgeItalianPizza.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EdgeItalianPizza.Infrastructure.Share.Extensions.ConfigurationsExtensions;

namespace EdgeItalianPizza.Infrastructure.Database.Configurations.Orders;

internal sealed class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
{
    public void Configure(EntityTypeBuilder<PromoCode> builder)
    {
        builder.BuildTable(
            tableName: "promo_codes",
            keyExpression: promoCode => promoCode.Id);

        builder.BuildPrimaryKey(
            propertyExpression: promoCode => promoCode.Id,
            columnName: "promo_code_id");

        builder.BuildPropertyWithMaxLength(
            propertyExpression: promoCode => promoCode.Code,
            columnName: "code",
            maxLength: PromoCode.MaxCodeLength);

        builder.OwnsOne(promoCode => promoCode.Period, subbuilder =>
        {
            subbuilder
                .Property(period => period.DateStart)
                .HasColumnName("date_start")
                .HasColumnType("DATE");

            subbuilder
                .Property(period => period.DateEnd)
                .HasColumnName("date_end")
                .HasColumnType("DATE");
        });

        builder.OwnsOne(promoCode => promoCode.Discount, subbuilder =>
        {
            subbuilder
                .Property(discount => discount.Value)
                .HasColumnName("discount")
                .HasColumnType("tinyint");
        });

        builder
            .HasMany(promoCode => promoCode.Orders)
            .WithOne(order => order.PromoCode)
            .HasForeignKey("promo_code_id")
            .IsRequired(false);
    }
}
