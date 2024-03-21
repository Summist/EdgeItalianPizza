namespace EdgeItalianPizza.WPF.Client.MVVM.Model;

internal sealed class PizzaModel
{
    public int Id { get; set; }

    public string PhotoPath { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public int Discount { get; set; }
}
