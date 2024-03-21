using EdgeItalianPizza.Application.Interfaces;
using EdgeItalianPizza.Application.Services;
using EdgeItalianPizza.Infrastructrure.SqlServer.Data;
using EdgeItalianPizza.WPF.Client.MVVM.Model;
using EdgeItalianPizza.WPF.Client.MVVM.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace EdgeItalianPizza.WPF.Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILoggerService _logger;
        private UserModel _user;

        public MainWindow()
        {
            InitializeComponent();

            _logger = new FileLoggerService();
            _user = new();

            DataContext = new NavigationViewModel(_logger);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
