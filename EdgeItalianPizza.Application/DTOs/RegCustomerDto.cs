namespace EdgeItalianPizza.Application.DTOs;

public sealed class RegCustomerDto
{
    public string Login { get; set; }
    public string Password { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
}
