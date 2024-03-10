namespace EdgeItalianPizza.Domain.Entities;

public sealed class PizzaEntity : EntityBase<int>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int Discount { get; set; }

    public ICollection<PizzaSizeEntity> PizzasSizes { get; set; } = [];
    public ICollection<ToppingEntity> Toppings { get; set; } = [];
}
