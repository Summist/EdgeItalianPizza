namespace EdgeItalianPizza.Domain.Entities;

public sealed class OrderEntity : EntityBase<long>
{
    public long CustomerId { get; set; }
    public UserEntity? Customer { get; set; } = null!;

    public long CourierId { get; set; }
    public UserEntity? Courier { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public int StatusId { get; set; }
    public StatusEntity? Status { get; set; } = null!;

    public ICollection<BasketEntity> Baskets { get; set; } = [];

    public int RestarauntId { get; set; }
    public RestarauntEntity? Restaraunt { get; set; } = null!;

    public int DeliveryId { get; set; }
    public DeliveryEntity? Delivery { get; set; } = null!;
}
