using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.WPF.Client.MVVM.ViewModel;
using System.Windows.Controls;

namespace EdgeItalianPizza.WPF.Client.MVVM.View;

/// <summary>
/// Логика взаимодействия для Basket.xaml
/// </summary>
public partial class Basket : UserControl
{
    public Basket(ILoggerService logger)
    {
        InitializeComponent();

        DataContext = new BasketViewModel(logger);
    }
}
