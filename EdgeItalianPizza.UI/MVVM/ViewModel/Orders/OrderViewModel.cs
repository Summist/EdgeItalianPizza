using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Abstractions.Interfaces;
using EdgeItalianPizza.UI.Share.Informations;
using EdgeItalianPizza.UI.Share.Utilities;
using System.Windows.Input;

namespace EdgeItalianPizza.UI.MVVM.ViewModel;

internal sealed class OrderViewModel(INavigationService navigation) : ViewModelBase
{
    private INavigationService _navigation = navigation;
    /// <summary>
    /// Навигация между View.
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

    /// <summary>
    /// Команда срабатывающая при загрузке.
    /// </summary>
    public ICommand LoadedCommand { get; private set; }

    protected override void InitializeComponents()
    {
        OrderInfo.OnAllProductRemoved += OrderInfo_OnAllProductRemoved;
        BasketViewModel.OnMakedOrder += OnMakedOrder;

        LoadedCommand = new RelayCommand(LoadedCommandExecute);
    }

    private void OnMakedOrder()
    {
        Navigation.NavigateTo<CodeViewModel>();
    }

    private void OrderInfo_OnAllProductRemoved()
    {
        Navigation.NavigateTo<EmptyViewModel>();
    }

    private void LoadedCommandExecute(object obj)
    {
        if (!OrderInfo.Drinks.Any() && !OrderInfo.Pizzas.Any())
        {
            Navigation.NavigateTo<EmptyViewModel>();
            return;
        }

        Navigation.NavigateTo<BasketViewModel>();
    }
}
