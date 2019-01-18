using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
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

namespace SmoothPOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lbTime.Content = DateTime.Now.ToLongTimeString();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();

            //System.Windows.Controls.Border
            Border UIProteries =  (Border)mainPanel.Children
                        .Cast<UIElement>()
                        .First(x => Grid.GetRow(x) == 0 && Grid.GetColumn(x) == 0);

            //Set UserControl Size
            TableControl tbControl = new TableControl();
            tbControl.Height = UIProteries.ActualHeight;
            tbControl.Width = UIProteries.ActualWidth;
            mainPanelLeft.Children.Add(tbControl);

            //Time
            DispatcherTimer dispatcherClockTimer = new DispatcherTimer();
            dispatcherClockTimer.Tick += DispatcherClockTimer_Tick;
            dispatcherClockTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherClockTimer.Start();

        }

        private void DispatcherClockTimer_Tick(object sender, EventArgs e)
        {
            lbTime.Content = DateTime.Now.ToLongTimeString();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }
    }
}
