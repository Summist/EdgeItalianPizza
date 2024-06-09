namespace EdgeItalianPizza.UI.Abstractions.Interfaces;

internal interface INotifySelected<TOut>
{
    /// <summary>
    /// Событие срабатываемое при выборе.
    /// </summary>
    event Action<TOut> OnSelected;
}
