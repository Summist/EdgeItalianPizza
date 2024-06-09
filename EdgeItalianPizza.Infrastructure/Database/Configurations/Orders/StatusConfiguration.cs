using EdgeItalianPizza.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static EdgeItalianPizza.Infrastructure.Share.Extensions.ConfigurationsExtensions;

namespace EdgeItalianPizza.Infrastructure.Database.Configurations.Orders;

internal sealed class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.BuildTable(
            tableName: "statuses",
            keyExpression: status => status.Id);

        builder.BuildPrimaryKey(
            propertyExpression: status => status.Id,
            columnName: "status_id");

        builder.BuildPropertyWithMaxLength(
            propertyExpression: status => status.Name,
            columnName: "status_name",
            maxLength: Status.MaxLength);

        builder
            .HasMany(status => status.Orders)
            .WithOne(order => order.Status)
            .HasForeignKey("status_id")
            .IsRequired();
    }
}
