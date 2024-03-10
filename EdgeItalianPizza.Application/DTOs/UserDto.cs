namespace EdgeItalianPizza.Application.DTOs;

public sealed class UserDto
{
    public long Id { get; set; }

    public string FisrtName { get; set; }
    public string LastName { get; set; }


    public DateTime DateOfBirth { get; set; }

    public int RoleId { get; set; }
}
