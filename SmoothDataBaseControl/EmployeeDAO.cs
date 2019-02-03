using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDataBaseControl
{
    public class EmployeeDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeDAO));

        private MySqlConnection _conn;

        private const string TABLE_EMPLOYEE = "tb_employee";


        private void DatabaseOpen()
        {
            string connectionPath = ConfigurationManager.ConnectionStrings["SmoothDB"].ConnectionString;
            //string connectionPath = ConfigurationManager.AppSettings["SmoothDB"].ToString();
            //string connectionPath = "server=localhost;user id=root;persistsecurityinfo=True;database=smoothdb;password=G4856162651O;";

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
        public int UpdateProfileEmployee(int EmployeeID, string FirstName, string LastName, string NickName, string Phone, string Email, string password)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();
                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_EMPLOYEE);
                stringSQL.Append("SET (first_name = @firstName, last_name = @lastName, nick_name = @nickName, phone = @phone, email = @email)");
                stringSQL.Append(" WHERE employee_id = @employeeID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@firstName", FirstName);
                cmd.Parameters.AddWithValue("@lastName", LastName);
                cmd.Parameters.AddWithValue("@phone", Phone);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@employeeID", EmployeeID);
                cmd.Parameters.AddWithValue("@nickName", NickName);

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
                stringSQL.Append("SELECT first_name, last_name, nick_name, phone, email, level_id, status_id ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_EMPLOYEE + ";");
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
                stringSQL.Append(" WHERE password LIKE '@password';");

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

        public DataTable GetEmployeeDetailByPassword(string Password)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("SELECT employee_id, first_name, last_name, nick_name, phone, email, level_id, status_id ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_EMPLOYEE);
                stringSQL.Append(" WHERE password LIKE @Password");


                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@Password", Password);

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);


                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                cmd.Dispose();
                DatabaseClose();

                log.Info("Get Employee Detail Success");

                return dt;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => GetEmployeeDetailByPassword(): " + ex.Message);
                return null;
            }

        }

        public int UpdateStaffStatus(int staffID, int statusID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();
                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_EMPLOYEE);
                stringSQL.Append(" SET status_id = @statusID");
                stringSQL.Append(" WHERE employee_id = @employeeID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@statusID", statusID);
                cmd.Parameters.AddWithValue("@employeeID", staffID);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => UpdateStaffStatus(): " + ex.Message);
                return -1;
            }
        }

        public int CheckStaffStatus(int staffID)
        {
            try
            {
                int statusID = 0;
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("SELECT status_id ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_EMPLOYEE);
                stringSQL.Append(" WHERE employee_id = @employeeID;");


                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@employeeID", staffID);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //name of column
                    statusID = (int)reader["status_id"];
                }
                cmd.Dispose();
                DatabaseClose();

                log.Info("Get Employee Status Success");

                return statusID;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => GetEmployeeDetailByPassword(): " + ex.Message);
                return -1;
            }
        }
    }
}
