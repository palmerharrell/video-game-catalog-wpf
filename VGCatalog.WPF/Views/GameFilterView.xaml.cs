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

namespace VGCatalog.WPF.Views
{
    /// <summary>
    /// Interaction logic for GameFilterView.xaml
    /// </summary>
    public partial class GameFilterView : UserControl
    {
        public GameFilterView()
        {
            InitializeComponent();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Remove this handler later
            var destinationurl = "https://github.com/palmerharrell/video-game-catalog-wpf/";
            var sInfo = new System.Diagnostics.ProcessStartInfo(destinationurl)
            {
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(sInfo);
        }
    }
}
