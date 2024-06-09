using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Abstractions.Interfaces;
using EdgeItalianPizza.UI.Share.Utilities;
using System.Windows.Input;

namespace EdgeItalianPizza.UI.MVVM.Model.Products;

internal sealed class DrinkModel : ObservableObject, INotifySelected<long>
{
    /// <summary>
    /// Событие срабатываемое при выборе пиццы.
    /// </summary>
    public event Action<long> OnSelected;

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

    /// <summary>
    /// Команда для выбора товара.
    /// </summary>
    public ICommand SelectCommand { get; private set; }

    public DrinkModel()
    {
        SelectCommand = new RelayCommand(SelectCommandExecute);
    }

    private void SelectCommandExecute(object obj)
    {
        OnSelected?.Invoke(Id);
    }
}
