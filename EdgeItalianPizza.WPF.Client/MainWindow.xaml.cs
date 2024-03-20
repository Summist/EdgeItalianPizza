using EdgeItalianPizza.WPF.Client.Pages;
using System.Windows;
using System.Windows.Input;

namespace EdgeItalianPizza.WPF.Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            frame.Content = new PizzasPage();
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

        private void PizzasButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new PizzasPage();
        }

        private void ComboButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new ComboPage();
        }

        private void PersonalCabinetButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new PersonalCabinetPage();
        }

        private void BasketButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new BasketPage();
        }
    }
}
