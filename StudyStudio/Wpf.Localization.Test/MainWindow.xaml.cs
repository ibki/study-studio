using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Wpf.Localization.Test
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CultureInfoSwitchButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Resources.Culture = new CultureInfo((sender as Button).Tag?.ToString() ?? "");

            HelloWorldTextBlock.Text = Properties.Resources.HelloWorld;
        }

        private void ShowMainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}