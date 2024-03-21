namespace EdgeItalianPizza.Application.DTOs;

public sealed class AuthCustomerDto
{
    public long Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
}
