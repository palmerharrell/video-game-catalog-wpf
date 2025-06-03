using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace VGCatalog.WPF.Components
{
    /// <summary>
    /// Interaction logic for TitleBar.xaml
    /// </summary>
    public partial class TitleBar : UserControl
    {
        public TitleBar()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void btnMaximizeAndRestore_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow;

            if (mainWindow.WindowState == WindowState.Normal)
            {
                mainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                mainWindow.WindowState = WindowState.Normal;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow;

            if (e.LeftButton == MouseButtonState.Pressed && e.ClickCount != 2)
            {

                if (mainWindow.WindowState == WindowState.Maximized)
                {
                    mainWindow.WindowState = WindowState.Normal;
                    mainWindow.Top = 0;
                    mainWindow.Left = e.GetPosition(mainWindow).X - Width / 2;
                }

                mainWindow.DragMove();
            }
            else
            {
                if (e.LeftButton == MouseButtonState.Pressed && e.ClickCount == 2)
                {
                    if (mainWindow.WindowState == WindowState.Normal)
                    {
                        mainWindow.WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        mainWindow.WindowState = WindowState.Normal;
                    }
                }
            }
        }
    }
}
