using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Abstractions.Interfaces;
using EdgeItalianPizza.UI.Share.Enums;
using EdgeItalianPizza.UI.Share.Info;
using EdgeItalianPizza.UI.Share.Informations;
using EdgeItalianPizza.UI.Share.Utilities;
using System.Windows.Input;

namespace EdgeItalianPizza.UI.MVVM.ViewModel;

internal sealed class MenuViewModel(
    INavigationService navigation,
    INotifySelected<string> pizzasViewModel,
    INotifySelected<long> drinksViewModel) : ViewModelBase
{
    private INavigationService _navigation = navigation;
    /// <summary>
    /// Сервис для навигации между View.
    /// </summary>
    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged(nameof(Navigation));
        }
    }

    private bool _isPizzasSelect = false;
    /// <summary>
    /// Выбрана ли категория с пиццами.
    /// </summary>
    public bool IsPizzasSelect
    {
        get => _isPizzasSelect;
        set
        {
            _isPizzasSelect = value;
            OnPropertyChanged(nameof(IsPizzasSelect));
        }
    }

    private bool _isDrinksSelect = false;
    /// <summary>
    /// Выбрана ли категория с напитками.
    /// </summary>
    public bool IsDrinksSelect
    {
        get => _isDrinksSelect;
        set
        {
            _isDrinksSelect = value;
            OnPropertyChanged(nameof(IsDrinksSelect));
        }
    }

    /// <summary>
    /// Команда при загрузке.
    /// </summary>
    public ICommand LoadCommand { get; private set; }
    /// <summary>
    /// Команда для перенаправления на View с пиццами.
    /// </summary>
    public ICommand NavigateToPizzasCommand { get; private set; }
    /// <summary>
    /// Команда для перенаправления на View с напитками.
    /// </summary>
    public ICommand NavigateToDrinksCommand { get; private set; }

    protected override void InitializeComponents()
    {
        pizzasViewModel.OnSelected += Pizza_OnSelected;
        drinksViewModel.OnSelected += Drink_OnSelected;
        OrderInfo.OnProductAdded += OrderInfo_OnAdded;

        DrinkCardViewModel.OnThrowException += OnThrowException;
        PizzaCardViewModel.OnThrowException += OnThrowException;
        PizzasViewModel.OnThrowException += OnThrowException;

        SetStartView();

        LoadCommand = new RelayCommand(LoadCommandExecute);
        NavigateToPizzasCommand = new RelayCommand(NavigateToPizzasCommandExecute);
        NavigateToDrinksCommand = new RelayCommand(NavigateToDrinksCommandExecute);
    }

    private void OnThrowException()
    {
        Navigation.NavigateTo<ErrorViewModel>();
    }

    private void OrderInfo_OnAdded(ProductType type)
    {
        if (type is ProductType.Pizza)
            NavigateToPizzasCommandExecute(null);

        if (type is ProductType.Drink)
            NavigateToDrinksCommandExecute(null);
    }

    private void SetStartView()
    {
        Navigation.NavigateTo<PizzasViewModel>();
        IsPizzasSelect = true;
    }

    private void LoadCommandExecute(object obj)
    {
        Navigation.NavigateTo<PizzasViewModel>();
        IsPizzasSelect = true;
    }

    private void NavigateToPizzasCommandExecute(object obj)
    {
        Navigation.NavigateTo<PizzasViewModel>();
        IsPizzasSelect = true;
    }

    private void NavigateToDrinksCommandExecute(object obj)
    {
        Navigation.NavigateTo<DrinksViewModel>();
        IsDrinksSelect = true;
    }

    private void Pizza_OnSelected(string name)
    {
        SelectedPizzaInfo.Name = name;
        Navigation.NavigateTo<PizzaCardViewModel>();
        IsPizzasSelect = false;
        IsDrinksSelect = false;
    }

    private void Drink_OnSelected(long id)
    {
        SelectedDrinkInfo.Id = id;
        Navigation.NavigateTo<DrinkCardViewModel>();
        IsPizzasSelect = false;
        IsDrinksSelect = false;
    }
}
