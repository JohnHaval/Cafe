using Cafe.Models;
using Cafe.Tools;
using Cafe.View.ChecksViews;
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

namespace Cafe.View.ChecksViews
{
    /// <summary>
    /// Логика взаимодействия для ChecksControlView.xaml
    /// </summary>
    public partial class ChecksControlView : UserControl
    {
        public ChecksControlView()
        {
            InitializeComponent();

            Products.ItemsSource = DBContext.Context.Products.Local.ToBindingList();
            Products.SelectedIndex = 0;
        }
        public ChecksControlView(Checks check)
        {
            InitializeComponent();

            Products.ItemsSource = DBContext.Context.Products.Local.ToBindingList();
            Products.SelectedIndex = 0;

            ActionPicture.Source = new BitmapImage(new Uri("/Images/Update.png", UriKind.Relative));
            Title.Text = "Изменение чека";
            InsertCheck.Content = "Сохранить";
            SelectedCheck = check;

            Cost.Text = check.Cost.ToString("F2");
            Discount.Text = check.Discount.ToString("F2");
            CostNDiscount.Text = check.CostNDiscount.ToString("F2");

            if (check.IsComplexLunch)
            {
                ComplexLunch.SelectedIndex = 1;
            }

            PurchasesList.ItemsSource = check.Purchases.ToList();
        }
        Checks SelectedCheck;
        bool IsNewCheck;

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AppMainWindow.MainScreen.Content = new ChecksView();
        }

        private void InsertObject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                long id = 1;
                int count = 0;
                try
                {
                    id = DBContext.Context.Purchases.ToList().Max(p => p.PurchaseID) + 1;
                }
                catch { }
                try
                {
                    count = Convert.ToInt32(ProductCount.Text);
                }
                catch
                {
                    NotificationActions.IntError();
                    return;
                }
                if (SelectedCheck == null) CreateNewCheck();
                DBContext.Context.Purchases.Add(new Purchases()
                {
                    PurchaseID = id,
                    CheckID = SelectedCheck.CheckID,
                    ProductID = ((Products)Products.SelectedItem).ProductID,
                    ProductCount = count
                });
                DBContext.Context.SaveChanges();

                DBContext.Context.Purchases.Load();
                PurchasesList.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoveObject_Click(object sender, RoutedEventArgs e)
        {
            if (PurchasesList.SelectedItem != null)
            {                
                //  C A L C U L A T E    DICSOUNT AND OTHER CHECK DATA!

                DBContext.Context.Purchases.Remove((Purchases)PurchasesList.SelectedItem);
                DBContext.Context.SaveChanges();

                DBContext.Context.Purchases.Load();
                PurchasesList.Items.Refresh();
            }
            else NotificationActions.NeedSelectBeforeRemove();
        }
        private void CreateNewCheck()
        {
            IsNewCheck = true;
            long id = 1;
            try
            {
                id = DBContext.Context.Checks.ToList().Max(p => p.CheckID) + 1;
            }
            catch { }
            SelectedCheck = new Checks()
            {
                CheckID = id
            };
        }
    }
}
