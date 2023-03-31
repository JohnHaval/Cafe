using Cafe.Models;
using Cafe.View.MeasuresViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cafe.Tools
{
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
                {//Products
                    //MainWindow.AppMainWindow.MainScreen.Content = new MeasuresControlView((Measures)((ListViewItem)sender).Content);
                }
                catch
                {//Checks
                    //MainWindow.AppMainWindow.MainScreen.Content = new MeasuresControlView((Measures)((ListViewItem)sender).Content);
                }
            }
        }
    }
}
