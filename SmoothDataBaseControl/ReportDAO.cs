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
    public class ReportDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ReportDAO));

        private MySqlConnection _conn;

        private const string TABLE_ORDER = "tb_order";
        private const string TABLE_ORDER_DETAIL = "tb_order_detail";

        private void DatabaseOpen()
        {
            string connectionPath = ConfigurationManager.ConnectionStrings["SmoothDB"].ConnectionString;
            _conn = new MySqlConnection(connectionPath);
            _conn.Open();
        }

        private void DatabaseClose()
        {
            _conn.Close();
        }

        public int AddOrder(string OrderDT, int OrderType, int EmployeeID, int TableID, int OrderStatusID, int Payment_ID, int CustomerID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_ORDER);
                stringSQL.Append(" (order_at, order_type_id, employee_id, table, order_status_id, payment_id, customer_id)");
                stringSQL.Append(" VALUES (@OrderDT, @OrderType, @EmployeeID, @TableID, @OrderStatusID, @Payment_ID, @CustomerID);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@OrderDT", OrderDT);
                cmd.Parameters.AddWithValue("@OrderType", OrderType);
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                cmd.Parameters.AddWithValue("@TableID", TableID);
                cmd.Parameters.AddWithValue("@OrderStatusID", OrderStatusID);
                cmd.Parameters.AddWithValue("@Payment_ID", Payment_ID);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                cmd.ExecuteNonQuery();
                long AddOrderID = cmd.LastInsertedId;
                DatabaseClose();


                log.Info("SmoothDataLayer -- AddOrder Success");
                return (int)AddOrderID;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddOrder(): " + ex.Message);
                return -1;
            }
        }

        public int UpdateOrder(int OrderID, string OrderDT, int OrderType, int EmployeeID, int TableID, int OrderStatusID, int Payment_ID, int CustomerID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_ORDER);
                stringSQL.Append(" SET order_at = @OrderDT, order_type_id = @OrderType, employee_id = @EmployeeID, table = @TableID, order_status_id = @OrderStatusID, payment_id = @Payment_ID, customer_id = @CustomerID");
                stringSQL.Append(" WHERE order_id = @OrderID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                cmd.Parameters.AddWithValue("@OrderDT", OrderDT);
                cmd.Parameters.AddWithValue("@OrderType", OrderType);
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                cmd.Parameters.AddWithValue("@TableID", TableID);
                cmd.Parameters.AddWithValue("@OrderStatusID", OrderStatusID);
                cmd.Parameters.AddWithValue("@Payment_ID", Payment_ID);
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);


                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- UpdateOrder Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => UpdateOrder(): " + ex.Message);
                return -1;
            }
        }

        public int DeleteOrder(int OrderID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("DELETE FROM ");
                stringSQL.Append(TABLE_ORDER);
                stringSQL.Append(" WHERE order_id = @OrderID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- DeleteOrder Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => DeleteOrder(): " + ex.Message);
                return -1;
            }
        }

        public DataTable GetListOfOrder()
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("SELECT  order_id, order_at, order_type_id, employee_id, table, order_status_id, payment_id, customer_id ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_ORDER);
                stringSQL.Append(" ORDER BY order_id DESC");


                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                DatabaseClose();
                log.Info("SmoothDataLayer -- GetListOfOrder Success");
                return dt;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetListOfOrder(): " + ex.Message);
                return null;
            }
        }

        public DataTable GetListOfOrderByFilter(string Column, string Name)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("SELECT  order_id, order_at, order_type_id, employee_id, table, order_status_id, payment_id, customer_id ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_ORDER);
                stringSQL.Append(" WHERE @Column LIKE @Name");
                stringSQL.Append(" ORDER BY order_id DESC");


                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@Column", Column);
                cmd.Parameters.AddWithValue("@Name", Name);

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                

                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                DatabaseClose();
                log.Info("SmoothDataLayer -- GetListOfOrder Success");
                return dt;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetListOfOrder(): " + ex.Message);
                return null;
            }
        }

        public int AddOrderDetail(int ProductID, int PopupItemID, int OrderID, int ProductQty, float Amount, string Comment, int CookStatus)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_ORDER_DETAIL);
                stringSQL.Append(" (product_id, popup_item_id, order_id, product_qty, amount, comment, cook_status)");
                stringSQL.Append(" VALUES (@ProductID, @PopupItemID, @OrderID, @ProductQty, @Amount, @Comment, @CustomerID);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@PopupItemID", PopupItemID);
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                cmd.Parameters.AddWithValue("@ProductQty", ProductQty);
                cmd.Parameters.AddWithValue("@Amount", Amount);
                cmd.Parameters.AddWithValue("@Comment", Comment);
                cmd.Parameters.AddWithValue("@CookStatus", CookStatus);

                cmd.ExecuteNonQuery();
                DatabaseClose();


                log.Info("SmoothDataLayer -- AddOrder Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddOrder(): " + ex.Message);
                return -1;
            }
        }

        public int UpdateOrderDetailCookStatus(int OrderID, int ProductID, int CookStatus)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_ORDER_DETAIL);
                stringSQL.Append(" SET cook_status = @CookStatus");
                stringSQL.Append(" WHERE product_id = @ProductID AND order_id = @OrderID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@CookStatus", CookStatus);


                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- UpdateSectionStable Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => UpdateSectionStable(): " + ex.Message);
                return -1;
            }
        }

        public int UpdateOrderDetail(int OrderDetailID, int ProductID, int PopupItemID, int OrderID, int ProductQty, float Amount, string Comment, int CookStatus)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_ORDER_DETAIL);
                stringSQL.Append(" SET product_id = @ProductID, popup_item_id = @PopupItemID, order_id = @OrderID, product_qty = @ProductQty, amount = @Amount, comment = @Comment, cook_status = @CookStatus");
                stringSQL.Append(" WHERE order_detail_id = @OrderDetailID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@OrderDetailID", OrderDetailID);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@PopupItemID", PopupItemID);
                cmd.Parameters.AddWithValue("@OrderID", OrderID);
                cmd.Parameters.AddWithValue("@ProductQty", ProductQty);
                cmd.Parameters.AddWithValue("@Amount", Amount);
                cmd.Parameters.AddWithValue("@Comment", Comment);
                cmd.Parameters.AddWithValue("@CookStatus", CookStatus);


                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- UpdateSectionStable Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => UpdateSectionStable(): " + ex.Message);
                return -1;
            }
        }

        public int DeleteOrderDetail(int OrderDetailID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("DELETE FROM ");
                stringSQL.Append(TABLE_ORDER_DETAIL);
                stringSQL.Append(" WHERE order_detail_id = @OrderDetailID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@OrderDetailID", OrderDetailID);
                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- DeleteOrderDetail Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => DeleteOrderDetail(): " + ex.Message);
                return -1;
            }
        }

    }
}
