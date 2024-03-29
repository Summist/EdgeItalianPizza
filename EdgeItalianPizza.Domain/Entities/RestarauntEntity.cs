﻿namespace EdgeItalianPizza.Domain.Entities;

public sealed class RestarauntEntity : EntityBase<int>
{
    public string Login { get; set; }
    public string Password { get; set; }

    public string Address { get; set; }

    public int CityId { get; set; }
    public CityEntity? City { get; set; } = null!;

    public ICollection<OrderEntity> Orders { get; set; } = [];
}
