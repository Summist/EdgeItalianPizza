using System.Text.RegularExpressions;

namespace EdgeItalianPizza.Share.FluentValidation;

/// <summary>
/// Класс с правилами для валидации строк.
/// </summary>
/// <param name="input">Строка, которую необходимо проверить.</param>
public sealed class FluentValidator(string input)
{
    private readonly string _input = input ?? string.Empty;

    private bool _isValid = true;

    /// <summary>
    /// Cообщение об ошибке при валидации.
    /// </summary>
    public string ErrorMessage { get; private set; } = string.Empty;

    /// <summary>
    /// Является ли проверяемая строка пустой, <see langword="null"/> или содержит пробелы.
    /// </summary>
    /// <param name="errorMessage">Сообщение об ошибке.</param>
    /// <returns>Возвращает данный <see cref="FluentValidator"/>.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public FluentValidator NotEmpty(string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(errorMessage);

        if (!_isValid)
        {
            return this;
        }

        bool isNotEmpty = HandleCondition(
            !string.IsNullOrWhiteSpace(_input) || 
            _input.Trim().Length > 0);

        SetErrorMessage(isNotEmpty, errorMessage);

        return this;
    }

    /// <summary>
    /// Проверка входит ли длина валидируемой строки в заданный диапазон.
    /// </summary>
    /// <param name="min">Минимально допустимая длина.</param>
    /// <param name="max">Максимально допустимая длина.</param>
    /// <returns>Возвращает данный <see cref="FluentValidator"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public FluentValidator Length(int min, int max)
    {
        if (min < 0 ||
            min > max)
        {
            throw new ArgumentOutOfRangeException("Min length value cannot be a less then zero and max length value.");
        }

        if (!_isValid)
        {
            return this;
        }

        int length = _input.Trim().Length;

        bool isValidLength = HandleCondition(length >= min && length <= max);

        SetErrorMessage(isValidLength, $"Длина поля должна быть от {min} до {max} символов");

        return this;
    }

    /// <summary>
    /// Проверка подходит ли валидируемая строка заданному паттерну.
    /// </summary>
    /// <param name="regex">Класс <see cref="Regex"/> с заданным паттерном.</param>
    /// <param name="errorMessage">Сообщение об ошибке.</param>
    /// <returns>Возвращает данный <see cref="FluentValidator"/>.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public FluentValidator IsMatch(Regex regex, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(regex);
        ArgumentNullException.ThrowIfNull(errorMessage);

        if (!_isValid)
        {
            return this;
        }

        bool isFindMatch = HandleCondition(regex.IsMatch(_input));

        SetErrorMessage(isFindMatch, errorMessage);

        return this;
    }

    /// <summary>
    /// Проверка подходит ли валидируемая строка заданному паттерну.
    /// </summary>
    /// <param name="pattern">Паттерн для Regex.</param>
    /// <param name="errorMessage">Сообщение об ошибке.</param>
    /// <returns>Возвращает данный <see cref="FluentValidator"/>.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public FluentValidator IsMatch(string pattern, string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(pattern);
        ArgumentNullException.ThrowIfNull(errorMessage);

        if (!_isValid)
        {
            return this;
        }

        bool isFindMatch = HandleCondition(Regex.IsMatch(_input, pattern));

        SetErrorMessage(isFindMatch, errorMessage);

        return this;
    }

   /// <summary>
   /// Результат проверки на валидацию.
   /// </summary>
   /// <returns>
   /// Возвращает <see langword="true"/>, если строка прошла все проверки, в противном случае <see langword="false"/>.
   /// </returns>
    public bool Validate()
    {
        return _isValid;
    }

    private bool HandleCondition(bool condition)
    {
        _isValid = condition;
        return condition;
    }

    private void SetErrorMessage(bool isConditionValid, string errorMessage)
    {
        ErrorMessage = isConditionValid ? string.Empty : errorMessage;
    }
}
