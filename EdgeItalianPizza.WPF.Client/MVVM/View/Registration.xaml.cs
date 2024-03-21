using EdgeItalianPizza.Application.Interfaces;
using System.Windows.Controls;

namespace EdgeItalianPizza.WPF.Client.MVVM.View;

/// <summary>
/// Логика взаимодействия для Registration.xaml
/// </summary>
public partial class Registration : UserControl
{
    public Registration(ILoggerService logger)
    {
        InitializeComponent();
    }
}
