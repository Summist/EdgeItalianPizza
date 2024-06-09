using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.MVVM.Model.Products;
using EdgeItalianPizza.UI.Share.Enums;

namespace EdgeItalianPizza.UI.Share.Informations;

internal static class OrderInfo
{
    public static string Code { get; set; }

    /// <summary>
    /// Событие, срабатываемое при добавлении в корзину.
    /// </summary>
    public static event Action<ProductType> OnProductAdded;

    /// <summary>
    /// Событие, срабатываемое при удалении всех элементов из корзины.
    /// </summary>
    public static event Action OnAllProductRemoved;

    private static readonly Dictionary<SelectedDrinkModel, int> _drinks = [];
    private static readonly Dictionary<SelectedPizzaModel, int> _pizzas = [];

    /// <summary>
    /// Информация о напитках и их количестве.
    /// </summary>
    public static IReadOnlyDictionary<SelectedDrinkModel, int> Drinks => _drinks.AsReadOnly();
    /// <summary>
    /// Информация о пиццах и их количестве.
    /// </summary>
    public static IReadOnlyDictionary<SelectedPizzaModel, int> Pizzas => _pizzas.AsReadOnly();

    /// <summary>
    /// Метод добавления пиццы в корзину.
    /// </summary>
    /// <param name="model">Модель выбранной пиццы.</param>
    public static void Add(ProductModel model)
    {
        if (model is SelectedDrinkModel drink)
            Add(_drinks, drink, ProductType.Drink);

        if (model is SelectedPizzaModel pizza)
            Add(_pizzas, pizza, ProductType.Pizza);
    }

    /// <summary>
    /// Метод добавления напитка в корзину.
    /// </summary>
    /// <param name="model">Модель выбранного напитка.</param>
    public static void Add(SelectedDrinkModel model)
    {
        Add(_drinks, model, ProductType.Drink);
    }

    private static void Add<TModel>(Dictionary<TModel, int> dictionary, TModel model, ProductType type)
    {
        if (model is null)
            return;

        if (dictionary.ContainsKey(model))
        {
            dictionary[model]++;
        }
        else
        {
            dictionary.Add(model, 1);
        }

        OnProductAdded?.Invoke(type);
    }

    /// <summary>
    /// Метод удаления пицц схожего типа из корзины.
    /// </summary>
    /// <param name="model">Модель выбранной пиццы.</param>
    public static void Remove(ProductModel model)
    {
        if (model is null)
            return;

        if (model is SelectedDrinkModel drink)
            _drinks.Remove(drink);

        if (model is SelectedPizzaModel pizza)
            _pizzas.Remove(pizza);

        if (!_pizzas.Any() && !_drinks.Any())
            OnAllProductRemoved?.Invoke();
    }

    /// <summary>
    /// Уменьшить количество товара в корзине.
    /// </summary>
    /// <param name="model">Модель выбранного товара.</param>
    public static void ReduceAmount(ProductModel model)
    {
        if (model is null)
            return;

        if (model is SelectedDrinkModel drink)
            ReduceAmount(_drinks, drink);

        if (model is SelectedPizzaModel pizza)
            ReduceAmount(_pizzas, pizza);
    }

    /// <summary>
    /// Уменьшить количество товара в корзине.
    /// </summary>
    /// <param name="model">Модель  выбранного товара.</param>
    private static void ReduceAmount<TModel>(Dictionary<TModel, int> dictionary, TModel model) where TModel : ProductModel
    {
        int currentAmount = --dictionary[model];

        if (currentAmount <= 0)
        {
            Remove(model);
        }
    }

    public static void Clear()
    {
        _drinks.Clear();
        _pizzas.Clear();
    }
}
