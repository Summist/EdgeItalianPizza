using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.WPF.Client.MVVM.ViewModel;
using System.Windows.Controls;

namespace EdgeItalianPizza.WPF.Client.MVVM.View;

/// <summary>
/// Логика взаимодействия для Pizzas.xaml
/// </summary>
public partial class Pizzas : UserControl
{
    public Pizzas(ILoggerService logger)
    {
        InitializeComponent();

        DataContext = new PizzasViewModel(logger);
    }
}
