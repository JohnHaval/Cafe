using Cafe.Tools;
using Cafe.View;
using System.Windows;

namespace Cafe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppMainWindow = this;
            MainScreen.Content = new MainView();

            DBContext.UpdateContext();
        }
        public static MainWindow AppMainWindow;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = NotificationActions.WindowClosing();
        }
    }
}
