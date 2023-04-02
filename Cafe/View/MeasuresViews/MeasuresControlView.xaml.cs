using Cafe.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Cafe.View.MeasuresViews
{
    /// <summary>
    /// Логика взаимодействия для MeasuresControlView.xaml
    /// </summary>
    public partial class MeasuresControlView : UserControl
    {
        public MeasuresControlView()
        {
            InitializeComponent();
        }
        public MeasuresControlView(Measures measure)
        {
            InitializeComponent();
            ActionPicture.Source = new BitmapImage(new Uri("/Images/Update.png", UriKind.Relative));
            Title.Text = "Изменение единицы измерения";
            AddObject.Content = "Сохранить";
            SelectedMeasure = measure;

            ObjectName.Text = measure.Name;
        }

        Measures SelectedMeasure;

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AppMainWindow.MainScreen.Content = new MeasuresView();
        }

        private void AddObject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedMeasure == null)
                {
                    int id = 1;
                    try
                    {
                        DBContext.Context.Measures.Load();
                        id = DBContext.Context.Measures.ToList().Max(p => p.MeasureID) + 1;
                    }
                    catch { }
                    DBContext.Context.Measures.Add(new Measures()
                    {
                        MeasureID = id,
                        Name = ObjectName.Text
                    });
                }
                else
                {
                    SelectedMeasure.Name = ObjectName.Text;
                }
                DBContext.Context.SaveChanges();
                MainWindow.AppMainWindow.MainScreen.Content = new MeasuresView();
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
