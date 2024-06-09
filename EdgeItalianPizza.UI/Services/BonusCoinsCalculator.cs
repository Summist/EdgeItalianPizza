using EdgeItalianPizza.UI.Abstractions.Interfaces;

namespace EdgeItalianPizza.UI.Services;

internal sealed class BonusCoinsCalculator : IBonusCoinsCalculator
{
    public int Calculate(decimal totalPrice)
    {
        decimal result = totalPrice - totalPrice / 100 * 95;

        return (int)Math.Round(result, 0);
    }
}
