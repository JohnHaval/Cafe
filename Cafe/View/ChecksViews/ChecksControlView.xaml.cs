using Cafe.Models;
using Cafe.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
            InsertCheck.Content = "Сохранить чек";
            SelectedCheck = check;

            Cost.Text = check.Cost.ToString("F2");
            Discount.Text = check.Discount.ToString("F2");
            CostNDiscount.Text = check.CostNDiscount.ToString("F2");

            if (check.IsComplexLunch)
            {
                ComplexLunch.SelectedIndex = 1;
            }

            PurchasesList.ItemsSource = check.Purchases.ToList();

            Purchases = check.Purchases.ToList();
        }

        Checks SelectedCheck;
        List<Purchases> Purchases = new List<Purchases>();
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBContext.UpdateContext();

                MainWindow.AppMainWindow.MainScreen.Content = new ChecksView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InsertObject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                long id = 1;
                int count = 0;
                try
                {
                    DBContext.Context.Purchases.Load();
                    id = DBContext.Context.Purchases.ToList().Max(p => p.PurchaseID) + 1;
                }
                catch { }
                try
                {
                    if (id <= Purchases.Max(p => p.PurchaseID)) id = Purchases.Max(p => p.PurchaseID) + 1;
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
                if (!CheckActions.HasHoldCount((Products)Products.SelectedItem, count))
                {
                    NotificationActions.NoHoldCount();
                    return;
                }
                if (SelectedCheck == null) CreateNewCheck();

                var purchase = new Purchases()
                {
                    PurchaseID = id,
                    CheckID = SelectedCheck.CheckID,
                    ProductID = ((Products)Products.SelectedItem).ProductID,
                    ProductCount = count
                };

                Purchases.Add(purchase);

                DBContext.Context.Purchases.Add(purchase);

                ((Products)Products.SelectedItem).HoldCount -= count;//Списание товара с остатков

                UpdateDisplayedData();

                if (PurchasesList.ItemsSource != null) PurchasesList.ItemsSource = null;
                PurchasesList.ItemsSource = Purchases;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoveObject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PurchasesList.SelectedItem != null)
                {
                    Products product = ((Purchases)PurchasesList.SelectedItem).Products;//Получение для будущего возврата к остаткам

                    Purchases.Remove((Purchases)PurchasesList.SelectedItem);

                    DBContext.Context.Purchases.Remove((Purchases)PurchasesList.SelectedItem);

                    product.HoldCount++;//Возвращение в остатки

                    UpdateDisplayedData();

                    if (PurchasesList.ItemsSource != null) PurchasesList.ItemsSource = null;
                    PurchasesList.ItemsSource = Purchases;

                }
                else NotificationActions.NeedSelectBeforeRemove();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void CreateNewCheck()
        {
            try
            {
                long id = 1;
                try
                {
                    DBContext.Context.Checks.Load();
                    id = DBContext.Context.Checks.ToList().Max(p => p.CheckID) + 1;
                }
                catch { }
                SelectedCheck = new Checks()
                {
                    CheckID = id,
                    Cost = 0,
                    Discount = 0,
                    CostNDiscount = 0,
                    IsComplexLunch = false
                };
                DBContext.Context.Checks.Add(SelectedCheck);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InsertCheck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBContext.Context.SaveChanges();

                MainWindow.AppMainWindow.MainScreen.Content = new ChecksView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Обновление отображаемых данных
        /// </summary>
        private void UpdateDisplayedData()
        {
            try
            {
                decimal cost = CalculateMainCost();
                SelectedCheck.Cost = cost;
                SelectedCheck.Discount = CheckActions.GetDiscount(cost);

                if (ComplexLunch.SelectedIndex == 0)
                {
                    SelectedCheck.CostNDiscount = SelectedCheck.Cost - SelectedCheck.Discount;
                }
                else
                {
                    SelectedCheck.Discount = 0;
                    SelectedCheck.CostNDiscount = SelectedCheck.Cost;
                }
                Cost.Text = SelectedCheck.Cost.ToString("F2");
                Discount.Text = SelectedCheck.Discount.ToString("F2");
                CostNDiscount.Text = SelectedCheck.CostNDiscount.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Рассчитывает стоимость всех товаров
        /// </summary>
        /// <returns>Стоимость всех товаров</returns>
        private decimal CalculateMainCost()
        {
            try
            {
                decimal mainCost = 0;
                foreach (var item in Purchases)
                {
                    mainCost += item.ProductCost;
                }
                return mainCost;
            }
            catch
            {
                return 0;
            }
        }

        private void ComplexLunch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedCheck != null)
            {
                if (ComplexLunch.SelectedIndex == 0)
                {
                    SelectedCheck.Discount = CheckActions.GetDiscount(SelectedCheck.Cost);
                    SelectedCheck.CostNDiscount = SelectedCheck.Cost - SelectedCheck.Discount;
                    SelectedCheck.IsComplexLunch = false;

                }
                else
                {
                    SelectedCheck.Discount = 0;
                    SelectedCheck.CostNDiscount = SelectedCheck.Cost;
                    SelectedCheck.IsComplexLunch = true;
                }
                Discount.Text = SelectedCheck.Discount.ToString("F2");
                CostNDiscount.Text = SelectedCheck.CostNDiscount.ToString("F2");
            }
        }
    }
}
