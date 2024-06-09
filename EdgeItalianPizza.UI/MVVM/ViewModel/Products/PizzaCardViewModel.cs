using AsyncAwaitBestPractices.MVVM;
using EdgeItalianPizza.Application.DTOs.Products;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.MVVM.Model.Products;
using EdgeItalianPizza.UI.Share.Values;
using EdgeItalianPizza.UI.Share.Enums;
using EdgeItalianPizza.UI.Share.Info;
using EdgeItalianPizza.UI.Share.Informations;
using EdgeItalianPizza.UI.Share.Mappers;
using EdgeItalianPizza.UI.Share.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Input;
using EdgeItalianPizza.UI.Share.Extensions;

namespace EdgeItalianPizza.UI.MVVM.ViewModel;

internal sealed class PizzaCardViewModel(IPizzaService service) : ViewModelBase
{
    private const PizzaSize StartSize = PizzaSize.Medium;

    public static event Action OnThrowException;

    private SelectedPizzaModel[] _models = [];

    private ObservableCollection<ToppingModel> _toppings = [];
    /// <summary>
    /// Добавки для пиццы.
    /// </summary>
    public ObservableCollection<ToppingModel> Toppings
    {
        get => _toppings;
        set
        {
            _toppings = value;
            OnPropertyChanged(nameof(Toppings));
        }
    }

    private SelectedPizzaModel _model;
    /// <summary>
    /// Пицца выбранного размера.
    /// </summary>
    public SelectedPizzaModel Model
    {
        get => _model;
        set
        {
            _model = value;
            OnPropertyChanged(nameof(Model));
        }
    }

    private int _imageSize;
    /// <summary>
    /// Размер для изображения пиццы.
    /// </summary>
    public int ImageSize
    {
        get => _imageSize;
        set
        {
            _imageSize = value;
            OnPropertyChanged(nameof(ImageSize));
        }
    }

    private bool _isSmallSelect = false;
    /// <summary>
    /// Выбран ли маленький размер пиццы.
    /// </summary>
    public bool IsSmallSelect
    {
        get => _isSmallSelect;
        set
        {
            _isSmallSelect = value;
            OnPropertyChanged(nameof(IsSmallSelect));
        }
    }

    private bool _isMediumSelect = false;
    /// <summary>
    /// Выбран ли средний размер пиццы.
    /// </summary>
    public bool IsMediumSelect
    {
        get => _isMediumSelect;
        set
        {
            _isMediumSelect = value;
            OnPropertyChanged(nameof(IsMediumSelect));
        }
    }

    private bool _isLargeSelect = false;
    /// <summary>
    /// Выбран ли большой размер пиццы.
    /// </summary>
    public bool IsLargeSelect
    {
        get => _isLargeSelect; set
        {
            _isLargeSelect = value;
            OnPropertyChanged(nameof(IsLargeSelect));
        }
    }

    private bool _isShowed = false;
    public bool IsShowed
    {
        get => _isShowed;
        set
        {
            _isShowed = value;
            OnPropertyChanged(nameof(IsShowed));
        }
    }

    /// <summary>
    /// Асинхронная команда при загрузке.
    /// </summary>
    public IAsyncCommand LoadAsyncCommand { get; private set; }

    /// <summary>
    /// Устанавливает пиццу маленького размера.
    /// </summary>
    public ICommand SetSmallSizeCommand { get; private set; }

    /// <summary>
    /// Устанавливает пиццу среднего размера.
    /// </summary>
    public ICommand SetMediumSizeCommand { get; private set; }

    /// <summary>
    /// Устанавливает пиццу большого размера.
    /// </summary>
    public ICommand SetLargeSizeCommand { get; private set; }

    /// <summary>
    /// Показывает характеристики пиццы.
    /// </summary>
    public ICommand ShowDetailsCommand { get; private set; }
    /// <summary>
    /// Команда добавления пиццы в заказ.
    /// </summary>
    public ICommand SelectCommand { get; private set; }

