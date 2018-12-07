using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            if (loginForm._ExitApp == true)
            {
                this.Close();
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
