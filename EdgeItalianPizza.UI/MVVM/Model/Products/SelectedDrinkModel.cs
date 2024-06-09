using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Share.Values;

namespace EdgeItalianPizza.UI.MVVM.Model.Products;

internal sealed class SelectedDrinkModel(NutritionalValue nutritionalValue) : ProductModel(nutritionalValue)
{
    public bool Equals(SelectedDrinkModel obj)
    {
        return obj is not null && obj.Id == Id;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as SelectedDrinkModel);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
