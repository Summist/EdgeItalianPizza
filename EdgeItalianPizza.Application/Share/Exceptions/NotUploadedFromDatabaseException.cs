namespace EdgeItalianPizza.Application.Share.Exceptions;

/// <summary>
/// Ошибка о том, что данные не были выгружены из базы данных.
/// </summary>
/// <param name="name">Название.</param>
internal class NotUploadedFromDatabaseException(string name)
    : ArgumentException(name + " не были выгружены из базы данных");
