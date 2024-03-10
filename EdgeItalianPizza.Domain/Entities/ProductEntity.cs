namespace EdgeItalianPizza.Domain.Entities;

public sealed class ProductEntity : EntityBase<long>
{
    public int PizzaSizeId { get; set; }
    public PizzaSizeEntity? PizzaSize { get; set; } = null!;

    public int ToppingId { get; set; }
    public ToppingEntity? Topping { get; set; } = null!;

    public ICollection<BasketEntity> Baskets { get; set; } = [];
}
