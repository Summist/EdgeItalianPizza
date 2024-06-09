namespace EdgeItalianPizza.UI.Share.Info;

/// <summary>
/// Информация о заведении к которому привязан терминал.
/// </summary>
internal static class RestaurantInfo
{
    /// <summary>
    /// Событие, оповещающее о авторизации заведения.
    /// </summary>
    public static event Action OnInfoChanged;

    /// <summary>
    /// Свойство, указывающее авторизовано ли заведение или нет.
    /// </summary>
    public static bool IsAuthorized => Info > 0;

    private static long _info = -1;
    /// <summary>
    /// Данные необходимые после авторизации.
    /// </summary>
    public static long Info
    {
        get => _info;
        set
        {
            _info = value;
            OnInfoChanged?.Invoke();
        }
    }
}
