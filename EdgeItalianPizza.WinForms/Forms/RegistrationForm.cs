using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Infrastructrure.SqlServer.Data;

namespace EdgeItalianPizza.WinForms.Forms;
public partial class RegistrationForm : Form
{
    private readonly AppDbContext _dbContext;
    private readonly ILoggerService _loggerService;

    public RegistrationForm(AppDbContext dbContext, ILoggerService loggerService)
    {
        InitializeComponent();

        _dbContext = dbContext;
        _loggerService = loggerService;
    }
}
