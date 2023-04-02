using Cafe.Models;
using Cafe.Tools;
using Cafe.View.ChecksViews;
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

namespace Cafe.View.ChecksViews
{
    /// <summary>
    /// Логика взаимодействия для ChecksView.xaml
    /// </summary>
    public partial class ChecksView : UserControl
    {
        public ChecksView()
        {
            InitializeComponent();
            ChecksList.ItemsSource = DBContext.Context.Checks.Local.ToBindingList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AppMainWindow.MainScreen.Content = new MainView();
        }

        private void InsertObject_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AppMainWindow.MainScreen.Content = new ChecksControlView();
        }

        private void UpdateObject_Click(object sender, RoutedEventArgs e)
        {
            if (ChecksList.SelectedItem != null)
            {
                MainWindow.AppMainWindow.MainScreen.Content = new ChecksControlView((Checks)ChecksList.SelectedItem);
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
                if (ChecksList.SelectedItem != null)
                {
                    if (NotificationActions.GetRemoveResponse())
                    {
                        var check = (Checks)ChecksList.SelectedItem;
                        var purchases = DBContext.Context.Purchases.Where(p => p.CheckID == check.CheckID).ToList();
                        foreach (var item in purchases)
                        {
                            Products product = item.Products;//Получение для будущего возврата к остаткам
                            DBContext.Context.Purchases.Remove(item);

                            DBContext.Context.SaveChanges();

                            product.HoldCount++;//Возвращение в остатки

                            DBContext.Context.SaveChanges();
                        }
                        DBContext.Context.Checks.Remove(check);
                        DBContext.Context.SaveChanges();
                        ChecksList.Items.Refresh();
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

        private void ChecksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChecksList.SelectedItem != null)
            {
                PurchasesList.ItemsSource = ((Checks)ChecksList.SelectedItem).Purchases;
            }
            else PurchasesList.ItemsSource = null;
        }
    }
}
