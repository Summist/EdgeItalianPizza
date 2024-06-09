using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Share.Values;
using EdgeItalianPizza.UI.Share.Enums;

namespace EdgeItalianPizza.UI.MVVM.Model.Products;

internal sealed class SelectedPizzaModel(
    PizzaSize size,
    NutritionalValue nutritionalValue) : ProductModel(nutritionalValue)
{
    private List<ToppingDetails> _toppings = [];

    public IEnumerable<long> ToppingIds => _toppings.Select(x => x.Id);

    private int _sizeValue;
    /// <summary>
    /// Значение размера пиццы.
    /// </summary>
    public int SizeValue
    {
        get => _sizeValue;
        set
        {
            _sizeValue = value;
            OnPropertyChanged(nameof(SizeValue));
        }
    }

    /// <summary>
    /// Размер пиццы.
    /// </summary>
    public PizzaSize Size { get; init; } = size;

    public void AddTopping(ToppingDetails details)
    {
        _toppings.Add(details);
        Price += details.Price;
    }

    public void RemoveTopping(ToppingDetails details)
    {
        _toppings.Remove(details);
        Price -= details.Price;
    }

    public bool Equals(SelectedPizzaModel obj)
    {
        return obj is not null &&
               obj.Id == Id
               && _toppings.GetHashCode() == obj._toppings.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as SelectedPizzaModel);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, _toppings);
    }
}
