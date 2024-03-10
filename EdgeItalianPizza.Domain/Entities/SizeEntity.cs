namespace EdgeItalianPizza.Domain.Entities;

public sealed class SizeEntity : EntityBase<int>
{
    public int Radius { get; set; }

    public ICollection<PizzaSizeEntity> PizzasSizes { get; set; } = [];
}
