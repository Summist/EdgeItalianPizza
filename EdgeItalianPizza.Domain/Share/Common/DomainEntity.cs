namespace EdgeItalianPizza.Domain.Share.Common;

/// <summary>
/// Класс родитель для доменных моделей.
/// </summary>
public abstract class DomainEntity
{
    /// <summary>
    /// Идентификационный номер сущности
    /// </summary>
    public long Id { get; protected set; }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
