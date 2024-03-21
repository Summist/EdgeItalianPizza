using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.WPF.Client.MVVM.Model;
using EdgeItalianPizza.WPF.Client.MVVM.View;
using EdgeItalianPizza.WPF.Client.Utilities;
using System.Windows.Controls;
using System.Windows.Input;

namespace EdgeItalianPizza.WPF.Client.MVVM.ViewModel;

public sealed class NavigationViewModel : ViewModelBase
{
    public UserModel? UserModel { get; set; } = null!;

    private UserControl _currentView;

    public UserControl CurrentView
    {
        get { return _currentView; }
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public ICommand PizzasCommand { get; set; }
    public ICommand ComboCommand { get; set; }
    public ICommand PersonalCabinetCommand { get; set; }
    public ICommand BasketCommand { get; set; }

    public NavigationViewModel(ILoggerService logger)
        : base (logger)
    {
        PizzasCommand = new RelayCommand(Pizza);
        ComboCommand = new RelayCommand(Combo);
        PersonalCabinetCommand = new RelayCommand(PersonalCabinet);
        BasketCommand = new RelayCommand(Basket);

        _currentView = new Pizzas(logger);
    }

    private void Pizza(object obj) => CurrentView = new Pizzas(_logger);
    private void Combo(object obj) => CurrentView = new Combo(_logger);
    private void PersonalCabinet(object obj)
    {
        if (UserModel is null)
        {
            CurrentView = new Authorization(_logger, this);
        }
        else
        {
            CurrentView = new PersonalCabinet(_logger);
        }
    }
    private void Basket(object obj) => CurrentView = new Basket(_logger);
}
