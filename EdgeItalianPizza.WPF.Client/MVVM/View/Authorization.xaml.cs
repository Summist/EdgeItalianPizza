using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.WPF.Client.MVVM.ViewModel;
using System.Windows.Controls;

namespace EdgeItalianPizza.WPF.Client.MVVM.View;

/// <summary>
/// Логика взаимодействия для Authorization.xaml
/// </summary>
public partial class Authorization : UserControl
{
    public Authorization(ILoggerService logger, NavigationViewModel navigationVM)
    {
        InitializeComponent();

        DataContext = new AuthorizationViewModel(logger, navigationVM);
    }
}
