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

namespace Cafe.View.Checks
{
    /// <summary>
    /// Логика взаимодействия для ChecksView.xaml
    /// </summary>
    public partial class ChecksView : UserControl
    {
        public ChecksView()
        {
            InitializeComponent();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AppMainWindow.MainScreen.Content = new MainView();
        }
    }
}
