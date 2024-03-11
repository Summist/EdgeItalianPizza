using EdgeItalianPizza.Application.DTOs;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Application.Services;
using EdgeItalianPizza.Infrastructrure.SqlServer.Data;
using EdgeItalianPizza.Infrastructrure.SqlServer.Repositories;
using EdgeItalianPizza.WPF.Client.Services;
using System.Windows;
using System.Windows.Input;

namespace EdgeItalianPizza.WPF.Client.Windows.Auth;
/// <summary>
/// Логика взаимодействия для AuthorizationWindow.xaml
/// </summary>
public partial class AuthorizationWindow : Window
{
    private readonly AppDbContext _dbContext;
    private readonly ILoggerService _logger;

    public AuthorizationWindow()
    {
        InitializeComponent();

        _dbContext = new();
        _logger = new FileLoggerService();
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        System.Windows.Application.Current.Shutdown();
    }

    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        System.Windows.Application.Current.MainWindow.WindowState = WindowState.Minimized;
    }

    private async void EntryButton_Click(object sender, RoutedEventArgs e)
    {
        entryErrorLabel.Content = string.Empty;

        string login = loginTextBox.Text;
        string password = passwordTextBox.Text;

        var customerRepository = new CustomerRepository(_dbContext);

        var loginValidateService = new LoginValidateService(this);
        var passwordValidateService = new PasswordValidateService(this);

        var hashService = new HashService();

        var customerService = new CustomerService(customerRepository, _logger);

        AuthorizationUserDto searchedUser = await customerService.GetAuthorization(
            login,
            password,
            loginValidateService,
            passwordValidateService,
            hashService);

        if (searchedUser.Status == -1)
            return;
        else if (searchedUser.Status == 0)
        {
            entryErrorLabel.Content = "Пользователь не найден.";
            return;
        }
    }

    private void LoginTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        loginErrorLabel.Text = string.Empty;
    }

    private void PasswordTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        passwordErrorLabel.Text = string.Empty;
    }
}
