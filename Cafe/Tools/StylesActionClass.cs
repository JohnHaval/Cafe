using Cafe.Models;
using Cafe.View.ChecksViews;
using Cafe.View.MeasuresViews;
using Cafe.View.ProductsViews;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cafe.Tools
{
    /// <summary>
    /// Класс стилей для изменения объекта из списка двойным кликом
    /// </summary>
    public partial class StylesActionClass
    {
        private void MeasuresList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                MainWindow.AppMainWindow.MainScreen.Content = new MeasuresControlView((Measures)((ListViewItem)sender).Content);
            }
            catch
            {
                try
                {
                    MainWindow.AppMainWindow.MainScreen.Content = new ProductsControlView((Products)((ListViewItem)sender).Content);
                }
                catch
                {
                    try
                    {
                        MainWindow.AppMainWindow.MainScreen.Content = new ChecksControlView((Checks)((ListViewItem)sender).Content);
                    }
                    catch { }
                }
            }
        }
    }
}
