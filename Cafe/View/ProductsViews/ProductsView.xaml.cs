using Cafe.Models;
using Cafe.Tools;
using Cafe.View.ProductsViews;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Cafe.View.ProductsViews
{
    /// <summary>
    /// Логика взаимодействия для ProductsView.xaml
    /// </summary>
    public partial class ProductsView : UserControl
    {
        public ProductsView()
        {
            InitializeComponent();
            ProductsList.ItemsSource = DBContext.Context.Products.Local.ToBindingList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AppMainWindow.MainScreen.Content = new MainView();
        }

        private void InsertObject_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AppMainWindow.MainScreen.Content = new ProductsControlView();
        }

        private void UpdateObject_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsList.SelectedItem != null)
            {
                MainWindow.AppMainWindow.MainScreen.Content = new ProductsControlView((Products)ProductsList.SelectedItem);
            }
            else
            {
                NotificationActions.NeedSelectForUpdate();
            }
        }

        private void RemoveObject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ProductsList.SelectedItem != null)
                {
                    if (NotificationActions.GetRemoveResponse())
                    {
                        DBContext.Context.Products.Remove((Products)ProductsList.SelectedItem);
                        DBContext.Context.SaveChanges();
                        ProductsList.Items.Refresh();
                    }
                }
                else
                {
                    NotificationActions.NeedSelectBeforeRemove();
                }
            }
            catch
            {
                NotificationActions.KeyProblem();
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text.Count() != 0)
            {
                foreach (var item in ProductsList.Items)
                {
                    var product = (Products)item;
                    if (product.ProductID.ToString().Contains(Search.Text) ||
                        product.Name.Contains(Search.Text))
                    {
                        ProductsList.SelectedItem = item;
                        ProductsList.ScrollIntoView(item);
                        return;
                    }
                }
                ProductsList.SelectedIndex = -1;
            }
            else ProductsList.SelectedIndex = -1;
        }
    }
}
