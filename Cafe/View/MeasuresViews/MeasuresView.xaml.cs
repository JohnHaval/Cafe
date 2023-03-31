using Cafe.Models;
using Cafe.Tools;
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
            MeasuresList.ItemsSource = DBContext.Context.Measures.Local.ToBindingList();
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
                        MeasuresList.Items.Refresh();
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
    }
}
