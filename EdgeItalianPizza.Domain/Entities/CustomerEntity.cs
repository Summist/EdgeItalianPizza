namespace EdgeItalianPizza.Domain.Entities;

public sealed class CustomerEntity : EntityBase<long>
{
    public string FisrtName { get; set; }
    public string LastName { get; set; }

    public string Login { get; set; }
    public string Password { get; set; }

    public DateTime DateOfBirth { get; set; }

    public ICollection<OrderEntity> Orders { get; set; } = [];
}
