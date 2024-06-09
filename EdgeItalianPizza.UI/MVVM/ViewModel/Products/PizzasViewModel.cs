using AsyncAwaitBestPractices.MVVM;
using EdgeItalianPizza.Application.DTOs.Products;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Abstractions.Interfaces;
using EdgeItalianPizza.UI.MVVM.Model.Products;
using System.Collections.ObjectModel;

namespace EdgeItalianPizza.UI.MVVM.ViewModel;

internal sealed class PizzasViewModel(IPizzaService service) : ViewModelBase, INotifySelected<string>
{
    public static event Action OnThrowException;

    /// <summary>
    /// Событие срабатываемое при выборе пиццы.
    /// </summary>
    public event Action<string> OnSelected;

    private ObservableCollection<PizzaModel> _models = [];
    /// <summary>
    /// Коллекция, содержащая модели пиццы для вывода их на экран.
    /// </summary>
    public ObservableCollection<PizzaModel> Models
    {
        get => _models;
        set
        {
            _models = value;
            OnPropertyChanged(nameof(Models));
        }
    }

    /// <summary>
    /// Асинхронная команда загрузки View.
    /// </summary>
    public IAsyncCommand LoadAsyncCommand { get; private set; }

    protected override void InitializeComponents()
    {
        LoadAsyncCommand = new AsyncCommand(LoadAsyncCommandExecute);
    }

    private async Task LoadAsyncCommandExecute()
    {
        try
        {
            if (Models.Any())
                return;

            IEnumerable<ProductResponse> response = await Task.Run(service.GetAllAsync);

            IEnumerable<PizzaModel> models = HandleResponse(response);

            Models = new(models);
        }
        catch
        {
            OnThrowException?.Invoke();
        }
    }

    private IEnumerable<PizzaModel> HandleResponse(IEnumerable<ProductResponse> response)
    {
        foreach (var item in response)
        {
            var model = new PizzaModel
            {
                PhotoUri = item.PhotoUri,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price
            };

            model.OnSelected += Pizza_OnSelected;

            yield return model;
        }
    }

    private void Pizza_OnSelected(string pizzaName) => OnSelected?.Invoke(pizzaName);
}
