using AsyncAwaitBestPractices.MVVM;
using EdgeItalianPizza.Application.DTOs.Products;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.MVVM.Model.Products;
using EdgeItalianPizza.UI.Share.Informations;
using EdgeItalianPizza.UI.Share.Utilities;
using EdgeItalianPizza.UI.Share.Values;
using System.Windows.Input;

namespace EdgeItalianPizza.UI.MVVM.ViewModel;

internal sealed class DrinkCardViewModel(IDrinkService service) : ViewModelBase
{
    /// <summary>
    /// Событие, срабатываемое при выбросе исключения.
    /// </summary>
    public static event Action OnThrowException;

    private SelectedDrinkModel _model;
    /// <summary>
    /// Выбранный напиток.
    /// </summary>
    public SelectedDrinkModel Model
    {
        get => _model;
        set
        {
            _model = value;
            OnPropertyChanged(nameof(Model));
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

    private bool _isKcalVisible;
    /// <summary>
    /// Видна ли информация о ккал.
    /// </summary>
    public bool IsKcalVisible
    {
        get => _isKcalVisible;
        set
        {
            _isKcalVisible = value;
            OnPropertyChanged(nameof(IsKcalVisible));
        }
    }

    private bool _isProteinsVisible;
    /// <summary>
    /// Видна ли информация о белках.
    /// </summary>
    public bool IsProteinsVisible
    {
        get => _isProteinsVisible;
        set
        {
            _isProteinsVisible = value;
            OnPropertyChanged(nameof(IsProteinsVisible));
        }
    }

    private bool _isFatsVisible;
    /// <summary>
    /// Видна ли информация о жирах.
    /// </summary>
    public bool IsFatsVisible
    {
        get => _isFatsVisible;
        set
        {
            _isFatsVisible = value;
            OnPropertyChanged(nameof(IsFatsVisible));
        }
    }

    private bool _IsCarbsVisible;
    /// <summary>
    /// Видна ли информация о углеводах.
    /// </summary>
    public bool IsCarbsVisible
    {
        get => _IsCarbsVisible;
        set
        {
            _IsCarbsVisible = value;
            OnPropertyChanged(nameof(IsCarbsVisible));
        }
    }

    /// <summary>
    /// Асинхронная команда при загрузке.
    /// </summary>
    public IAsyncCommand LoadAsyncCommand { get; private set; }

    /// <summary>
    /// Показывает характеристики пиццы.
    /// </summary>
    public ICommand ShowDetailsCommand { get; private set; }
    /// <summary>
    /// Команда добавления напитка в заказ.
    /// </summary>
    public ICommand SelectCommand { get; private set; }

    protected override void InitializeComponents()
    {
        LoadAsyncCommand = new AsyncCommand(LoadAsyncCommandExecute);
        ShowDetailsCommand = new RelayCommand(ShowDetailsCommandExecute);
        SelectCommand = new RelayCommand(SelectCommandExecute);
    }

    private async Task LoadAsyncCommandExecute()
    {
        try
        {
            long id = SelectedDrinkInfo.Id;

            var response = await Task.Run(() => service.GetByIdAsync(id));

            Model = GetModel(response);

            InitializeVisibilities();
        }
        catch
        {
            OnThrowException?.Invoke();
        }
    }

    private void ShowDetailsCommandExecute(object obj)
    {
        IsShowed = !IsShowed;
    }

    private void SelectCommandExecute(object obj)
    {
        OrderInfo.Add(Model);
    }

    private static SelectedDrinkModel GetModel(SelectedDrinkResponse response)
    {
        var nutritionalValue = new NutritionalValue(
            response.Kcal,
            response.Proteins,
            response.Fats,
            response.Carbs,
            response.Volume);

        return new SelectedDrinkModel(nutritionalValue)
        {
            Id = response.Id,
            PhotoUri = response.PhotoUri,
            Name = response.Name,
            Description = response.Description,
            Price = response.Price,
        };
    }

    private void InitializeVisibilities()
    {
        IsKcalVisible = Model.NutritionalValue.Kcal is not null;
        IsProteinsVisible = Model.NutritionalValue.Proteins is not null;
        IsFatsVisible = Model.NutritionalValue.Fats is not null;
        IsCarbsVisible = Model.NutritionalValue.Carbs is not null;
    }
}
