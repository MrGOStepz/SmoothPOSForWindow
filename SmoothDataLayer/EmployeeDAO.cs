using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;

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
        public int AddNewEmployee(string FirstName, string LastName, string Phone, string Email, int Password)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                string hash = CalculateMD5Hash(Password);

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
                cmd.Parameters.AddWithValue("@password", hash);

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
        public int UpdateProfileEmployee(int EmployeeID, string FirstName, string LastName, string Phone, string Email, int password)
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
        public DataTable FindData(int password, string command)
        {
            DataTable dt = null;
            try
            {
                StringBuilder stringSQL = new StringBuilder();
                string hash = CalculateMD5Hash(password);

                DatabaseOpen();
                stringSQL.Append("SELECT * ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_EMPLOYEE);
                stringSQL.Append(" WHERE password = @password;");
                

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@password", hash);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataTable dt_temp = new DataTable();
                adp.Fill(dt_temp);
                cmd.Dispose();
                DatabaseClose();

                log.Info("CustomerDAO :: Get Customer Data By phone number:: Success");
                dt = dt_temp;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => FindData(): " + ex.Message);
            }
            //log.Info("Log in Status ret = " + ret);
            return dt;
        }

        public string CalculateMD5Hash(int input)

        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            string string_temp = input.ToString();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(string_temp);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
