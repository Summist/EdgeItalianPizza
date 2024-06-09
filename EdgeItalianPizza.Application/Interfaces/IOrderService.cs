using EdgeItalianPizza.Application.DTOs.Orders;
using EdgeItalianPizza.Share.ResultPattern;

namespace EdgeItalianPizza.Application.Interfaces;

public interface IOrderService
{
    Task<Result<string>> MakeOrderAsync(OrderRequest request);
}
