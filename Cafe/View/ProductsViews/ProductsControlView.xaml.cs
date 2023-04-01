using Cafe.Models;
using Cafe.Tools;
using Cafe.View.ProductsViews;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
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
    /// Логика взаимодействия для ProductsControlView.xaml
    /// </summary>
    public partial class ProductsControlView : UserControl
    {
        public ProductsControlView()
        {
            InitializeComponent();

            Measures.ItemsSource = DBContext.Context.Measures.Local.ToBindingList();
            Measures.SelectedIndex = 0;
        }
        public ProductsControlView(Products product)
        {
            InitializeComponent();

            Measures.ItemsSource = DBContext.Context.Measures.Local.ToBindingList();
            Measures.SelectedItem = product.Measures;

            ActionPicture.Source = new BitmapImage(new Uri("/Images/Update.png", UriKind.Relative));
            Title.Text = "Изменение товара";
            AddObject.Content = "Сохранить";
            SelectedProduct = product;

            ObjectName.Text = product.Name;
            Price.Text = product.Price.ToString("F2");
            HoldCount.Text = product.HoldCount.ToString();
        }

        Products SelectedProduct;

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AppMainWindow.MainScreen.Content = new ProductsView();
        }

        private void AddObject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DBContext.Context.Products == null)
                {
                    NotificationActions.NoComboList();
                    return;
                }
                int id = 1, count = 0;
                decimal price = 0;
                try
                {
                    id = DBContext.Context.Products.ToList().Max(p => p.ProductID) + 1;
                }
                catch { }
                try
                {
                    price = Convert.ToDecimal(Price.Text);
                    count = Convert.ToInt32(HoldCount.Text);
                }
                catch
                {
                    NotificationActions.IntError();
                    return;
                }
                if (SelectedProduct == null)
                {                    
                    DBContext.Context.Products.Add(new Products()
                    {
                        ProductID = id,
                        Name = ObjectName.Text,
                        Price = price,
                        HoldCount = count,
                        MeasureID = ((Measures)Measures.SelectedItem).MeasureID
                    });
                }
                else
                {
                    SelectedProduct.Name = ObjectName.Text;
                    SelectedProduct.Price = price;
                    SelectedProduct.HoldCount = count;
                    SelectedProduct.MeasureID = ((Measures)Measures.SelectedItem).MeasureID;
                }
                DBContext.Context.SaveChanges();
                MainWindow.AppMainWindow.MainScreen.Content = new ProductsView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ObjectName.Focus();
        }
    }
}
