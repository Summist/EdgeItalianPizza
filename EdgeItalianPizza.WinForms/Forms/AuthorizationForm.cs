using EdgeItalianPizza.Application.DTOs;
using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Application.Services;
using EdgeItalianPizza.Infrastructrure.SqlServer.Data;
using EdgeItalianPizza.Infrastructrure.SqlServer.Repositories;
using EdgeItalianPizza.WinForms.Services;

namespace EdgeItalianPizza.WinForms.Forms;

public partial class AuthorizationForm : Form
{
    private readonly AppDbContext _dbContext;
    private readonly ILoggerService _loggerService;

    public AuthorizationForm()
    {
        InitializeComponent();

        _dbContext = new();
        _loggerService = new FileLoggerService();
    }

    private void AuthorizationForm_Load(object sender, EventArgs e)
    {
        passwordTextBox.UseSystemPasswordChar = true;
    }

    private async void EntryButton_Click(object sender, EventArgs e)
    {
        string login = loginTextBox.Text;
        string password = passwordTextBox.Text;

        var userRepository = new UserRepository(_dbContext);
        var userService = new UserService(userRepository, _loggerService);

        var loginValidateService = new LoginValidateService();
        var passwordValidateService = new PasswordValidateService();

        var hashService = new HashService();

        UserDto? searchedUser = await userService.GetAuthorization(
            login,
            password,
            loginValidateService,
            passwordValidateService,
            hashService);

        if (searchedUser is null)
        {
            MessageBox.Show("Пользователь не найден.", "Уведомление");
            return;
        }

        MessageBox.Show("Операция прошла успешно", "Уведомление");
    }

    private void RegistrationLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        var registrationForm = new RegistrationForm(_dbContext, _loggerService);

        Hide();
        registrationForm.ShowDialog();
        Show();
    }
}
