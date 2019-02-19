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
    public class PrinterDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(PrinterDAO));

        private MySqlConnection _conn;

        private const string TABLE_PRINTER_PRODUCT = "tb_printer_product";
        private const string TABLE_PRINTER = "tb_printer";
        private const string TABLE_PRINTER_LOG = "tb_printer_log";

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

        public int AddPrinter(string Name,string PrinterIP, string PritnerPort)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_PRINTER);
                stringSQL.Append(" (name, printer_ip, printer_port)");
                stringSQL.Append(" VALUES (@Name, @PrinterIP, @PritnerPort);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@PrinterIP", PrinterIP);
                cmd.Parameters.AddWithValue("@PritnerPort", PritnerPort);

                cmd.ExecuteNonQuery();
                DatabaseClose();


                log.Info("SmoothDataLayer -- AddPrinter Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddPrinter(): " + ex.Message);
                return -1;
            }
        }

        public int UpdatePrinter(int PrinterID, string Name)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_PRINTER);
                stringSQL.Append(" SET name = @Name");
                stringSQL.Append(" WHERE printer_id = @PrinterID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@PrinterID", PrinterID);
                cmd.Parameters.AddWithValue("@Name", Name);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- UpdatePrinter Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => UpdatePrinter(): " + ex.Message);
                return -1;
            }
        }

        public int RemovePrinter(int PrinterID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_PRINTER);
                stringSQL.Append(" SET is_active = 0");
                stringSQL.Append(" WHERE printer_id = @PrinterID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@PrinterID", PrinterID);
                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- RemovePrinter Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => RemovePrinter(): " + ex.Message);
                return -1;
            }
        }

        public DataTable GetListOfPrinter()
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("SELECT printer_id, name, printer_ip, printer_port ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_PRINTER);
                stringSQL.Append(" WHERE is_active = 1; ");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                DatabaseClose();
                log.Info("SmoothDataLayer -- GetListOfPrinter Success");
                return dt;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetListOfPrinter(): " + ex.Message);
                return null;
            }
        }

        public int AddPrinterProduct(int PrinterID, int ProdudctID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_PRINTER);
                stringSQL.Append(" (product_id, printer_id)");
                stringSQL.Append(" VALUES (@PrinterID, @ProdudctID);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@PrinterID", PrinterID);
                cmd.Parameters.AddWithValue("@ProdudctID", ProdudctID);

                cmd.ExecuteNonQuery();

                long tableID = cmd.LastInsertedId;
                DatabaseClose();

                int tID = (int)tableID;


                log.Info("SmoothDataLayer -- AddPrinterProduct Success");
                return tID;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddPrinterProduct(): " + ex.Message);
                return -1;
            }
        }

        public int RemovePrinterProduct(int PrinterID, int ProductID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("DELETE FROM ");
                stringSQL.Append(TABLE_PRINTER);
                stringSQL.Append(" WHERE product_id = @PrinterID AND printer_id = @ProductID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@PrinterID", PrinterID);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- RemovePrinterProduct Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => RemovePrinterProduct(): " + ex.Message);
                return -1;
            }
        }

        public int AddPrinterLog(int PrinterID, string DT, string stringJson)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_PRINTER_LOG);
                stringSQL.Append(" (printer_id, print_dt, printer_detail)");
                stringSQL.Append(" VALUES (@PrinterID, @DT, @stringJson);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@PrinterID", PrinterID);
                cmd.Parameters.AddWithValue("@DT", DT);
                cmd.Parameters.AddWithValue("@stringJson", stringJson);

                cmd.ExecuteNonQuery();
                DatabaseClose();


                log.Info("SmoothDataLayer -- AddPrinterLog Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddPrinterLog(): " + ex.Message);
                return -1;
            }
        }

        public DataTable GetListOfPrinterLog()
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("SELECT TOP 50 printer_log_id, printer_id, print_dt, printer_detail ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_PRINTER_LOG);
                stringSQL.Append(" ORDER BY printer_log_id DESC");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                DatabaseClose();
                log.Info("SmoothDataLayer -- GetListOfPrinterLog Success");
                return dt;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetListOfPrinterLog(): " + ex.Message);
                return null;
            }
        }

    }
}
