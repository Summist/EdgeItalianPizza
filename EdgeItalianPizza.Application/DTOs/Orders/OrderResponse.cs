namespace EdgeItalianPizza.Application.DTOs.Orders;

public record OrderResponse(
    string Code,
    int BonusCoinsFromOrder);
