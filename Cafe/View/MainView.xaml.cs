using System.Windows;
using System.Windows.Controls;

namespace Cafe.View
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AppMainWindow.MainScreen.Content = new ProductsViews.ProductsView();
        }

        private void Checks_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AppMainWindow.MainScreen.Content = new ChecksViews.ChecksView();
        }

        private void Measures_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AppMainWindow.MainScreen.Content = new MeasuresViews.MeasuresView();
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик программы: Лопаткин Сергей Михайлович (GitHub.Name = \"JohnHaval\")\n\n" +
                "Наименование программы: Кафе-столовая\n" +
                "Кодовое наименование: Cafe\n" +
                "Версия: 1.0", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AppMainWindow.Close();
        }
    }
}
