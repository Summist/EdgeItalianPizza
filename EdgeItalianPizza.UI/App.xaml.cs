using EdgeItalianPizza.Application.DependencyInjection;
using EdgeItalianPizza.Infrastructure.Database.Data;
using EdgeItalianPizza.Infrastructure.DependencyInjection;
using EdgeItalianPizza.UI.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace EdgeItalianPizza.UI;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    private readonly IHost _host;

    public App()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        _host = Host
            .CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services
                    .ConfigureInfrastructure(configuration)
                    .ConfigureServices()
                    .ConfigureUI();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host!.StartAsync();

        MainWindow = _host.Services.GetRequiredService<MainWindow>();
        MainWindow.Show();

        var dbContext = _host.Services.GetRequiredService<ApplicationDbContext>();
        _ = dbContext.Model;

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host!.StopAsync();
        _host.Dispose();

        base.OnExit(e);
    }
}

