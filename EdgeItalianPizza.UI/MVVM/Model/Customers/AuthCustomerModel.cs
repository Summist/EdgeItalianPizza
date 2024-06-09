using EdgeItalianPizza.UI.Abstractions;

namespace EdgeItalianPizza.UI.MVVM.Model.Customers;

internal sealed class AuthCustomerModel : ObservableObject
{
    private long _id;
    /// <summary>
    /// Идентификационный номер покупателя.
    /// </summary>
    public long Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    private string _phoneNumber;
    /// <summary>
    /// Номер телефона покупателя.
    /// </summary>
    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            _phoneNumber = value;
            OnPropertyChanged(nameof(PhoneNumber));
        }
    }

    private DateOnly? _dateOfBirth;
    /// <summary>
    /// Дата рождения покупателя.
    /// </summary>
    public DateOnly? DateOfBirth
    {
        get => _dateOfBirth;
        set
        {
            _dateOfBirth = value;
            NotDateOfBirthHasValue = !value.HasValue;
            DateOfBirthHasValue = value.HasValue;
            OnPropertyChanged(nameof(DateOfBirth));
        }
    }

    private int _bonusCoins;
    /// <summary>
    /// Количество бонусных монет покупателя.
    /// </summary>
    public int BonusCoins
    {
        get => _bonusCoins;
        set
        {
            _bonusCoins = value;
            OnPropertyChanged(nameof(BonusCoins));
        }
    }

    private bool _dateOfBirthHasValue;
    public bool DateOfBirthHasValue
    {
        get => _dateOfBirthHasValue;
        set
        {
            _dateOfBirthHasValue = value;
            OnPropertyChanged(nameof(DateOfBirthHasValue));
        }
    }

    private bool _notDateOfBirthHasValue;
    public bool NotDateOfBirthHasValue
    {
        get => _notDateOfBirthHasValue;
        set
        {
            _notDateOfBirthHasValue = value;
            OnPropertyChanged(nameof(NotDateOfBirthHasValue));
        }
    }

    public AuthCustomerModel()
    {
        _notDateOfBirthHasValue = !DateOfBirth.HasValue;
        _dateOfBirthHasValue = DateOfBirth.HasValue;
    }
}
