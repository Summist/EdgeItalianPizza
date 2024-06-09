using EdgeItalianPizza.Domain.Entities.Customers;
using EdgeItalianPizza.Domain.Entities.Customers.ValueObjects;
using EdgeItalianPizza.Domain.ValueObjects;
using EdgeItalianPizza.Share.ResultPattern;
using System.Reflection;

namespace EdgeItalianPizza.Domain.UnitTests.Entities.Customers;

internal class CustomerTests
{
    [TestCase("2005-05-09")]
    [TestCase("1996-05-09")]
    [TestCase("1926-05-09")]
    [TestCase("2012-05-09")]
    public void IsAgeAppropriate_Return_True(string date)
    {
        Type type = typeof(Customer);

        var customer = (Customer)Activator.CreateInstance(type, true);

        MethodInfo method = type.GetMethod(
            "IsAgeAppropriate",
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static);

        bool result = (bool)method.Invoke(
           customer,
           [DateOnly.Parse(date)]);

        Assert.That(result, Is.True);
    }

    [TestCase("2013-05-09")]
    [TestCase("1923-05-09")]
    [TestCase("2024-05-09")]
    [TestCase("2019-05-09")]
    public void IsAgeAppropriate_Return_False(string date)
    {
        Type type = typeof(Customer);

        var customer = (Customer)Activator.CreateInstance(type, true);

        MethodInfo method = type.GetMethod(
            "IsAgeAppropriate",
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static);

        bool result = (bool)method.Invoke(
           customer,
           [DateOnly.Parse(date)]);

        Assert.That(result, Is.False);
    }

    [TestCase("89033758921", "+7 (903) 375-89-21")]
    [TestCase("+79033758921", "+7 (903) 375-89-21")]
    public void FormatPhoneNumber_Return_Expected(string input, string expected)
    {
        Type type = typeof(Customer);

        var customer = (Customer)Activator.CreateInstance(type, true);

        MethodInfo method = type.GetMethod(
            "FormatPhoneNumber",
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static);

        string result = (string)method.Invoke(
           customer,
           [input]);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("89033758921", new string[] { "89033758921", "89033759921" })]
    [TestCase("89033758921", new string[] { "+79033758921", "89033759921" })]
    [TestCase("89033758921", new string[] { "+7 (903) 375-89-21", "89033759921" })]
    [TestCase("89033758921", new string[] { "89033758921" })]
    public void IsPhoneNumberAvailable_Return_False(string input, string[] phoneNumbers)
    {
        Type type = typeof(Customer);

        var customer = (Customer)Activator.CreateInstance(type, true);

        MethodInfo method = type.GetMethod(
            "IsPhoneNumberAvailable",
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static);

        bool result = (bool)method.Invoke(
           customer,
           [input, phoneNumbers]);

        Assert.That(result, Is.False);
    }

    [TestCase("89033758921", new string[] { "89033759921", "89033759921" })]
    [TestCase("89033758921", new string[] { "+89033759921", "89033759921" })]
    [TestCase("89033758921", new string[] { "89033759921", "89033759921" })]
    public void IsPhoneNumberAvailable_Return_True(string input, string[] phoneNumbers)
    {
        Type type = typeof(Customer);

        var customer = (Customer)Activator.CreateInstance(type, true);

        MethodInfo method = type.GetMethod(
            "IsPhoneNumberAvailable",
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static);

        bool result = (bool)method.Invoke(
           customer,
           [input, phoneNumbers]);

        Assert.That(result, Is.True);
    }

    [Test]
    public void DataValidVerification_Return_Result_With_IsSuccess_True()
    {
        Type type = typeof(Customer);

        var customer = (Customer)Activator.CreateInstance(type, true);

        MethodInfo method = type.GetMethod(
            "DataValidVerification",
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static);

        var phoneNumber = PhoneNumber.Create("89033758921");
        var password = Password.Create("Qwe123456789!");

        Result result = (Result)method.Invoke(
           customer,
           [phoneNumber.Value, password.Value]);

        Assert.That(result.IsSuccess, Is.True);
    }

    [Test]
    public void DataValidVerification_Return_Result_With_IsFailure_True()
    {
        Type type = typeof(Customer);

        var customer = (Customer)Activator.CreateInstance(type, true);

        MethodInfo method = type.GetMethod(
            "DataValidVerification",
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static);

        Result result = (Result)method.Invoke(
           customer,
           [null, null]);

        Assert.That(result.IsFailure, Is.True);
    }

    [TestCase("89033758921", new string[] { "89033758991" }, "Qwe123456789!")]
    [TestCase("89033758921", new string[] { "89033758991", "+79033755921" }, "Qwe123456789!")]
    public void Create_Should_Return_Result_With_IsSuccess_True(string phoneNumber, string[] phoneNumbers, string password)
    {
        var phoneNumberResult = PhoneNumber.Create(phoneNumber);
        var passwordResult = Password.Create(password);

        var customer = Customer.Create(phoneNumberResult.Value, phoneNumbers, passwordResult.Value);

        Assert.That(customer.IsSuccess, Is.True);
    }

    [TestCase("89033758921", new string[] { "89033758921" }, "Qwe123456789!")]
    public void Create_Should_Return_Result_With_IsFailure_True(string phoneNumber, string[] phoneNumbers, string password)
    {
        var phoneNumberResult = PhoneNumber.Create(phoneNumber);
        var passwordResult = Password.Create(password);

        var customer = Customer.Create(phoneNumberResult.Value, phoneNumbers, passwordResult.Value);

        Assert.That(customer.IsFailure, Is.True);
    }

    [Test]
    public void Create_Should_Return_Result_With_IsFailure_True()
    {
        var customer = Customer.Create(null, [], null);

        Assert.That(customer.IsFailure, Is.True);
    }

    [TestCase("89033758921", "Qwe123456789!")]
    public void Create_Should_Return_Result_With_IsSuccess_True(string phoneNumber, string password)
    {
        var phoneNumberResult = PhoneNumber.Create(phoneNumber);
        var passwordResult = Password.Create(password);

        var customer = Customer.Create(phoneNumberResult.Value, passwordResult.Value);

        Assert.That(customer.IsSuccess, Is.True);
    }

    [Test]
    public void Create_Return_Result_With_IsFailure_True()
    {
        var customer = Customer.Create(null, null);

        Assert.That(customer.IsFailure, Is.True);
    }
}
