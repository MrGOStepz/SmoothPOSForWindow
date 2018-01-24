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
    public class PrinterDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeDAO));
        private MySqlConnection _conn;

        private const string TABLE_ORDER = "tb_order";

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

        public DataTable GetListForPrint(int orderNo, string prtLocation)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("SELECT * ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_ORDER);
                stringSQL.Append(" WHERE order_id = @order_id;");
                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@order_id", orderNo);

                cmd.ExecuteNonQuery();

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
                log.Error("DataLayer => GetCustomerByPhoneNumber(): " + ex.Message);
                return null;
            }
        }
        //public GetListForPrint(orderDetailModel.OrderID, prtLocation)
        //{

        //}
    }
}
