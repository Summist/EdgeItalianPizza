using EdgeItalianPizza.Application.DTOs.Orders;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Domain.Entities.Customers;
using EdgeItalianPizza.Domain.Entities.Customers.Interfaces;
using EdgeItalianPizza.Domain.Entities.Orders;
using EdgeItalianPizza.Domain.Entities.Orders.Interfaces;
using EdgeItalianPizza.Domain.Entities.Orders.ValueObjects;
using EdgeItalianPizza.Domain.Entities.Products;
using EdgeItalianPizza.Domain.Entities.Products.Interfaces;
using EdgeItalianPizza.Domain.Entities.Restaurants;
using EdgeItalianPizza.Domain.Entities.Restaurants.Interfaces;
using EdgeItalianPizza.Share.ResultPattern;

namespace EdgeItalianPizza.Application.Services;

public sealed class OrderService(
    IRestaurantRepository restaurantRepository,
    IPromoCodeRepository promoCodeRepository,
    ICustomerRepository customerRepository,
    IStatusRepository statusRepository,
    IOrderRepository orderRepository,
    IDrinkRepository drinkRepository,
    IPizzaRepository pizzaRepository,
    IToppingDetailsRepository toppingDetailsRepository,
    IOrderDrinkRepository orderDrinkRepository,
    IOrderPizzaRepository orderPizzaRepository) : IOrderService
{
    public async Task<Result<string>> MakeOrderAsync(OrderRequest request)
    {
        var failureMessage = Result<string>.Failure("Произошла ошибка при оформлении заказа");

        try
        {
            if (!request.Drinks.Any() && !request.Pizzas.Any())
            {
                return failureMessage;
            }

            Restaurant? restaurant = await restaurantRepository.GetAsync(request.RestaurantId);

            if (!TryGetCustomerWithPromoCode(request, out Customer customer, out PromoCode promoCode))
            {
                return failureMessage;
            }

            Status status = statusRepository.GetStatusToNewOrder();

            Result<Order> order = Order.Create(restaurant, customer, promoCode, request.DateOfCreated, request.BonusCoins, status);

            if (order.IsFailure)
            {
                return failureMessage;
            }

            IEnumerable<OrderDrink> orderDrinks = await GetOrderDrinksAsync(order.Value, request.Drinks);

            if (request.Drinks.Any() && !orderDrinks.Any())
            {
                return failureMessage;
            }

            IEnumerable<OrderPizza> orderPizzas = await GetOrderPizzasAsync(order.Value, request.Pizzas);

            if (request.Pizzas.Any() && !orderPizzas.Any())
            {
                return failureMessage;
            }

            Result<Code> code = Code.Create(request.DateOfCreated, orderPizzas, orderDrinks);

            if (code.IsFailure)
            {
                return failureMessage;
            }

            order.Value.SetCode(code.Value);

            if (!await orderRepository.AddAsync(order.Value))
            {
                return failureMessage;
            }

            if (request.Drinks.Any() && !await orderDrinkRepository.AddRangeAsync(orderDrinks))
            {
                return failureMessage;
            }

            if (request.Pizzas.Any() && !await orderPizzaRepository.AddRangeAsync(orderPizzas))
            {
                return failureMessage;
            }

            return Result<string>.Success(code.Value.Value);
        }
        catch
        {
            return failureMessage;
        }
    }

    private bool TryGetCustomerWithPromoCode(OrderRequest request, out Customer? customer, out PromoCode? promoCode)
    {
        promoCode = promoCodeRepository.Get(request.PromoCode);
        customer = null;

        if (request.CustomerId != -1)
        {
            customer = customerRepository.Get(request.CustomerId);

            return (customer is not null && promoCode is not null) || (customer is not null && promoCode is null);
        }

        return true;
    }

    private async Task<IEnumerable<OrderDrink>> GetOrderDrinksAsync(Order order, IEnumerable<OrderDrinkDTO> drinkDTOs)
    {
        var list = new List<OrderDrink>();

        foreach (var drinkDTO in drinkDTOs)
        {
            Drink? drink = await drinkRepository.GetAsync(drinkDTO.DrinkId);

            if (drink is null)
            {
                return [];
            }

            Result<OrderDrink> orderDrink = OrderDrink.Create(order, drink, drinkDTO.Amount);

            if (orderDrink.IsFailure)
            {
                return [];
            }

            list.Add(orderDrink.Value);
        }

        return list;
    }

    private async Task<IEnumerable<OrderPizza>> GetOrderPizzasAsync(Order order, IEnumerable<OrderPizzaDTO> pizzaDTOs)
    {
        var list = new List<OrderPizza>();

        foreach (var pizzaDTO in pizzaDTOs)
        {
            Pizza? pizza = await pizzaRepository.GetAsync(pizzaDTO.PizzaId);

            if (pizza is null)
            {
                return [];
            }

            Result<OrderPizza> orderPizza = OrderPizza.Create(order, pizza, pizzaDTO.Amount);

            if (orderPizza.IsFailure)
            {
                return [];
            }

            IEnumerable<PizzaToppings> toppings = await GetToppingsAsync(orderPizza.Value, pizzaDTO.ToppingDetailsIds);

            orderPizza.Value.AddToppings(toppings);

            list.Add(orderPizza.Value);
        }

        return list;
    }

    private async Task<IEnumerable<PizzaToppings>> GetToppingsAsync(OrderPizza orderPizza, IEnumerable<long> toppingDetailIds)
    {
        var list = new List<PizzaToppings>();

        foreach (var toppingDetailId in toppingDetailIds)
        {
            ToppingDetails? toppingDetails = await toppingDetailsRepository.GetAsync(toppingDetailId);

            if (toppingDetails is null)
            {
                return [];
            }

            Result<PizzaToppings> pizzaTopping = PizzaToppings.Create(orderPizza, toppingDetails);

            if (pizzaTopping.IsFailure)
            {
                return [];
            }

            list.Add(pizzaTopping.Value);
        }

        return list;
    }
}
