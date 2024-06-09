using AsyncAwaitBestPractices.MVVM;
using EdgeItalianPizza.Application.DTOs.Products;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Abstractions.Interfaces;
using EdgeItalianPizza.UI.MVVM.Model.Products;
using System.Collections.ObjectModel;

namespace EdgeItalianPizza.UI.MVVM.ViewModel;

internal sealed class DrinksViewModel(IDrinkService service) : ViewModelBase, INotifySelected<long>
{
    /// <summary>
    /// Срабатывает при выборе напитка.
    /// </summary>
    public event Action<long> OnSelected;

    private ObservableCollection<DrinkModel> _models = [];
    /// <summary>
    /// Модели напитков.
    /// </summary>
    public ObservableCollection<DrinkModel> Models
    {
        get => _models;
        set
        {
            _models = value;
            OnPropertyChanged(nameof(Models));
        }
    }

    /// <summary>
    /// Асинхронная загрузка.
    /// </summary>
    public IAsyncCommand LoadAsyncCommand { get; private set; }

    protected override void InitializeComponents()
    {
        LoadAsyncCommand = new AsyncCommand(LoadAsyncCommandExecute);
    }

    private async Task LoadAsyncCommandExecute()
    {
        if (Models.Any())
            return;

        var response = await Task.Run(service.GetAllAsync);

        var models = HandleResponse(response);

        Models = new(models);
    }

    private IEnumerable<DrinkModel> HandleResponse(IEnumerable<ProductResponse> response)
    {
        foreach (var item in response)
        {
            var model = new DrinkModel
            {
                Id = item.Id,
                PhotoUri = item.PhotoUri,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price
            };

            model.OnSelected += Drink_OnSelected;

            yield return model;
        }
    }

    private void Drink_OnSelected(long id)
    {
        OnSelected?.Invoke(id);
    }
}
