namespace EdgeItalianPizza.WPF.Client.MVVM.Model;

public sealed class UserModel
{
    public long Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
}
