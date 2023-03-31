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

namespace Cafe.View.Measures
{
    /// <summary>
    /// Логика взаимодействия для MeasuresView.xaml
    /// </summary>
    public partial class MeasuresView : UserControl
    {
        public MeasuresView()
        {
            InitializeComponent();
            MeasuresList.Items.Add("sf");
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AppMainWindow.MainScreen.Content = new MainView();
        }

        private void InsertObject_Click(object sender, RoutedEventArgs e)
        {
            MeasuresList.Items.Add("sf");

        }
    }
}
