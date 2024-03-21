using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.WPF.Client.MVVM.ViewModel;
using System.Windows.Controls;

namespace EdgeItalianPizza.WPF.Client.MVVM.View;

/// <summary>
/// Логика взаимодействия для PersonalCabinet.xaml
/// </summary>
public partial class PersonalCabinet : UserControl
{
    public PersonalCabinet(ILoggerService logger)
    {
        InitializeComponent();

        DataContext = new PersonalCabinetViewModel(logger);
    }
}
