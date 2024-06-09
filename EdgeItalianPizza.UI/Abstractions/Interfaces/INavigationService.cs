namespace EdgeItalianPizza.UI.Abstractions.Interfaces;

internal interface INavigationService
{
    ViewModelBase CurrentView { get; }
    void NavigateTo<T>() where T : ViewModelBase;
}
