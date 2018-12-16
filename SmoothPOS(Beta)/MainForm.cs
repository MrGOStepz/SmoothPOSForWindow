using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;

namespace SmoothPOS_Beta_
{
    public partial class MainForm : Form
    {
        TableControl _tableControl;
        PayControl _payControl;

        public MainForm()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            InitializeComponent();
            InitializeForm();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Check Database Service
            if (ServiceStatus.Stopped == DatabaseServiceStatus(GlobalHelper.DatabaseServiceName))
            {
                MessageBox.Show("Service Running");
            }

            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            if (loginForm._ExitApp == true)
            {
                this.Close();
            }
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

        private void InitializeForm()
        {
            _tableControl = new TableControl();
            _payControl = new PayControl();

            _tableControl.Name = "TableControl";
            _payControl.Name = "PayControl";

            fillPanel.Controls.Clear();
            fillPanel.Controls.Add(_tableControl);

            lbTime.Text = "";
            tClock.Tick += TClock_Tick;
            tClock.Interval = 1000;
            tClock.Enabled = true;
            tClock.Start();
        }

        private void TClock_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            GlobalHelper.EmployeeDetail = null;

            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();

            if (loginForm._ExitApp == true)
            {
                this.Close();
            }
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            fillPanel.Controls.Clear();
            fillPanel.Controls.Add(_tableControl);
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            fillPanel.Controls.Clear();
            fillPanel.Controls.Add(_payControl);
        }

        private void btnBackOffice_Click(object sender, EventArgs e)
        {
            BackForm backForm = new BackForm();
            backForm.Show();
        }
    }
}
