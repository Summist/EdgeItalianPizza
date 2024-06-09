using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Abstractions.Interfaces;

namespace EdgeItalianPizza.UI.Services;

internal sealed class NavigationService(Func<Type, ViewModelBase> viewModelFactory) : ObservableObject, INavigationService
{
    private ViewModelBase _currentView;
    public ViewModelBase CurrentView
    {
        get => _currentView;
        set
        {
            _currentView = value;
            OnPropertyChanged(nameof(CurrentView));
        }
    }

    public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
    {
        ViewModelBase viewModel = viewModelFactory?.Invoke(typeof(TViewModel));
        CurrentView = viewModel;
    }
}
