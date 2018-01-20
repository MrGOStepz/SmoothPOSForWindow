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
    public class OrderDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeDAO));

        private MySqlConnection _conn;

        private const string TABLE_ORDER = "tb_order";
        private const string TABLE_ORDERTYPE = "tb_order_type";
        private const string TABLE_ORDERSTATUS = "tb_order_status";
        private const string TABLE_ORDERDETAIL = "tb_order_detail";

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

        public int AddNewOrder( string orderDateTime, 
                                int orderTypeID, 
                                int employeeID, 
                                int table, 
                                int orderStatusID, 
                                int paymentID, 
                                int customerID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_ORDER);
                stringSQL.Append(" (order_at, order_type_id, employee_id, table_no, order_status_id, payment_id, customer_id)");
                stringSQL.Append(" VALUES (@orderDateTime, @orderTypeID, @employeeID, @table, @orderStatusID, @paymentID, @customerID);");

                log.Info(stringSQL);

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@orderDateTime", orderDateTime);
                cmd.Parameters.AddWithValue("@orderTypeID", orderTypeID);
                cmd.Parameters.AddWithValue("@employeeID", employeeID);
                cmd.Parameters.AddWithValue("@table", table);
                cmd.Parameters.AddWithValue("@orderStatusID", orderStatusID);
                cmd.Parameters.AddWithValue("@paymentID", paymentID);
                cmd.Parameters.AddWithValue("@customerID", customerID);

                log.Info(stringSQL);
                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- Add Order Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => AppNewOrder(): " + ex.Message);
                return -1;
            }
        }

        public int AddOrderDetail(int productID,
                        int popUpItemID,
                        int orderID,
                        int productQty,
                        float amount,
                        string comment)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_ORDERDETAIL);
                stringSQL.Append(" (product_id, popup_item_id, order_id, product_qty, amount, comment)");
                stringSQL.Append(" VALUES (@productID, @popUpItemID, @orderID, @productQty, @amount, @comment);");

                log.Info(stringSQL);

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@productID", productID);
                cmd.Parameters.AddWithValue("@orderID", orderID);
                cmd.Parameters.AddWithValue("@popUpItemID", popUpItemID);
                cmd.Parameters.AddWithValue("@productQty", productQty);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@comment", comment);

                log.Info(stringSQL);
                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- Add Order Detail Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => AppNewOrder(): " + ex.Message);
                return -1;
            }
        }

        public DataTable GetListOfATable(string tableName)
        {
            DataTable dt = null;
            string TABLE_NAME = tableName;

            if (TABLE_NAME != null)
            {
                try
                {
                    StringBuilder stringSQL = new StringBuilder();

                    DatabaseOpen();
                    stringSQL.Append("SELECT * ");
                    stringSQL.Append("FROM ");
                    stringSQL.Append(TABLE_NAME + ";");
                    MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                    DataTable dt_temp = new DataTable();
                    adp.Fill(dt_temp);
                    cmd.Dispose();
                    DatabaseClose();

                    log.Info("DataLayer :: Get List Of GetListOrderType"+TABLE_NAME);

                    dt = dt_temp;
                }
                catch (Exception ex)
                {
                    log.Error("DataLayer :: GetListOrderType(): " +TABLE_NAME+ ex.Message);
                }
            }
            return dt;
        }
    }
}
