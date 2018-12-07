using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock_IO
{
    public partial class MainForm : Form
    {
        public static Employee _employee;

        public MainForm()
        {
            InitializeComponent();
            InitializeLayout();
            InitializeData();
        }

        private void InitializeData()
        {
            DataTable dt = new DataTable();
            DatabaseHandle dbHandle = new DatabaseHandle();

            dt = dbHandle.ListOfUser();

            
            cbName.DisplayMember = "first_name";
            cbName.ValueMember = "employee_id";
            cbName.DataSource = dt;
        }


        private void InitializeLayout()
        {
            btnClockIn.Enabled = false;
            btnClockOut.Enabled = false;

            lbCreateStatus.Text = "";
            lbStatus.Text = "";

            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DatabaseHandle dbHandle = new DatabaseHandle();
            _employee = new Employee();
            _employee = dbHandle.CheckUser(txtPW.Text);

            if (_employee.Name != null)
            {
                lbStatus.Text = "Welcome " + _employee.Name;

                if (_employee.ClockInStatus == 2)
                {
                    SetButtonClockIn(true);

                }
                else
                {
                    SetButtonClockIn(false);
                }

            }
            else
            {
                lbStatus.Text = "Wrong Password!";
            }


        }

        private void SetButtonClockIn(bool Login)
        {
            if (Login == true)
            {
                btnClockIn.Enabled = true;
                btnClockOut.Enabled = false;
            }
            else
            {
                btnClockIn.Enabled = false;
                btnClockOut.Enabled = true;
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            DatabaseHandle dbHandle = new DatabaseHandle();

            if(txtCreatePW.Text != txtCFPW.Text)
            {
                lbCreateStatus.Text = "PW not match";
            }
            else
            {
               if(dbHandle.AddNewEmployee(txtCreateName.Text, txtCFPW.Text) > 0 )
                {
                    lbCreateStatus.Text = "Create Complete!";
                }
            }
        }

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            DatabaseHandle dbHandle = new DatabaseHandle();

            if (_employee != null)
            {
                if (dbHandle.AddEmployeeTime(_employee.Name) > 0)
                {
                    if (dbHandle.UpdateUserStatus(_employee.EmployeeID, 1) > 0)
                    {
                        txtPW.Text = "";
                        btnClockIn.Enabled = false;
                        btnClockOut.Enabled = false;
                        _employee = null;
                    }
                    

                }

            }
            else
            {
                lbStatus.Text = "Please Login";
            }

            
        }

        private void btnClockOut_Click(object sender, EventArgs e)
        {
            DatabaseHandle dbHandle = new DatabaseHandle();

            if(_employee.Name != null)
            {
                if(dbHandle.UpdateClockOut(_employee.Name) > 0)
                {
                    if (dbHandle.UpdateUserStatus(_employee.EmployeeID, 2) > 0)
                    {
                        txtPW.Text = "";
                        lbStatus.Text = "Good Bye " + _employee.Name;
                        _employee = null;
                        btnClockIn.Enabled = false;
                        btnClockOut.Enabled = false;
                    }
                }
            }
            else
            {
                lbStatus.Text = "Pease Login";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {


            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintDialog pdi = new PrintDialog();

            PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();

            //// preview the assigned document or you can create a different previewButton for it
            //printPrvDlg.Document = printDoc;
            //printPrvDlg.ShowDialog();

            pdi.Document = printDoc;
            printDoc.Print();
            

        }

        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DatabaseHandle dbHandle = new DatabaseHandle();
            DateTime dtFrom = new DateTime();
            DateTime dtTo = new DateTime();

            dtFrom = dtpFrom.Value;
            dtTo = dtpEnd.Value;

            List<EmployeeTimeSheet> lstEmployeeTimeSheets = new List<EmployeeTimeSheet>();
            lstEmployeeTimeSheets = dbHandle.GetEmployeeTimeSheet(cbName.Text, dtFrom, dtTo);

            try
            {
                int y = 0;
                long totalTime = 0;
                if (lstEmployeeTimeSheets != null && lstEmployeeTimeSheets.Count != 0)
                {
                    e.Graphics.DrawString(lstEmployeeTimeSheets[0].Name + " | " + dtFrom.ToShortDateString() + " - " + dtTo.ToShortDateString(), new Font("Arial", 10), Brushes.Black, 5, 5, new StringFormat());

                    for (int i = 0; i < lstEmployeeTimeSheets.Count; i++)
                    {
                        long timeTick = lstEmployeeTimeSheets[i].DateTo.Ticks - lstEmployeeTimeSheets[i].DateFrom.Ticks;
                        totalTime += timeTick;
                        TimeSpan elapsedSpan = new TimeSpan(timeTick);
                        e.Graphics.DrawString(lstEmployeeTimeSheets[0].DateTo.ToShortDateString() + " | " + lstEmployeeTimeSheets[i].DateFrom.ToShortTimeString() + " - " + lstEmployeeTimeSheets[i].DateTo.ToShortTimeString() + " | " + String.Format("{0} hr, {1} m", 
                   elapsedSpan.Hours, elapsedSpan.Minutes), new Font("Arial", 7), Brushes.Black, 5, 10 + ((i+1)*13), new StringFormat());
                        y = 10 + ((i + 1) * 15);
                    }

                    TimeSpan eSpan = new TimeSpan(totalTime);
                    e.Graphics.DrawString("Total " + String.Format("{0} hr, {1} m", eSpan.Hours, eSpan.Minutes), new Font("Arial", 8), Brushes.Black, 5, y + 8, new StringFormat());
                }


            }
            catch (Exception)
            {

            }
        }
    }
}
