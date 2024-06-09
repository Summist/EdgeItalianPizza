namespace EdgeItalianPizza.Share.ResultPattern;

/// <summary>
/// Реализация ResultPattern.
/// </summary>
public sealed partial class Result
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

    /// <summary>
    /// Конструктор, присваивающий результат положительным. 
    /// </summary>
    private Result()
    {
        IsSuccess = true;
    }

    /// <summary>
    /// Конструктор, присваивающий результат провальным.
    /// </summary>
    /// <param name="errorMessage">Сообщение об ошибке.</param>
    private Result(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Метод возвращающий положительный результат.
    /// </summary>
    public static Result Success() => new();

    /// <summary>
    /// Метод, возвращающий провальный результат.
    /// </summary>
    /// <param name="errorMessage">Сообщение об ошибке</param>
    public static Result Failure(string errorMessage) => new(errorMessage);

    /// <summary>
    /// Преобразование строки в тип Result.
    /// </summary>
    /// <param name="errorMessage">Сообщение об ошибке</param>
    public static implicit operator Result(string errorMessage) => new(errorMessage);
}
