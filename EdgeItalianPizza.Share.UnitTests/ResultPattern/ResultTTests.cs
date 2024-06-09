using EdgeItalianPizza.Share.ResultPattern;

namespace EdgeItalianPizza.Share.UnitTests.ResultPattern;

internal class ResultTTests
{
    [Test]
    public void Success_Should_Return_Result_With_IsSuccess_True()
    {
        Assert.That(Result<string>.Success(string.Empty).IsSuccess, Is.True);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("  ")]
    [TestCase("12313")]
    [TestCase("\t\n\r")]
    public void Success_Should_Return_Result_With_IsSuccess_Value_Equal_Input(string value)
    {
        Assert.That(Result<string>.Success(value).Value, Is.EqualTo(value));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("  ")]
    [TestCase("12313")]
    [TestCase("\t\n\r")]
    public void Failure_Should_Return_Result_With_IsFailure_True(string errorMessage)
    {
        Assert.That(Result<string>.Failure(errorMessage).IsFailure, Is.True);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("  ")]
    [TestCase("12313")]
    [TestCase("\t\n\r")]
    public void Failure_Should_Return_Result_With_ErrorMessage_Equal_Input(string errorMessage)
    {
        Assert.That(Result<string>.Failure(errorMessage).ErrorMessage, Is.EqualTo(errorMessage));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("  ")]
    [TestCase("12313")]
    [TestCase("\t\n\r")]
    public void Failure_Should_Return_Result_With_Value_Is_Null(string errorMessage)
    {
        Assert.That(Result<string>.Failure(errorMessage).Value, Is.Null);
    }
}
