namespace EdgeItalianPizza.Share.ResultPattern.Extensions;

/// <summary>
/// Класс расширение для ResultPattern.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Метод сравнения <see cref="{TSourse}"/> с <see langword="null"/>.
    /// </summary>
    /// <typeparam name="TValue">Тип, который нужно вернуть.</typeparam>
    /// <typeparam name="TSource">Тип, сравниваемый с <see langword="null"/>.</typeparam>
    /// <param name="source">Объект, сравниваемые с <see langword="null"/>.</param>
    /// <param name="onSuccess">Функция, которую нужно вернуть, если <paramref name="source"/> не <see langword="null"/>.</param>
    /// <param name="onFailure">Функция, которую нужно вернуть, если <paramref name="source"/> <see langword="null"/>.</param>
    /// <returns>
    /// Возвращает <see cref="Result{TValue}"/>.
    /// </returns>
    public static Result<TValue> Match<TValue, TSource>(
        this TSource source,
        Func<TValue> onSuccess,
        Func<string> onFailure)
    {
        if (source is null)
        {
            return onFailure();
        }

        return onSuccess();
    }
}
