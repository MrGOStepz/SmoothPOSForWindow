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
        public MainForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
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
            this.Close();
        }
    }
}
