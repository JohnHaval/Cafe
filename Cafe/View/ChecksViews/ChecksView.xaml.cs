using Cafe.Models;
using Cafe.Tools;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            RefreshAll();
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
                        foreach (var item in check.Purchases.ToList())
                        {
                            DBContext.Context.Purchases.Remove(item);
                        }
                        DBContext.Context.Checks.Remove(check);
                        DBContext.Context.SaveChanges();
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
            RefreshAll();
        }

        private void ChecksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChecksList.SelectedItem != null)
            {
                PurchasesList.ItemsSource = ((Checks)ChecksList.SelectedItem).Purchases;
            }
            else PurchasesList.ItemsSource = null;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text.Count() != 0)
            {
                foreach (var item in ChecksList.Items)
                {
                    var check = (Checks)item;
                    if (check.CheckID.ToString().Contains(Search.Text) ||
                        check.CostNDiscount.ToString().Contains(Search.Text))
                    {
                        ChecksList.SelectedItem = item;
                        ChecksList.ScrollIntoView(item);
                        return;
                    }
                }
                ChecksList.SelectedIndex = -1;
            }
            else ChecksList.SelectedIndex = -1;
        }

        private void RefreshTable_Click(object sender, RoutedEventArgs e)
        {
            RefreshAll();
        }
        private void RefreshAll()
        {
            DBContext.Context.Checks.Load();
            DBContext.Context.Purchases.Load();
            ChecksList.ItemsSource = null;
            ChecksList.ItemsSource = DBContext.Context.Checks.Local.ToBindingList();
        }
    }
}
