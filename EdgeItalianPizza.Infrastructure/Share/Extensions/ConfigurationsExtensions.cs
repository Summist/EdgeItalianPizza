using EdgeItalianPizza.Domain.Share.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace EdgeItalianPizza.Infrastructure.Share.Extensions;

internal static class ConfigurationsExtensions
{
    internal static KeyBuilder BuildTable<TEntity>(
        this EntityTypeBuilder<TEntity> builder,
        string tableName,
        Expression<Func<TEntity, object?>> keyExpression
        ) where TEntity : DomainEntity
    {
        return builder
            .ToTable(tableName)
            .HasKey(keyExpression);
    }

    internal static PropertyBuilder<long> BuildPrimaryKey<TEntity>(
        this EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, long>> propertyExpression,
        string columnName)
            where TEntity : DomainEntity
    {
        return builder
            .Property(propertyExpression)
            .HasColumnName(columnName)
            .HasColumnType(ColumnTypes.Id)
            .ValueGeneratedOnAdd();
    }

    internal static PropertyBuilder<decimal> BuildPropertyAsSmallMoney<TEntity>(
        this EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, decimal>> propertyExpression,
        string columnName,
        bool isRequired = true)
            where TEntity : DomainEntity
    {
        return builder
            .BuildPropertyDefault(propertyExpression, columnName, isRequired)
            .HasColumnType("smallmoney");
    }

    internal static PropertyBuilder<string> BuildPropertyWithMaxLength<TEntity>(
        this EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, string>> propertyExpression,
        string columnName,
        int maxLength,
        bool isRequired = true)
            where TEntity : DomainEntity
    {
        return builder
            .BuildPropertyDefault(propertyExpression, columnName, isRequired)
            .HasMaxLength(maxLength);
    }

    internal static PropertyBuilder<int> BuildPropertyAsInt<TEntity>(
        this EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, int>> propertyExpression,
        string columnName,
        bool isRequired = true)
            where TEntity : DomainEntity
    {
        return builder
            .BuildPropertyDefault(propertyExpression, columnName, isRequired)
            .HasColumnType("int");
    }

    internal static PropertyBuilder<int> BuildPropertyAsSmallInt<TEntity>(
        this EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, int>> propertyExpression,
        string columnName,
        bool isRequired = true)
            where TEntity : DomainEntity
    {
        return builder
            .BuildPropertyDefault(propertyExpression, columnName, isRequired)
            .HasColumnType("smallint");
    }

    internal static PropertyBuilder<int> BuildPropertyAsTinyInt<TEntity>(
        this EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, int>> propertyExpression,
        string columnName,
        bool isRequired = true)
            where TEntity : DomainEntity
    {
        return builder
            .BuildPropertyDefault(propertyExpression, columnName, isRequired)
            .HasColumnType("tinyint");
    }

    internal static PropertyBuilder<DateOnly?> BuildPropertyAsDate<TEntity>(
        this EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, DateOnly?>> propertyExpression,
        string columnName,
        bool isRequired = true)
            where TEntity : DomainEntity
    {
        return builder
            .BuildPropertyDefault(propertyExpression, columnName, isRequired)
            .HasColumnType("date");
    }

    internal static PropertyBuilder<DateTime> BuildPropertyAsDateTime<TEntity>(
        this EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, DateTime>> propertyExpression,
        string columnName,
        bool isRequired = true)
            where TEntity : DomainEntity
    {
        return builder
            .BuildPropertyDefault(propertyExpression, columnName, isRequired)
            .HasColumnType("datetime");
    }

    private static PropertyBuilder<TType> BuildPropertyDefault<TEntity, TType>(
        this EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, TType>> propertyExpression,
        string columnName,
        bool isRequired)
            where TEntity : DomainEntity
    {
        return builder
            .Property(propertyExpression)
            .HasColumnName(columnName)
            .IsRequired(isRequired);
    }

    private static class ColumnTypes
    {
        internal const string Id = $"bigint";
    }
}
