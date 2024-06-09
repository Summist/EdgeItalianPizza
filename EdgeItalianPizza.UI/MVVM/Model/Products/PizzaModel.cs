using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Abstractions.Interfaces;
using EdgeItalianPizza.UI.Share.Utilities;
using System.Windows.Input;

namespace EdgeItalianPizza.UI.MVVM.Model.Products;

internal sealed class PizzaModel : ObservableObject, INotifySelected<string>
{
    /// <summary>
    /// Событие срабатываемое при выборе пиццы.
    /// </summary>
    public event Action<string> OnSelected;

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
    /// Команда для выбора пиццы.
    /// </summary>
    public ICommand SelectCommand { get; private set; }

    /// <summary>
    /// Стандартный констуктор.
    /// </summary>
    public PizzaModel()
    {
        SelectCommand = new RelayCommand(SelectCommandExecute);
    }

    private void SelectCommandExecute(object obj)
    {
        OnSelected?.Invoke(Name);
    }
}
