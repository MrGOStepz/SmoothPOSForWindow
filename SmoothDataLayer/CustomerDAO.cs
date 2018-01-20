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
    public class CustomerDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeDAO));

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
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNo"></param>
        /// <param name="address"></param>
        /// <param name="lastActive"></param>
        /// <param name="cardNo"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public int AddNewCustomer(string firstName,
            string lastName,
            int phoneNo,
            string address,
            string lastActive,
            string dateTime,
            int cardNo,
            string email)
        {
            int ret = 0;
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_CUSTOMER);
                stringSQL.Append(" (first_name, last_name, phone, address, last_active, dob, card, email)");
                stringSQL.Append(" VALUES (@firstName, @lastName, @phoneNo, @address, @lastActive, @dateTime, @cardNo, @Email);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@phoneNo", phoneNo);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@lastActive", lastActive);
                cmd.Parameters.AddWithValue("@dateTime", dateTime);
                cmd.Parameters.AddWithValue("@cardNo", cardNo);
                cmd.Parameters.AddWithValue("@email", email);

                cmd.ExecuteNonQuery();

                DatabaseClose();

                log.Info("DataLayer :: Add Customer Success");
                ret = 1;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer :: AppNewCustomer(): " + ex.Message);
                ret = -1;
            }

            return ret;
        }

        public int UpdateCustomer(int customerId,
            string firstName,
            string lastName,
            int    phoneNo,
            string address,
            int    totalOrder,
            string lastActive,
            string dob,
            int    cardNo,
            string email)
        {
            int ret = 0;

            try
            {

                StringBuilder stringSQL = new StringBuilder();
                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_CUSTOMER);
                stringSQL.Append(" SET first_name = @firstName, last_name = @lastName, phone = @phoneNo, address = @address, total_order = @totalOrder, last_active = @lastActive, dob = @dob, card = @cardNo, email = @email");
                //stringSQL.Append(" SET total_order = @totalOrder");
                stringSQL.Append(" WHERE customer_id = @customerID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@customerID", customerId);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@phoneNo", phoneNo);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@totalOrder", totalOrder);
                cmd.Parameters.AddWithValue("@lastActive", lastActive);
                cmd.Parameters.AddWithValue("@dob", dob);
                cmd.Parameters.AddWithValue("@cardNo", cardNo);
                cmd.Parameters.AddWithValue("@email", email);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("Update Customer Detail Success");
                ret = 1;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => UpdateProfileEmployee(): " + ex.Message);
                ret = -1;
            }

            return ret;
        }

        public int GetListOfCustomer()
        {
            int ret = 0;

            return ret;
        }

        public DataTable GetCustomerByPhoneNumber(int phoneNo)
        {
            DataTable dt=null;

            try
            {
                StringBuilder stringSQL = new StringBuilder();
                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);

                DatabaseOpen();

                stringSQL.Append("SELECT * ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_CUSTOMER);
                stringSQL.Append(" WHERE phone = @phoneNo;");
     
                cmd.Parameters.AddWithValue("@phoneNo", phoneNo);

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
                log.Error("DataLayer => GetCustomerByPhoneNumber(): " + ex.Message);
            }

            return dt;
        }


    }
}
