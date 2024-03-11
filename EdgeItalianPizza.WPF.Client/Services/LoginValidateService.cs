using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Domain;
using EdgeItalianPizza.WPF.Client.Windows.Auth;
using System.Text.RegularExpressions;

namespace EdgeItalianPizza.WPF.Client.Services;

public sealed class LoginValidateService : ILoginValidateService
{
    private readonly AuthorizationWindow _window;

    public LoginValidateService(AuthorizationWindow window)
    {
        _window = window;
    }

    public bool IsValidate(string login)
    {
        if (string.IsNullOrWhiteSpace(login))
        {
            _window.loginErrorLabel.Text = "Поле с логином обязательно для заполнения";
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
            _window.loginErrorLabel.Text = "Невозможный логин";
            return false;
        }

        return true;
    }

    private bool IsCorrectLength(string login)
    {
        if (login.Length < Constants.LOGIN_MIN_LENGTH)
        {
            _window.loginErrorLabel.Text = $"Длина логина не может быть меньше {Constants.LOGIN_MIN_LENGTH}";
            return false;
        }

        if (login.Length > Constants.LOGIN_MAX_LENGTH)
        {
            _window.loginErrorLabel.Text = $"Длина логина не может быть больше {Constants.LOGIN_MAX_LENGTH}";
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
