using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Domain;
using System.Text.RegularExpressions;

namespace EdgeItalianPizza.WPF.Client.Services;

public sealed class LoginValidateService : ILoginValidateService
{

    public bool IsValidate(string login)
    {
        if (string.IsNullOrWhiteSpace(login))
        {
            return false;
        }

        if (!IsCorrectLength(login))
        {
            return false;
        }

        int counter = GetCountOfRegexMathches(login,
            new Regex(@"[0-9a-zA-Z!#@$%^&*()_+=}{?><]"));

        if (login.Length != counter)
        {
            return false;
        }

        return true;
    }

    private bool IsCorrectLength(string login)
    {
        if (login.Length < Constants.LOGIN_MIN_LENGTH)
        {
            return false;
        }

        if (login.Length > Constants.LOGIN_MAX_LENGTH)
        {
            return false;
        }

        return true;
    }

    private int GetCountOfRegexMathches(string login, Regex regex)
    {
        int count = regex.Count(login);

        return count;
    }
}
