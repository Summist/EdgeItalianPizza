namespace EdgeItalianPizza.Domain.Entities;

public sealed class RoleEntity : EntityBase<int>
{
    public string Name { get; set; }

    public ICollection<UserEntity> Users { get; set; } = [];
}
