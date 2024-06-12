using EdgeItalianPizza.UI.Abstractions;

namespace EdgeItalianPizza.UI.Share.Informations;

/// <summary>
/// Информация о сессии покупателя.
/// </summary>
internal static class CustomerSessionInfo
{
    /// <summary>
    /// Событие, оповещающее о авторизации заведения.
    /// </summary>
    public static Action OnInfoChanged;

    /// <summary>
    /// Информация о том авторизован ли пользователь или нет.
    /// </summary>
    public static bool IsAuth => Customer is not null;

    private static CustomerSession _customer = null;
    /// <summary>
    /// Данные о пользователе
    /// </summary>
    public static CustomerSession Customer
    {
        get => _customer;
        set
        {
            _customer = value;
            OnInfoChanged?.Invoke();
        }
    }
}

/// <summary>
/// Данные покупателя.
/// </summary>
internal sealed class CustomerSession : ObservableObject
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

    public CustomerSession(DateOnly? DateOfBirth)
    {
        _notDateOfBirthHasValue = DateOfBirth.HasValue;
        _dateOfBirthHasValue = !DateOfBirth.HasValue;
    }
}