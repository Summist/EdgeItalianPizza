using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Share.Enums;
using EdgeItalianPizza.UI.Share.Informations;
using EdgeItalianPizza.UI.Share.Utilities;
using System.Windows.Input;

namespace EdgeItalianPizza.UI.MVVM.Model.Orders;

/// <summary>
/// Модель товара в корзине.
/// </summary>
/// <param name="type"></param>
internal class OrderItemModel : ObservableObject
{
    private readonly ProductModel _product;

    public event Action OnItemChanged;

    private long _id;
    /// <summary>
    /// Идентификационный номер напитка.
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

    private int _amount = 0;
    /// <summary>
    /// Количество данного товара в заказе.
    /// </summary>
    public int Amount
    {
        get => _amount;
        set
        {
            _amount = value;
            OnPropertyChanged(nameof(Amount));
        }
    }

    /// <summary>
    /// Тип товара.
    /// </summary>
    public ProductType Type { get; init; }

    public ICommand DeleteProductCommand { get; private set; }
    public ICommand ReduceProductCommand { get; private set; }
    public ICommand AddProductCommand { get; private set; }

    public OrderItemModel(ProductType type, ProductModel product)
    {
        Type = type;
        _product = product;
        DeleteProductCommand = new RelayCommand(DeleteCommandExecute);
        ReduceProductCommand = new RelayCommand(ReduceProductCommandExecute);
        AddProductCommand = new RelayCommand(AddProductCommandExecute);
    }

    private void DeleteCommandExecute(object obj)
    {
        OrderInfo.Remove(_product);

        OnItemChanged?.Invoke();
    }

    private void ReduceProductCommandExecute(object obj)
    {
        OrderInfo.ReduceAmount(_product);

        OnItemChanged?.Invoke();
    }

    private void AddProductCommandExecute(object obj)
    {
        OrderInfo.Add(_product);

        OnItemChanged?.Invoke();
    }

}
