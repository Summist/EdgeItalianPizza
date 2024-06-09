using EdgeItalianPizza.UI.Abstractions;
using EdgeItalianPizza.UI.Abstractions.Interfaces;
using EdgeItalianPizza.UI.Share.Informations;
using EdgeItalianPizza.UI.Share.Utilities;
using System.Windows.Input;

namespace EdgeItalianPizza.UI.MVVM.ViewModel;

internal sealed class CustomerViewModel(
    INavigationService navigation,
    INotifyNavigation toRegistration,
    INotifyNavigation toAuth) : ViewModelBase
{
    private INavigationService _navigation = navigation;
    /// <summary>
    /// Навигация между View.
    /// </summary>
    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged(nameof(Navigation));
        }
    }

    /// <summary>
    /// Комманда, срабатывающая при загрузке.
    /// </summary>
    public ICommand LoadCommand { get; private set; }

    protected override void InitializeComponents()
    {
        CustomerSessionInfo.OnInfoChanged += CustomerSessionInfo_OnInfoChanged;
        PersonalCabinetViewModel.OnNewPasswordClick += OnNewPassword;
        NewPasswordViewModel.OnBack += NavigateLogic;

        toRegistration.OnButtonClick += ToRegistrationView;
        toAuth.OnButtonClick += ToAuthView;

        LoadCommand = new RelayCommand(LoadCommandExecute);
    }

    private void OnNewPassword()
    {
        Navigation.NavigateTo<NewPasswordViewModel>();
    }

    private void CustomerSessionInfo_OnInfoChanged()
    {
        NavigateLogic();
    }

    private void ToAuthView()
    {
        Navigation.NavigateTo<CustomerAuthViewModel>();
    }

    private void ToRegistrationView()
    {
        Navigation.NavigateTo<CustomerRegViewModel>();
    }

    private void LoadCommandExecute(object obj)
    {
        NavigateLogic();
    }

    // TODO: Подумать над решением.
    private void NavigateLogic()
    {
        if (CustomerSessionInfo.IsAuth)
        {
            Navigation.NavigateTo<PersonalCabinetViewModel>();
        }
        else
        {
            Navigation.NavigateTo<CustomerAuthViewModel>();
        }
    }
}
