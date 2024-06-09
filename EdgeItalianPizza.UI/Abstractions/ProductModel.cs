using EdgeItalianPizza.UI.Share.Values;

namespace EdgeItalianPizza.UI.Abstractions;

internal abstract class ProductModel(NutritionalValue nutritionalValue) : ObservableObject
{
    private long _id;
    /// <summary>
    /// Идентификационный номер.
    /// </summary>
    public long Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    private string _photoUri;
    /// <summary>
    /// Ссылка на изображение.
    /// </summary>
    public string PhotoUri
    {
        get => _photoUri;
        set
        {
            _photoUri = value;
            OnPropertyChanged(nameof(PhotoUri));
        }
    }

    private string _name;
    /// <summary>
    /// Название.
    /// </summary>
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    private string _description;
    /// <summary>
    /// Описание.
    /// </summary>
    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChanged(nameof(Description));
        }
    }

    private decimal _price;
    /// <summary>
    /// Стоимость.
    /// </summary>
    public decimal Price
    {
        get => Math.Round(_price, 2);
        set
        {
            _price = value;
            OnPropertyChanged(nameof(Price));
        }
    }

    /// <summary>
    /// Энергетическая ценность пиццы.
    /// </summary>
    public NutritionalValue NutritionalValue { get; init; } = nutritionalValue;
}
