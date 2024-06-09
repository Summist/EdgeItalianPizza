using EdgeItalianPizza.Domain.Share.Common;

namespace EdgeItalianPizza.Domain.Entities.Orders.ValueObjects;

/// <summary>
/// Период времени.
/// </summary>
public sealed class DateRange : ValueObject
{
    /// <summary>
    /// Дата начала периода.
    /// </summary>
    public DateOnly DateStart { get; private set; }

    /// <summary>
    /// Дата окончания периода.
    /// </summary>
    public DateOnly DateEnd { get; private set; }

    /// <summary>
    /// Метод проверяющий входит ли дата в период.
    /// </summary>
    /// <param name="period">Диапазон времени.</param>
    /// <param name="date">Проверяемая дата.</param>
    /// <returns>
    /// Возвращает <see langword="true"/>, если дата входит в диапазон, в противном случае <see langword="false"/>.
    /// </returns>
    public static bool IsDateInRange(DateRange period, DateOnly date)
    {
        return date >= period.DateStart && date <= period.DateEnd;
    }

    protected override IEnumerable<object> GetEqualityObjects()
    {
        yield return DateStart; 
        yield return DateEnd;
    }
}
