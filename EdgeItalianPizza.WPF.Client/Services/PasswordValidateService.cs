using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Domain;
using System.Text.RegularExpressions;

namespace EdgeItalianPizza.WPF.Client.Services;

public sealed class PasswordValidateService : IPasswordValidateService
{
    public bool IsValidate(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            return false;
        }

        if (!IsCorrectLength(password))
        {
            return false;
        }

        int counter = 0;

        counter += GetAmountOfRegexMathces(password, new Regex(@"[a-z]"), "Пароль должен содержать латинские буквы нижнего регистра");
        counter += GetAmountOfRegexMathces(password, new Regex(@"[A-Z]"), "Пароль должен содержать латинские бувы верхнего регистра");
        counter += GetAmountOfRegexMathces(password, new Regex(@"[0-9]"), "Пароль должен содержать цифры");
        counter += GetAmountOfRegexMathces(password, new Regex(@"[!#@$%^&*()_+=}{?><]"), "Пароль должен содержать специальные символы");

        if (password.Length != counter)
        {
            return false;
        }

        return true;
    }

    private bool IsCorrectLength(string password)
    {
        if (password.Length < Constants.PASSWORD_MIN_LENGTH)
        {
            return false;
        }

        if (password.Length > Constants.PASSWORD_MAX_LENGTH)
        {
            return false;
        }

        return true;
    }

    private int GetAmountOfRegexMathces(string password, Regex regex, string errorMassage)
    {
        int count = regex.Count(password);

        if (count == 0)
        {
        }

        return count;
    }
}
