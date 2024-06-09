using System.Security.Cryptography;
using System.Text;

namespace EdgeItalianPizza.Share.HashServices;

/// <summary>
/// Сервис хеширования.
/// </summary>
public sealed class HashService
{
    /// <summary>
    /// Метод хеширования
    /// </summary>
    /// <param name="value">Строка, которую нужно захешировать.</param>
    /// <returns>Захешированная строка.</returns>
    public static string Hash(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return string.Empty;

        byte[] passwordBytes = Encoding.UTF8.GetBytes(value);
        byte[] hash = SHA1.HashData(passwordBytes);

        return Convert.ToBase64String(hash);
    }
}
