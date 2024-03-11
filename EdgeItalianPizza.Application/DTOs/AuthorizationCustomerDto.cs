namespace EdgeItalianPizza.Application.DTOs;

public sealed class AuthorizationUserDto
{
    public int Status { get; set; }

    public long Id { get; set; }

    public string FisrtName { get; set; }
    public string LastName { get; set; }


    public DateTime DateOfBirth { get; set; }
}
