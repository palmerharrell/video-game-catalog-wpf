using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VGCatalog.WPF.Components
{
    /// <summary>
    /// Interaction logic for SearchingOverlay.xaml
    /// </summary>
    public partial class SearchingOverlay : UserControl
    {
        public SearchingOverlay()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && e.ClickCount != 2)
            {
                var mainWindow = Application.Current.MainWindow;

                if (mainWindow.WindowState == WindowState.Maximized)
                {
                    mainWindow.WindowState = WindowState.Normal;
                    mainWindow.Top = 0;
                    mainWindow.Left = e.GetPosition(this).X - Width / 2;
                }

                mainWindow.DragMove();
            }
        }
    }
}
