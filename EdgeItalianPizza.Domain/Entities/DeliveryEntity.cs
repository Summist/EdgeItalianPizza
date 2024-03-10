namespace EdgeItalianPizza.Domain.Entities;

public sealed class DeliveryEntity : EntityBase<int>
{
    public string Address { get; set; }

    public int CityId { get; set; }
    public CityEntity? City { get; set; } = null!;

    public ICollection<OrderEntity> Orders { get; set; } = [];
}
