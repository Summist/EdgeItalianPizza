namespace EdgeItalianPizza.Domain.Entities;

public sealed class PizzaSizeEntity : EntityBase<int>
{
    public int PizzaId { get; set; }
    public PizzaEntity? Pizza { get; set; } = null!;

    public int SizeId { get; set; }
    public SizeEntity? Size { get; set; } = null!;

    public double Price { get; set; }

    public string PhotoName { get; set; }

    public double Energy { get; set; }
    public double Proteins { get; set; }
    public double Fats { get; set; }
    public double Carbohydrates { get; set; }

    public double Weight { get; set; }

    public ICollection<ProductEntity> Products { get; set; } = [];
}
