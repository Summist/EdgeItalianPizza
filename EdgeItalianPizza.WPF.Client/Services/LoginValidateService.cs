using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Domain;
using System.Text.RegularExpressions;

namespace EdgeItalianPizza.WPF.Client.Services;

public sealed class LoginValidateService : ILoginValidateService
{
    public string ErrorMessage { get; private set; }

    public bool IsValidate(string login)
    {
        if (string.IsNullOrWhiteSpace(login))
        {
            ErrorMessage += "Поле с логином обязятельно для заполнения";
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
            ErrorMessage = $"Невозможный логин";
            return false;
        }

        return true;
    }

    private bool IsCorrectLength(string login)
    {
        if (login.Length < Constants.LOGIN_MIN_LENGTH)
        {
            ErrorMessage = $"Логин не может быть меньше {Constants.LOGIN_MIN_LENGTH} символов";
            return false;
        }

        if (login.Length > Constants.LOGIN_MAX_LENGTH)
        {
            ErrorMessage = $"Логин не может быть больше {Constants.LOGIN_MAX_LENGTH} символов";
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
