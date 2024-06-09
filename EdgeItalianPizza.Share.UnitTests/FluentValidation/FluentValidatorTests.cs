using EdgeItalianPizza.Share.FluentValidation;
using System.Text.RegularExpressions;

namespace EdgeItalianPizza.Share.UnitTests.FluentValidation;

internal class FluentValidatorTests
{
    [TestCase("123")]
    [TestCase("1")]
    [TestCase("  sda")]
    public void NotEmpty_Return_FluentValidator_With_ErrorMessage_Empty(string value)
    {
        var fluentValidator = new FluentValidator(value);

        Assert.That(fluentValidator.NotEmpty("not empty").ErrorMessage, Is.Empty);
    }

    [TestCase(null, "123")]
    [TestCase("", "123")]
    [TestCase("  ", "123")]
    public void NotEmpty_Return_FluentValidator_With_ErrorMessage_Equal_Input_ErrorMessage(string value, string errorMessage)
    {
        var fluentValidator = new FluentValidator(value);

        Assert.That(fluentValidator.NotEmpty(errorMessage).ErrorMessage, Is.EqualTo(errorMessage));
    }

    [Test]
    public void NotEmpty_Throw_ArgumentNullException()
    {
        var fluentValidator = new FluentValidator(string.Empty);

        Assert.Throws<ArgumentNullException>(() => fluentValidator.NotEmpty(null!));
    }

    [TestCase("123", 1, 10)]
    [TestCase("123123123123123123", 1, 30)]
    [TestCase("", 0, 10)]
    public void Length_Return_FluentValidator_With_ErrorMessage_Empty(string value, int min, int max)
    {
        var fluentValidator = new FluentValidator(value);

        Assert.That(fluentValidator.Length(min, max).ErrorMessage, Is.Empty);
    }

    [TestCase("123", 1, 2)]
    [TestCase("123123123123123123", 1, 5)]
    [TestCase("", 1, 10)]
    public void Length_Return_FluentValidator_With_ErrorMessage_Not_Empty(string value, int min, int max)
    {
        var fluentValidator = new FluentValidator(value);

        Assert.That(fluentValidator.Length(min, max).ErrorMessage, Is.EqualTo($"Длина поля должна быть от {min} до {max} символов"));
    }

    [TestCase(-1, 100)]
    [TestCase(10, 9)]
    public void Length_Throw_ArgumentOutOfRangeException(int min, int max)
    {
        var fluentValidator = new FluentValidator(string.Empty);

        Assert.Throws<ArgumentOutOfRangeException>(() => fluentValidator.Length(min, max));
    }

    [TestCase(null, "")]
    [TestCase("", null)]
    [TestCase(null, null)]
    public void IsMatch_Throw_ArgumentNullException(string pattern, string errorMessage)
    {
        var fluentValidator = new FluentValidator(string.Empty);

        Assert.Throws<ArgumentNullException>(() => fluentValidator.IsMatch(pattern, errorMessage));
    }

    [TestCase(null, "")]
    [TestCase(null, null)]
    public void IsMatch_Throw_ArgumentNullException(Regex regex, string errorMessage)
    {
        var fluentValidator = new FluentValidator(string.Empty);

        Assert.Throws<ArgumentNullException>(() => fluentValidator.IsMatch(regex, errorMessage));
    }

    [Test]
    public void IsMatch_Throw_ArgumentNullException()
    {
        var fluentValidator = new FluentValidator(string.Empty);

        Regex regex = null!;

        Assert.Throws<ArgumentNullException>(() => fluentValidator.IsMatch(regex, string.Empty));
    }

    [TestCase("89033758921", @"^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$")]
    public void IsMatch_Return_FluentValidator_With_ErrorMessage_Empty(string value, string pattern)
    {
        var fluentValidator = new FluentValidator(value);

        Assert.That(fluentValidator.IsMatch(pattern, "not empty").ErrorMessage, Is.Empty);
    }

    [TestCase("89033758921Q", @"^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$", "error")]
    public void IsMatch_Return_FluentValidator_With_ErrorMessage_Equal_Input_Error(string value, string pattern, string errorMessage)
    {
        var fluentValidator = new FluentValidator(value);

        Assert.That(fluentValidator.IsMatch(pattern, errorMessage).ErrorMessage, Is.EqualTo(errorMessage));
    }
}
