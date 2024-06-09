using EdgeItalianPizza.Share.HashServices;

namespace EdgeItalianPizza.Share.UnitTest.HashServices;

internal class HashServiceTests
{
    [TestCase(null)]
    [TestCase("")]
    [TestCase("          ")]
    public void Hash_Null_Or_White_Space_Result_String_Empty(string value)
    {
        // Act
        string expected = string.Empty;
        string actual = HashService.Hash(value);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Hash_Input_Qwe123_Result()
    {
        // Act
        string expected = "TSaluv064Z2hxujVpbH/3dCWQRo=";
        string actual = HashService.Hash("Qwe123");

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
