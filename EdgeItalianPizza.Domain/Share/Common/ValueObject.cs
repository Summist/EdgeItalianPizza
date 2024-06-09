namespace EdgeItalianPizza.Domain.Share.Common;

/// <summary>
/// Иммутабельный тип, значение которого задается при создании и не меняется на протяжении всей жизни объекта.
/// </summary>
public abstract class ValueObject
{
    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;

        if (GetType() != obj.GetType())
            return false;

        var valueObject = (ValueObject)obj;

        return GetEqualityObjects().SequenceEqual(valueObject.GetEqualityObjects());
    }

    public override int GetHashCode()
        => GetEqualityObjects().Aggregate(default(int), (hashcode, value)
            => HashCode.Combine(hashcode, value.GetHashCode()));

    public static bool operator ==(ValueObject? a, ValueObject? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(ValueObject a, ValueObject b)
        => !(a == b);

    protected abstract IEnumerable<object> GetEqualityObjects();
}
