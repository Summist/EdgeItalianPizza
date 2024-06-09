namespace EdgeItalianPizza.UI.Abstractions.Interfaces;

internal interface IBonusCoinsCalculator
{
    int Calculate(decimal totalPrice);
}
