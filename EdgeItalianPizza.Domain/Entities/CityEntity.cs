namespace EdgeItalianPizza.Domain.Entities;

public sealed class CityEntity : EntityBase<int>
{
    public string Name { get; set; }

    public ICollection<RestarauntEntity> Restaraunts { get; set; } = [];
    public ICollection<DeliveryEntity> Deliveries { get; set; } = [];
    public ICollection<CourierEntity> Couriers { get; set; } = [];
}
