using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TestingService
{
    public partial class Testing : Form
    {
        //private EmployeeService.EmployeeServiceClient _em = new EmployeeService.EmployeeServiceClient();
        private EmployeeServiceTest.EmployeeServiceClient _em = new EmployeeServiceTest.EmployeeServiceClient();

        public Testing()
        {
            InitializeComponent();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            var employeeDetail = new { FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Phone = txtPhone.Text,
                Password = txtPassword.Text };
           
            string json = JsonConvert.SerializeObject(employeeDetail);
            _em.AddNewEmployeeDetail(json);
            //_em.AddNewEmployee(json);
        }

        private void Testing_Load(object sender, EventArgs e)
        {
            string strJSON = _em.GetListOfEmployee();

            DataTable dt = (DataTable)JsonConvert.DeserializeObject(strJSON, (typeof(DataTable)));
            dgvListOfEmployee.DataSource = dt;
        }
    }
}
