namespace EdgeItalianPizza.Application.DTOs.Orders;

public record OrderRequest(
    long RestaurantId,
    IEnumerable<OrderDrinkDTO> Drinks,
    IEnumerable<OrderPizzaDTO> Pizzas,
    DateTime DateOfCreated,
    int BonusCoins = 0,
    long CustomerId = -1,
    string PromoCode = "");

public record OrderDrinkDTO(
    long DrinkId,
    int Amount);

public record OrderPizzaDTO(
    long PizzaId,
    IEnumerable<long> ToppingDetailsIds,
    int Amount);