    protected override void InitializeComponents()
    {
        LoadAsyncCommand = new AsyncCommand(LoadAsyncCommandExecute);
        SetSmallSizeCommand = new RelayCommand(SetSmallSizeCommandExecute);
        SetMediumSizeCommand = new RelayCommand(SetMediumSizeCommandExecute);
        SetLargeSizeCommand = new RelayCommand(SetLargeSizeCommandExecute);
        ShowDetailsCommand = new RelayCommand(ShowDetailsCommandExecute);
        SelectCommand = new RelayCommand(SelectCommandExecute);
    }

    private async Task LoadAsyncCommandExecute()
    {
        try
        {
            var response = await service.GetByNameAsync(SelectedPizzaInfo.Name);

            HandleResponse(response);

            IsMediumSelect = true;
            SetPizzaSize(StartSize);
            SetToppingsSize(StartSize);
            IsShowed = false;
        }
        catch
        {
            OnThrowException?.Invoke();
        }
    }

    private void SetSmallSizeCommandExecute(object obj)
    {
        SetPizzaSize(PizzaSize.Small);
        SetToppingsSize(PizzaSize.Small);
        IsSmallSelect = true;
    }

    private void SetMediumSizeCommandExecute(object obj)
    {
        SetPizzaSize(PizzaSize.Medium);
        SetToppingsSize(PizzaSize.Medium);
        IsMediumSelect = true;
    }

    private void SetLargeSizeCommandExecute(object obj)
    {
        SetPizzaSize(PizzaSize.Large);
        SetToppingsSize(PizzaSize.Large);
        IsLargeSelect = true;
    }

    private void ShowDetailsCommandExecute(object obj)
    {
        IsShowed = !IsShowed;
    }

    private void SelectCommandExecute(object obj)
    {
        OrderInfo.Add(Model);
    }

    private void SetPizzaSize(PizzaSize size)
    {
        ImageSize = size.ToImageSize();
        Model = _models.First(model => model.Size == size);
    }

    private void HandleResponse(SelectedPizzaResponse response)
    {
        _models = GetModels(response.Pizzas).ToArray();

        var toppings = GetToppings(response.Toppings);

        Toppings = new(toppings);
    }

    private static IEnumerable<SelectedPizzaModel> GetModels(IEnumerable<PizzaResponse> pizzas)
    {
        foreach (var item in pizzas)
        {
            yield return GetModel(item);
        }
    }

    private static SelectedPizzaModel GetModel(PizzaResponse response)
    {
        PizzaSize size = response.SizeValue.ToPizzaSize();

        var nutritionalValue = new NutritionalValue(
            response.Kcal,
            response.Proteins,
            response.Fats,
            response.Carbs,
            response.Portion);

        return new SelectedPizzaModel(size, nutritionalValue)
        {
            Id = response.Id,
            PhotoUri = response.PhotoUri,
            Name = response.Name,
            Description = response.Description,
            Price = response.Price,
            SizeValue = response.SizeValue,
        };
    }

    private IEnumerable<ToppingModel> GetToppings(IEnumerable<ToppingResponse> toppings)
    {
        foreach (var item in toppings)
        {
            ToppingModel model = item.ToModel();

            model.OnSelected += Topping_OnSelected;

            yield return model;
        }
    }

    private void Topping_OnSelected(IReadOnlyDictionary<PizzaSize, ToppingDetails> details, bool isSelected)
    {
        for (var i = 0; i < _models.Length; i++)
        {
            var modelSize = _models[i].Size;

            if (isSelected)
            {
                _models[i].AddTopping(details[modelSize]);
            }
            else
            {
                _models[i].RemoveTopping(details[modelSize]);
            }
        }
    }

    private void SetToppingsSize(PizzaSize size)
    {
        foreach (var item in Toppings)
        {
            item.SetSize(size);
        }
    }
}
