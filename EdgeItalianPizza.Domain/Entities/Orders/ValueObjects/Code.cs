using EdgeItalianPizza.Domain.Share.Common;
using EdgeItalianPizza.Share.ResultPattern;

namespace EdgeItalianPizza.Domain.Entities.Orders.ValueObjects;

/// <summary>
/// Класс представляющих уникальный код заказа.
/// </summary>
public sealed class Code : ValueObject
{
    /// <summary>
    /// Максимально допустимая длина кода.
    /// </summary>
    public const int MaxLength = 100;

    /// <summary>
    /// Значение кода.
    /// </summary>
    public string Value { get; private set; }

    private Code() { }

    private Code(string value)
    {
        Value = value;
    }

    public static Result<Code> Create(DateTime dateOfCreated, IEnumerable<OrderPizza> orderPizzas, IEnumerable<OrderDrink> orderDrinks)
    {
        if (!orderPizzas.Any() && !orderDrinks.Any())
        {
            return "";
        }

        string code = $"{orderPizzas.Count() + orderDrinks.Count()}{dateOfCreated.Second}{dateOfCreated.Microsecond}";

        return new Code(code);
    }

    protected override IEnumerable<object> GetEqualityObjects()
    {
        yield return Value;
    }
}
