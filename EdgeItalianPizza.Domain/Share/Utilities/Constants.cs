namespace EdgeItalianPizza.Domain.Share.Utilities;

/// <summary>
/// Класс, содержащий константные значения приложения.
/// </summary>
public static class Constants
{
    /// <summary>
    /// Класс, содержащий информацию о максимально и минимально допустимых длинах.
    /// </summary>
    public static class LimitLength
    {
        /// <summary>
        /// Максимально разрешенная длина для ссылок на изображение.
        /// </summary>
        public const int PhotoUri = 100;
        /// <summary>
        /// Минимально разрешенная длина для логина.
        /// </summary>
        public const int MinLogin = 6;
        /// <summary>
        /// Минимально разрешенная длина для пароля.
        /// </summary>
        public const int MinPassword = 8;
        /// <summary>
        /// Минимально разрешенная длина для номера телефона.
        /// </summary>
        public const int MinPhoneNumber = 10;
    }

    /// <summary>
    /// Класс, содержащий паттерны для проверок с помощью регулярных выражений.
    /// </summary>
    public static class RegexPattern
    {
        /// <summary>
        /// Паттерн для номера телефона.
        /// </summary>
        public const string PhoneNumber = @"^(\+7|8)?\s?\(?\d{3}\)?[\s-]?\d{3}[\s-]?\d{2}[\s-]?\d{2}$";
        /// <summary>
        /// Паттерн для пароля.
        /// </summary>
        public const string Password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$";
    }
}
