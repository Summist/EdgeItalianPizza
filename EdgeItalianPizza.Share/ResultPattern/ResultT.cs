namespace EdgeItalianPizza.Share.ResultPattern;

/// <summary>
/// Реализация ResultPattern.
/// </summary>
public sealed partial class Result<TValue>
{
    /// <summary>
    /// Является ли результат успешным.
    /// </summary>
    public bool IsSuccess { get; private set; } = false;
    /// <summary>
    /// Является ли результат провальным.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Сообщение об ошибке.
    /// </summary>
    public string ErrorMessage { get; private set; } = string.Empty;

    private readonly TValue _value = default;
    /// <summary>
    /// Значение при положительном результате.
    /// </summary>
    public TValue Value => _value;

    private Result(TValue value)
    {
        _value = value;
        IsSuccess = true;
    }

    private Result(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Метод, возращающий положительный результат.
    /// </summary>
    /// <param name="value">Значение при положительном результате</param>
    public static Result<TValue> Success(TValue value) => new(value);

    /// <summary>
    /// Метод, возвращающий провальный результат.
    /// </summary>
    /// <param name="errorMessage">Сообщение об ошибке</param>
    public static Result<TValue> Failure(string errorMessage) => new(errorMessage);

    /// <summary>
    /// Преобразование значения в тип Result.
    /// </summary>
    /// <param name="value">Значение при положительном результате</param>
    public static implicit operator Result<TValue>(TValue value) => new(value);

    /// <summary>
    /// Преобразование строки в тип Result.
    /// </summary>
    /// <param name="errorMessage">Сообщение об ошибке</param>
    public static implicit operator Result<TValue>(string errorMessage) => new(errorMessage);
}
