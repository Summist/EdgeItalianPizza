namespace EdgeItalianPizza.Domain.Entities;

public sealed class ToppingEntity : EntityBase<int>
{
    public string Name { get; set; }

    public string PhotoName { get; set; }

    public double Price { get; set; }

    public ICollection<PizzaEntity> Pizzas { get; set; } = [];
    public ICollection<ProductEntity> Products { get; set; } = [];
}
