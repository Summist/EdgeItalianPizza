namespace EdgeItalianPizza.Domain.Entities;

public sealed class CourierEntity : EntityBase<long>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Login { get; set; }
    public string Password { get; set; }

    public string INN { get; set; }

    public string PassportNumber { get; set; }

    public int CityId { get; set; }
    public CityEntity? City { get; set; } = null!;

    public ICollection<OrderEntity> Orders { get; set; } = [];
}
