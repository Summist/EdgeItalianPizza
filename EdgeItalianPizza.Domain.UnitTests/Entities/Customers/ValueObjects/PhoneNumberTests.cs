using EdgeItalianPizza.Domain.Entities.Customers.ValueObjects;

namespace EdgeItalianPizza.Domain.UnitTests.Entities.Customers.ValueObjects;

internal class PhoneNumberTests
{
    [TestCase("+79033758921")]
    [TestCase("89033758921")]
    [TestCase("+7 (903) 375-89-21")]
    public void Create_Return_Result_With_IsSuccess_True_And_Value_Not_Null(string value)
    {
        var phoneNumber = PhoneNumber.Create(value);

        Assert.Multiple(() =>
        {
            Assert.That(phoneNumber.Value, Is.Not.Null);
            Assert.That(phoneNumber.IsSuccess, Is.True);
        });
    }

    [TestCase("+65 6511 !9266")]
    [TestCase("")]
    [TestCase(null)]
    [TestCase("+65 6511 92666511 926611222")]
    public void Create_Return_Result_With_IsFailure_True_And_Value_Is_Null(string value)
    {
        var phoneNumber = PhoneNumber.Create(value);

        Assert.Multiple(() =>
        {
            Assert.That(phoneNumber.Value, Is.Null);
            Assert.That(phoneNumber.IsFailure, Is.True);
        });
    }
}
