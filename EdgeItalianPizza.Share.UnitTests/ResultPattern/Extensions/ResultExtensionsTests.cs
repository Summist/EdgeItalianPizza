using EdgeItalianPizza.Share.ResultPattern.Extensions;

namespace EdgeItalianPizza.Share.UnitTests.ResultPattern.Extensions;

internal class ResultExtensionsTests
{
    [TestCase("213", "123")]
    [TestCase("qweqw", "123")]
    [TestCase("   ", "123")]
    [TestCase("null", "123")]
    public void Match_Should_Return_Result_With_Value_Not_Null(string source, string value)
    {
        var actual = source.Match(
            () => value,
            () => string.Empty);

        Assert.That(actual.Value, Is.EqualTo(value));
    }

    [TestCase(null, "123")]
    public void Match_Should_Return_Result_With_ErrorMessage_Equal_Input(string source, string errorMessage)
    {
        var actual = source.Match(
            () => string.Empty,
            () => errorMessage);

        Assert.That(actual.ErrorMessage, Is.EqualTo(errorMessage));
    }
}
