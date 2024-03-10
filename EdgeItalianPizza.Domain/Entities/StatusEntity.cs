namespace EdgeItalianPizza.Domain.Entities;

public sealed class StatusEntity : EntityBase<int>
{
    public string Name { get; set; }

    public ICollection<OrderEntity> Orders { get; set; } = [];
}
