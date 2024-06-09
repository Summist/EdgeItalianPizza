using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Abstractions.Interfaces;
using EdgeItalianPizza.UI.Share.Info;
using EdgeItalianPizza.UI.Share.Utilities;
using System.Windows.Input;

namespace EdgeItalianPizza.UI.MVVM.ViewModel;

internal sealed class MainViewModel(INavigationService navigation) : ViewModelBase
{
    private INavigationService _navigation = navigation;
    /// <summary>
    /// Сервис навигации между View.
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

    private bool _isMenuSelect = false;
    /// <summary>
    /// Выбрана ли страница меню.
    /// </summary>
    public bool IsMenuSelect
    {
        get => _isMenuSelect;
        set
        {
            _isMenuSelect = value;
            OnPropertyChanged(nameof(IsMenuSelect));
        }
    }

    private bool _isPersonalCabinetSelect = false;
    /// <summary>
    /// Выбрана ли страница личного кабинета.
    /// </summary>
    public bool IsPersonalCabinetSelect
    {
        get => _isPersonalCabinetSelect;
        set
        {
            _isPersonalCabinetSelect = value;
            OnPropertyChanged(nameof(IsPersonalCabinetSelect));
        }
    }

    private bool _isBasketSelect = false;
    /// <summary>
    /// Выбрана ли страница с корзиной.
    /// </summary>
    public bool IsBasketSelect
    {
        get => _isBasketSelect; set
        {
            _isBasketSelect = value;
            OnPropertyChanged(nameof(IsBasketSelect));
        }
    }

    /// <summary>
    /// Команда для перенаправления в меню.
    /// </summary>
    public ICommand NavigateToMenuCommand { get; private set; }
    /// <summary>
    /// Команда для перенаправления в личный кабинет.
    /// </summary>
    public ICommand NavigateToPersonalCabinetCommand { get; private set; }
    /// <summary>
    /// Команда для перенаплавления в корзину.
    /// </summary>
    public ICommand NavigateToBasketCommand { get; private set; }

    protected override void InitializeComponents()
    {
        RestaurantInfo.OnInfoChanged += RestaurantInfo_OnInfoChanged;
        CodeViewModel.OnNextButtonClicked += OnNextButtonClicked;

        SetStartView();

        NavigateToMenuCommand = new RelayCommand(NavigateToMenuCommandExecute);
        NavigateToPersonalCabinetCommand = new RelayCommand(NavigateToPersonalCabinetCommandExecute);
        NavigateToBasketCommand = new RelayCommand(NavigateToBasketCommandExecute);
    }

    private void OnNextButtonClicked()
    {
        IsMenuSelect = TryNavigationTo<MenuViewModel>();
    }

    private void SetStartView() => Navigation.NavigateTo<RestaurantAttachViewModel>();

    private void RestaurantInfo_OnInfoChanged()
    {
        IsMenuSelect = TryNavigationTo<MenuViewModel>();
    }

    private void NavigateToMenuCommandExecute(object obj)
    {
        IsMenuSelect = TryNavigationTo<MenuViewModel>();
    }

    private void NavigateToPersonalCabinetCommandExecute(object obj)
    {
        IsPersonalCabinetSelect = TryNavigationTo<CustomerViewModel>();
    }

    private void NavigateToBasketCommandExecute(object obj)
    {
        IsBasketSelect = TryNavigationTo<OrderViewModel>();
    }

    private bool TryNavigationTo<TViewModel>() where TViewModel : ViewModelBase
    {
        if (RestaurantInfo.IsAuthorized)
        {
            Navigation.NavigateTo<TViewModel>();
            return true;
        }

        return false;
    }
}
