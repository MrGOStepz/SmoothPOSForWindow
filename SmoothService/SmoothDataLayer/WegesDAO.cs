using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDataLayer
{
    public class WegesDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeDAO));

        private MySqlConnection _conn;

        private const string TABLE_EMPLOYEE = "tb_employee";


        private void DatabaseOpen()
        {
            string connectionPath = "server=localhost;port=3310;user id=root;persistsecurityinfo=True;database=smoothdb;password=JuJ90507;";
            //string connectionPath = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            _conn = new MySqlConnection(connectionPath);
            _conn.Open();
        }

        private void DatabaseClose()
        {
            _conn.Close();
        }

        public DataTable GetListOfWeges()
        {
            try
            {
                DataTable dt = new DataTable();

                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
