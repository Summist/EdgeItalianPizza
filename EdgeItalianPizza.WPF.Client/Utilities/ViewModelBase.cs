using EdgeItalianPizza.Application.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EdgeItalianPizza.WPF.Client.Utilities;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    protected readonly ILoggerService _logger;

    public event PropertyChangedEventHandler PropertyChanged;

    public ViewModelBase(ILoggerService logger)
    {
        _logger = logger;
    }

    public void OnPropertyChanged([CallerMemberName] string propName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
