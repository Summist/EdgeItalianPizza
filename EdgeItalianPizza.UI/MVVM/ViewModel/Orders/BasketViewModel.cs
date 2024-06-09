using AsyncAwaitBestPractices.MVVM;
using EdgeItalianPizza.Application.DTOs.Orders;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Abstractions.Interfaces;
using EdgeItalianPizza.UI.MVVM.Model.Orders;
using EdgeItalianPizza.UI.Share.Enums;
using EdgeItalianPizza.UI.Share.Info;
using EdgeItalianPizza.UI.Share.Informations;
using EdgeItalianPizza.UI.Share.Utilities;
using EdgeItalianPizza.UI.Share.Values;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EdgeItalianPizza.UI.MVVM.ViewModel;

internal sealed class BasketViewModel(
    IBonusCoinsCalculator coinsCalculator,
    IPromoCodeService promoCodeService,
    IOrderService orderService,
    ICustomerService customerService) : ViewModelBase
{
    public static Action OnMakedOrder;

    private readonly PromoCode _promoCodeValue = new();

    private ObservableCollection<OrderItemModel> _products = [];
    /// <summary>
    /// Товары в корзине.
    /// </summary>
    public ObservableCollection<OrderItemModel> Products
    {
        get => _products;
        set
        {
            _products = value;
            OnPropertyChanged(nameof(Products));
        }
    }

    private string _productWord = string.Empty;
    /// <summary>
    /// Склонение слова "товар" в зависимости от количества товаров в корзине. 
    /// </summary>
    public string ProductWord
    {
        get => _productWord;
        set
        {
            _productWord = value;
            OnPropertyChanged(nameof(ProductWord));
        }
    }

    private string _totalPriceWord = "Сумма заказа";
    public string TotalPriceWord
    {
        get => _totalPriceWord;
        set
        {
            _totalPriceWord = value;
            OnPropertyChanged(nameof(TotalPriceWord));
        }
    }


    private int _productsAmount = 0;
    /// <summary>
    /// Кол-во товаров в корзине.
    /// </summary>
    public int ProductsAmount
    {
        get => _productsAmount;
        set
        {
            _productsAmount = value;
            ProductWord = GetQuantityString(value);
            OnPropertyChanged(nameof(ProductsAmount));
        }
    }

    private decimal _totalPrice = 0;
    /// <summary>
    /// Итоговая сумма заказа.
    /// </summary>
    public decimal TotalPrice
    {
        get => Math.Round(_totalPrice, 2);
        set
        {
            _totalPrice = value;

            if (IsBonusCoinsUse)
            {
                BonusCoins = 0;
            }
            else
            {
                BonusCoins = coinsCalculator.Calculate(value);
            }

            OnPropertyChanged(nameof(TotalPrice));
        }
    }

    private int _bonusCoins = 0;
    /// <summary>
    /// Количество бонусных монет.
    /// </summary>
    public int BonusCoins
    {
        get => _bonusCoins;
        set
        {
            _bonusCoins = value;
            OnPropertyChanged(nameof(BonusCoins));
        }
    }

    private string _promoCode = string.Empty;
    /// <summary>
    /// Введенный промокод.
    /// </summary>
    public string PromoCode
    {
        get => _promoCode;
        set
        {
            _promoCode = value;
            OnPropertyChanged(nameof(PromoCode));
        }
    }

    private string _promoCodeErrorMessage = string.Empty;
    /// <summary>
    /// Сообщение об ошибке при применении промокода.
    /// </summary>
    public string PromoCodeErrorMessage
    {
        get => _promoCodeErrorMessage;
        set
        {
            _promoCodeErrorMessage = value;
            OnPropertyChanged(nameof(PromoCodeErrorMessage));
        }
    }

    private bool _isBonusCoinsUse = false;
    /// <summary>
    /// Используются ли бонусные монеты пользователя.
    /// </summary>
    public bool IsBonusCoinsUse
    {
        get => _isBonusCoinsUse;
        set
        {
            if (!CustomerSessionInfo.IsAuth)
            {
                return;
            }

            _isBonusCoinsUse = value;

            if (value)
            {
                BonusCoins = 0;
            }
            else
            {
                BonusCoins = coinsCalculator.Calculate(TotalPrice);
            }

            CalculateTotalPrice();

            OnPropertyChanged(nameof(IsBonusCoinsUse));
        }
    }

    private bool _isBonusCoinsUseVisible = false;
    /// <summary>
    /// Можно ли использовать бонусные монеты.
    /// </summary>
    public bool IsBonusCoinsUseVisible
    {
        get => _isBonusCoinsUseVisible; 
        set 
        { 
            _isBonusCoinsUseVisible = value;
            OnPropertyChanged(nameof(IsBonusCoinsUseVisible));
        }
    }

    /// <summary>
    /// Команда, срабатывающая при загрузке.
    /// </summary>
    public ICommand LoadedCommand { get; private set; }
    /// <summary>
    /// Асинхронная команда для применения промокода.
    /// </summary>
    public IAsyncCommand UsePromoCodeAsyncCommand { get; private set; }
    /// <summary>
    /// Асинхронная команда для оформления заказа.
    /// </summary>
    public IAsyncCommand MakeAnOrderAsyncCommand { get; private set; }

    protected override void InitializeComponents()
    {
        LoadedCommand = new RelayCommand(LoadedCommandExecute);
        UsePromoCodeAsyncCommand = new AsyncCommand(UsePromoCodeAsyncCommandExecute);
        MakeAnOrderAsyncCommand = new AsyncCommand(MakeAnOrderAsyncCommandExecute);

        CustomerSessionInfo.OnInfoChanged += OnCustomerChangeInfo;
    }

    private void OnCustomerChangeInfo()
    {
        if (CustomerSessionInfo.IsAuth)
        {
            IsBonusCoinsUseVisible = true;
            CalculateTotalPrice();
        }
        else
        {
            PromoCode = string.Empty;
            PromoCodeErrorMessage = string.Empty;
            TotalPriceWord = "Сумма заказа";

            _promoCodeValue.Discount = 0;
            IsBonusCoinsUseVisible = false;
            IsBonusCoinsUse = false;
            _promoCodeValue.Id = -1;

            CalculateTotalPrice();
        }
    }

    private void LoadedCommandExecute(object obj)
    {
        IsBonusCoinsUseVisible = CustomerSessionInfo.IsAuth && _promoCodeValue.Id == -1;

        PromoCode = string.Empty;
        PromoCodeErrorMessage = string.Empty;
        _promoCodeValue.CalculateDiscountOnLoaded();

        CalculateTotalPrice();

        ProductsAmount = OrderInfo.Drinks.Count + OrderInfo.Pizzas.Count;

        var orderItems = GetOrderItems();

        Products = new(orderItems);
    }

    private async Task UsePromoCodeAsyncCommandExecute()
    {
        IsBonusCoinsUse = false;

        var dateTimeNow = DateTime.Now;

        if (string.IsNullOrWhiteSpace(PromoCode))
            return;

        if (!TryGetCustomerId(out long customerId))
        {
            PromoCodeErrorMessage = "Чтобы использовать промокод необходимо авторизоваться";
            return;
        }

        var request = new PromoCodeRequest(customerId, PromoCode, DateOnly.FromDateTime(dateTimeNow));

        var response = await Task.Run(() => promoCodeService.ApplyAsync(request));

        if (response.IsFailure)
        {
            PromoCodeErrorMessage = response.ErrorMessage;
            return;
        }

        _promoCodeValue.Id = response.Value.Id;
        _promoCodeValue.Code = new string(PromoCode);
        _promoCodeValue.Discount = response.Value.Discount;

        IsBonusCoinsUseVisible = false;

        CalculateTotalPrice();

        TotalPriceWord = "Сумма заказа со скидкой";
    }

    private static bool TryGetCustomerId(out long result)
    {
        result = CustomerSessionInfo.Customer?.Id ?? -1;

        return result != -1;
    }

    private async Task MakeAnOrderAsyncCommandExecute()
    {
        OrderRequest request = GetOrderRequest();

        var result = await orderService.MakeOrderAsync(request);

        if (result.IsFailure)
        {
            return;
        }

        if (CustomerSessionInfo.IsAuth && !IsBonusCoinsUse)
        {
            await customerService.AddBonusCoins(CustomerSessionInfo.Customer.Id, BonusCoins);
        }

        if (CustomerSessionInfo.IsAuth && IsBonusCoinsUse)
        {
            await customerService.RemoveBonusCoins(CustomerSessionInfo.Customer.Id);
        }

        OrderInfo.Code = result.Value;
        OnMakedOrder?.Invoke();

        _promoCodeValue.Id = -1;
        CustomerSessionInfo.Customer = null!;
        OrderInfo.Clear();
    }

    private OrderRequest GetOrderRequest()
    {
        var dateOfCreated = DateTime.Now;

        long customerId = CustomerSessionInfo.Customer?.Id ?? -1;
        int bonusCoins = IsBonusCoinsUse ? CustomerSessionInfo.Customer?.BonusCoins ?? 0 : 0;

        var orderDrinkDTOs = new List<OrderDrinkDTO>();

        foreach (var drink in OrderInfo.Drinks)
        {
            orderDrinkDTOs.Add(new(drink.Key.Id, drink.Value));
        }

        var orderPizzaDTOs = new List<OrderPizzaDTO>();

        foreach (var pizza in OrderInfo.Pizzas)
        {
            orderPizzaDTOs.Add(new(pizza.Key.Id, pizza.Key.ToppingIds, pizza.Value));
        }

        return new OrderRequest(
            RestaurantInfo.Info,
            orderDrinkDTOs,
            orderPizzaDTOs,
            dateOfCreated,
            bonusCoins,
            customerId,
            _promoCodeValue.Code);
    }

    private void CalculateTotalPrice()
    {
        TotalPrice = 0;

        foreach (var item in OrderInfo.Drinks)
        {
            TotalPrice += item.Key.Price * item.Value;
        }

        foreach (var item in OrderInfo.Pizzas)
        {
            TotalPrice += item.Key.Price * item.Value;
        }

        if (IsBonusCoinsUse)
        {
            TotalPrice -= CustomerSessionInfo.Customer?.BonusCoins ?? 0;
        }
        else
        {
            TotalPrice -= TotalPrice / 100 * _promoCodeValue.Discount;
        }
    }

    private IEnumerable<OrderItemModel> GetOrderItems()
    {
        foreach (var item in OrderInfo.Pizzas)
        {
            var orderItem = new OrderItemModel(ProductType.Pizza, item.Key)
            {
                Id = item.Key.Id,
                PhotoUri = item.Key.PhotoUri,
                Name = item.Key.Name,
                Description = item.Key.Description,
                Price = item.Key.Price * item.Value,
                Amount = item.Value
            };

            orderItem.OnItemChanged += OrderItem_OnItemChanged;

            yield return orderItem;
        }

        foreach (var item in OrderInfo.Drinks)
        {
            var orderItem = new OrderItemModel(ProductType.Drink, item.Key)
            {
                Id = item.Key.Id,
                PhotoUri = item.Key.PhotoUri,
                Name = item.Key.Name,
                Description = item.Key.Description,
                Price = item.Key.Price * item.Value,
                Amount = item.Value
            };

            orderItem.OnItemChanged += OrderItem_OnItemChanged;

            yield return orderItem;
        }
    }

    private void OrderItem_OnItemChanged()
    {
        LoadedCommandExecute(default);
    }

    private static string GetQuantityString(int quantity)
    {
        int remainder10 = quantity % 10;
        int remainder100 = quantity % 100;

        if (remainder10 == 1 && remainder100 != 11)
            return "товар";

        if (remainder10 >= 2 && remainder10 <= 4 &&
           (remainder100 < 10 || remainder100 >= 20))
            return "товара";

        return "товаров";
    }
}
