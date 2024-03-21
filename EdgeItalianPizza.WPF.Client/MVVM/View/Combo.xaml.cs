using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.WPF.Client.MVVM.ViewModel;
using System.Windows.Controls;

namespace EdgeItalianPizza.WPF.Client.MVVM.View;

/// <summary>
/// Логика взаимодействия для Combo.xaml
/// </summary>
public partial class Combo : UserControl
{
    public Combo(ILoggerService logger)
    {
        InitializeComponent();

        DataContext = new ComboViewModel(logger);
    }
}
