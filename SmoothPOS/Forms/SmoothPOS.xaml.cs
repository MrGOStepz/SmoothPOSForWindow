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
using System.ServiceProcess;
using Newtonsoft.Json;

namespace SmoothPOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Border _UIProperies;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGlobalHelper();
            lbTime.Content = DateTime.Now.ToLongTimeString();
            Loaded += MainWindow_Loaded;
            _UIProperies = (Border)mainPanel.Children
                        .Cast<UIElement>()
                        .First(x => Grid.GetRow(x) == 0 && Grid.GetColumn(x) == 0);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Check Database Service
            try
            {
                if (ServiceStatus.Stopped == DatabaseServiceStatus(Setting.DatabaseServiceName))
                {
                    MessageBox.Show("Service is running");
                }

                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
                            
                //Set UserControl Size
                TableControl tbControl = new TableControl();
                tbControl.Height = _UIProperies.ActualHeight;
                tbControl.Width = _UIProperies.ActualWidth;
                mainPanelLeft.Children.Add(tbControl);
                
                //Time
                DispatcherTimer dispatcherClockTimer = new DispatcherTimer();
                dispatcherClockTimer.Tick += DispatcherClockTimer_Tick;
                dispatcherClockTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherClockTimer.Start();
                
            }
            catch (Exception ex)
            {
                //TODO Exception Service
                MessageBox.Show(ex.Message);
            }
        }
        
        private void InitializeGlobalHelper()
        {
            DatabaseHandle dbHandle = new DatabaseHandle();
            GlobalHelper.SectionDetail = JsonConvert.DeserializeObject<List<SectionModel>>(dbHandle.GetListOfSection());
            GlobalHelper.TableDetail = JsonConvert.DeserializeObject<List<TableModal>>(dbHandle.GetListTable());
            GlobalHelper.LocationMenuDetail = JsonConvert.DeserializeObject<List<LocationMenuModel>>(dbHandle.GetListLocationMenu());
            GlobalHelper.LocationTabDetail = JsonConvert.DeserializeObject<List<LocationTabModel>>(dbHandle.GetListOfLocationTab());
        }

        private ServiceStatus DatabaseServiceStatus(string serviceName)
        {
            //Change Service is running
            ServiceController sc = new ServiceController(serviceName);

            switch (sc.Status)
            {
                //case ServiceControllerStatus.Running:
                //    return ServiceStatus.Running;
                case ServiceControllerStatus.Stopped:
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running);
                    return ServiceStatus.Stopped;
                //case ServiceControllerStatus.Paused:
                //    return ServiceStatus.Paused;
                //case ServiceControllerStatus.StopPending:
                //    return ServiceStatus.Stoping;
                //case ServiceControllerStatus.StartPending:
                //    return ServiceStatus.Starting;
                default:
                    return ServiceStatus.Changing;
            }
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

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            mainPanelLeft.Children.Clear();
            TableControl tbControl = new TableControl();
            tbControl.Height = _UIProperies.ActualHeight;
            tbControl.Width = _UIProperies.ActualWidth;
            mainPanelLeft.Children.Add(tbControl);
        }

        private void BtnCookStatus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnResendOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnReprintReceipt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
