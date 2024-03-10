namespace EdgeItalianPizza.Domain.Entities;

public sealed class UserEntity : EntityBase<long>
{
    public string FisrtName { get; set; }
    public string LastName { get; set; }

    public string Login { get; set; }
    public string Password { get; set; }

    public DateTime DateOfBirth { get; set; }

    public int RoleId { get; set; }
    public RoleEntity? Role { get; set; } = null!;
}
