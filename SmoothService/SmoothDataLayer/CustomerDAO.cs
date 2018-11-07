using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDataLayer
{
    public class CustomerDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CustomerDAO));

        private MySqlConnection _conn;

        private const string TABLE_CUSTOMER = "tb_customer";


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
        public int AddNewCustomer(string FirstName, string LastName, string Phone, string Address, string LastActive, string DOB,string Email)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_CUSTOMER);
                stringSQL.Append(" (first_name, last_name, phone, address, last_active, dob, email)");
                stringSQL.Append(" VALUES (@FirstName, @LastName, @Phone, @Address, @LastActive, @DOB, @Email);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@LastActive", LastActive);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@Email", Email);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- Add Customer Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => AddNewCustomer(): " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Phone"></param>
        /// <param name="Address"></param>
        /// <param name="LastActive"></param>
        /// <param name="DOB"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public int UpdateProfileCustomer(int CustomerID, string FirstName, string LastName, string Phone, string Address,int TotalOrder, string DOB, string Email)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();
                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_CUSTOMER);
                stringSQL.Append("SET (first_name = @FirstName, last_name = @LastName, phone = @Phone, address = @Address, total_order = @TotalOrder, dob = @DOB, email = @Email)");
                stringSQL.Append(" WHERE customer_id = @CustomerID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@TotalOrder", TotalOrder);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("Update Profile Customer Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => UpdateProfileCustomer(): " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Get All Data Table Employee
        /// </summary>
        /// <returns></returns>
        public DataTable GetListOfCustomer()
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("SELECT customer_id, first_name, last_name, phone, address, total_order, last_active, dob, email ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_CUSTOMER + ";");
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

                log.Info("Get List Of Customer Success");

                return dt;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => GetListOfCustomer(): " + ex.Message);
                return null;
            }
        }
        public bool GetListOfCustomerFilter(string name, string column)
        {
            bool ret = false;
            try
            {
                StringBuilder stringSQL = new StringBuilder();
                DatabaseOpen();
                stringSQL.Append("SELECT customer_id, first_name, last_name, phone, address, total_order, last_active, dob, email ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_CUSTOMER);
                stringSQL.Append(" WHERE password LIKE '@password';");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                //cmd.Parameters.AddWithValue("@password", password);

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
