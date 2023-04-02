﻿using Cafe.Models;
using Cafe.View.ChecksViews;
using Cafe.View.MeasuresViews;
using Cafe.View.ProductsViews;
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
