using Cafe.Models;
using Cafe.Tools;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Cafe.View.MeasuresViews
{
    /// <summary>
    /// Логика взаимодействия для MeasuresView.xaml
    /// </summary>
    public partial class MeasuresView : UserControl
    {
        public MeasuresView()
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
            MainWindow.AppMainWindow.MainScreen.Content = new MeasuresControlView();
        }

        private void UpdateObject_Click(object sender, RoutedEventArgs e)
        {
            if (MeasuresList.SelectedItem != null)
            {
                MainWindow.AppMainWindow.MainScreen.Content = new MeasuresControlView((Measures)MeasuresList.SelectedItem);
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
                if (MeasuresList.SelectedItem != null)
                {
                    if (NotificationActions.GetRemoveResponse())
                    {
                        DBContext.Context.Measures.Remove((Measures)MeasuresList.SelectedItem);
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

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text.Count() != 0)
            {
                foreach (var item in MeasuresList.Items)
                {
                    var measure = (Measures)item;
                    if (measure.MeasureID.ToString().Contains(Search.Text) ||
                        measure.Name.Contains(Search.Text))
                    {
                        MeasuresList.SelectedItem = item;
                        MeasuresList.ScrollIntoView(item);
                        return;
                    }
                }
                MeasuresList.SelectedIndex = -1;
            }
            else MeasuresList.SelectedIndex = -1;
        }

        private void RefreshTable_Click(object sender, RoutedEventArgs e)
        {
            RefreshAll();
        }
        private void RefreshAll()
        {
            DBContext.Context.Measures.Load();
            MeasuresList.ItemsSource = null;
            MeasuresList.ItemsSource = DBContext.Context.Measures.Local.ToBindingList();
        }
    }
}
