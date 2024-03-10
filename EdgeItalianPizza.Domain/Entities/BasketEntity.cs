namespace EdgeItalianPizza.Domain.Entities;

public sealed class BasketEntity : EntityBase<long>
{
    public long ProductId { get; set; }
    public ProductEntity? Product { get; set; } = null!;

    public int Amount { get; set; }

    public decimal Price { get; set; }

    public ICollection<OrderEntity> Orders { get; set; } = [];
}
