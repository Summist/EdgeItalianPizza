namespace EdgeItalianPizza.UI.Abstractions;

internal abstract class ViewModelBase : ObservableObject
{
    public ViewModelBase() => InitializeComponents();

    /// <summary>
    /// Инициализация конпонентов.
    /// </summary>
    protected virtual void InitializeComponents() { }
}