using EdgeItalianPizza.Share.ResultPattern;

namespace EdgeItalianPizza.Share.UnitTests.ResultPattern;

internal class ResultTests
{
    [Test]
    public void Success_Should_Return_Result_With_IsSuccess_True()
    {
        Assert.That(Result.Success().IsSuccess, Is.True);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("  ")]
    [TestCase("12313")]
    [TestCase("\t\n\r")]
    public void Failure_Should_Return_Result_With_IsFailure_True(string errorMessage)
    {
        Assert.That(Result.Failure(errorMessage).IsFailure, Is.True);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("  ")]
    [TestCase("12313")]
    [TestCase("\t\n\r")]
    public void Failure_Should_Return_Result_With_ErrorMessage_Equal_Input(string errorMessage)
    {
        Assert.That(Result.Failure(errorMessage).ErrorMessage, Is.EqualTo(errorMessage));
    }
}
