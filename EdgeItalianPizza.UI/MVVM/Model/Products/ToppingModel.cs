using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Share.Values;
using EdgeItalianPizza.UI.Share.Enums;
using EdgeItalianPizza.UI.Share.Utilities;
using System.Windows.Input;

namespace EdgeItalianPizza.UI.MVVM.Model.Products;

internal sealed class ToppingModel : ObservableObject
{
    private readonly Dictionary<PizzaSize, ToppingDetails> _details;

    /// <summary>
    /// Событие срабатываемое при выборе пиццы.
    /// </summary>
    public event Action<IReadOnlyDictionary<PizzaSize, ToppingDetails>, bool> OnSelected;

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

    private bool _isSelected = false;
    /// <summary>
    /// Выбрана ли добавка.
    /// </summary>
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            OnPropertyChanged(nameof(IsSelected));
        }
    }

    /// <summary>
    /// Команда при выборе добавки.
    /// </summary>
    public ICommand SelectCommand { get; private set; }

    public ToppingModel(Dictionary<PizzaSize, ToppingDetails> details)
    {
        _details = details;

        SelectCommand = new RelayCommand(SelectCommandExecute);
    }

    /// <summary>
    /// Устанавливает размер для добавки.
    /// </summary>
    /// <param name="size">Размер.</param>
    public void SetSize(PizzaSize size)
    {
        if (size is PizzaSize.None)
            return;

        var details = _details[size];

        Id = details.Id;
        Price = details.Price;
    }

    private void SelectCommandExecute(object obj)
    {
        OnSelected?.Invoke(_details, IsSelected);
    }
}
