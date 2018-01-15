using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace SmoothDataLayer
{
    public class EmployeeDAO
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

        /// <summary>
        /// Add New Employee
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Phone"></param>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int AddNewEmployee(string FirstName, string LastName, string Phone, string Email, string Password)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_EMPLOYEE);
                stringSQL.Append(" (first_name, last_name, phone, email, password)");
                stringSQL.Append(" VALUES (@FirstName, @LastName, @Phone, @Email, @Password);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@firstName", FirstName);
                cmd.Parameters.AddWithValue("@lastName", LastName);
                cmd.Parameters.AddWithValue("@phone", Phone);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@password", Password);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- Add Employee Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => AppNewEmployee(): " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Update Profile Employee by Employee ID
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Phone"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public int UpdateProfileEmployee(int EmployeeID, string FirstName, string LastName, string Phone, string Email, string password)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();
                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_EMPLOYEE);
                stringSQL.Append("SET (first_name = @firstName, last_name = @lastName, phone = @phone, email = @email)");
                stringSQL.Append(" WHERE employee_id = @employeeID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@firstName", FirstName);
                cmd.Parameters.AddWithValue("@lastName", LastName);
                cmd.Parameters.AddWithValue("@phone", Phone);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@employeeID", EmployeeID);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("Update Profile Employee Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => UpdateProfileEmployee(): " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Get All Data Table Employee
        /// </summary>
        /// <returns></returns>
        public DataTable GetListOfEmployee()
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("SELECT * ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_EMPLOYEE +";");
                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                //If you want data for coloumn
                //MySqlDataReader reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{
                //                              name of column
                //    EmployeeID = (int)reader["employee_id"];
                //}

                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                DatabaseClose();

                log.Info("Get List Of Employee Success");

                return dt;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => ListOfEmployee(): " + ex.Message);
                return null;
            }
        }
        public bool FindData(string password, string command)
        {
            bool ret = false;
            try
            {
                StringBuilder stringSQL = new StringBuilder();
                DatabaseOpen();
                stringSQL.Append("SELECT * ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_EMPLOYEE);
                stringSQL.Append(" WHERE password = @password;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@password", password);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                
                ret = true;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => FindData(): " + ex.Message);
            }
            log.Info("Log in Status ret = " + ret);
            return ret;
        }
    }
}
