using EdgeItalianPizza.UI.Abstractions.Interfaces;
using System.ComponentModel;

namespace EdgeItalianPizza.UI.Abstractions;

internal abstract class ValidatableModel : ObservableObject, IDataErrorInfo, ICanBeValidate
{
    protected string[] _columnNames = [];

    public string this[string columnName] => IsValid(columnName);
    public string Error => string.Empty;

    public virtual bool IsValid()
    {
        if (!_columnNames.Any())
            throw new ArgumentException($"{nameof(_columnNames)} должен быть заполнен");

        return _columnNames.All(columnName => string.IsNullOrWhiteSpace(IsValid(columnName)));
    }

    protected abstract string IsValid(string columnName);
}
