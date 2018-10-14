using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDataLayer
{
    public class PopupDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeDAO));

        private MySqlConnection _conn;

        private const string TABLE_POPUP = "tb_popup";
        private const string TABLE_POPUP_ITEM = "tb_popup_item";

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

        /// <summary>
        /// Add Popup Table and List PopupTable
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="lstName">List of name SubPopup</param>
        /// <param name="lstPrice">List of price Subpopup</param>
        /// <param name="lstImagePath">List of Path image</param>
        /// <returns></returns>
        public int AddPopup(string Name, List<string> lstName, List<float> lstPrice, List<string> lstImagePath)
        {
            try
            {
                //Check They are equal
                if(lstName.Count != lstPrice.Count && lstPrice.Count != lstImagePath.Count && lstName.Count != lstImagePath.Count)
                {
                    return -1;
                }

                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_POPUP);
                stringSQL.Append(" (name)");
                stringSQL.Append(" VALUES (@Name);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@Name", Name);

                cmd.ExecuteNonQuery();

                long popupID = cmd.LastInsertedId;
                DatabaseClose();

                DatabaseOpen();
                for (int i = 0; i < lstName.Count; i++)
                {
                    stringSQL = new StringBuilder();
                    stringSQL.Append("INSERT INTO ");
                    stringSQL.Append(TABLE_POPUP_ITEM);
                    stringSQL.Append(" (popup_id, name, price, image_path)");
                    stringSQL.Append(" VALUES (@PopupID, @Name, @Price, @ImagePath);");

                    cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                    cmd.Parameters.AddWithValue("@PopupID", popupID);
                    cmd.Parameters.AddWithValue("@Name", lstName[i]);
                    cmd.Parameters.AddWithValue("@Price", lstPrice[i]);
                    cmd.Parameters.AddWithValue("@ImagePath", lstImagePath[i]);

                    cmd.ExecuteNonQuery();
                }

                DatabaseClose();
                log.Info("SmoothDataLayer -- Add Popup Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddPopup(): " + ex.Message);
                return -1;
            }
        }


        public int UpdatePopup(int PopupID, string Name, List<int> lstSupPopupID, List<string> lstName, List<float> lstPrice, List<string> lstImagePath)
        {
            try
            {

                if (lstName.Count != lstPrice.Count && lstPrice.Count != lstImagePath.Count && lstName.Count != lstImagePath.Count)
                {
                    return -1;
                }

                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_POPUP);
                stringSQL.Append(" SET name = @Name");
                stringSQL.Append(" WHERE popup_id = @PopupID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@PopupID", PopupID);

                cmd.ExecuteNonQuery();

                DatabaseClose();

                DatabaseOpen();
                for (int i = 0; i < lstSupPopupID.Count; i++)
                {
                    stringSQL = new StringBuilder();
                    stringSQL.Append("UPDATE ");
                    stringSQL.Append(TABLE_POPUP_ITEM);
                    stringSQL.Append(" SET name = @Name, popup_id = @PopupID, price = @Price, image_path = @ImagePath");
                    stringSQL.Append(" WHERE popup_item_id = @SupPopupID");

                    cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                    cmd.Parameters.AddWithValue("@SupPopupID", lstSupPopupID[i]);
                    cmd.Parameters.AddWithValue("@Name", lstName[i]);
                    cmd.Parameters.AddWithValue("@Price", lstPrice[i]);
                    cmd.Parameters.AddWithValue("@ImagePath", lstImagePath[i]);
                    cmd.Parameters.AddWithValue("@PopupID", PopupID);

                    cmd.ExecuteNonQuery();
                }

                DatabaseClose();
                log.Info("SmoothDataLayer -- Update Popup Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => UpdatePopup(): " + ex.Message);
                return -1;
            }
        }

        public int DeletePopup(int PopupID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("DELECT FORM ");
                stringSQL.Append(TABLE_POPUP_ITEM);
                stringSQL.Append(" WHERE popup_id = @PopupID;");

                stringSQL.Append("DELECT FORM ");
                stringSQL.Append(TABLE_POPUP);
                stringSQL.Append(" WHERE popup_id = @PopupID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@PopupID", PopupID);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- Update Popup Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => UpdatePopup(): " + ex.Message);
                return -1;
            }
        }

        public DataTable GetListOfPopup()
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();
                
                DatabaseOpen();

                stringSQL.Append("SELECT popup_id, name ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_POPUP + ";");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                DatabaseClose();
                log.Info("SmoothDataLayer -- GetListOfPopup Success");
                return dt;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetListOfPopup(): " + ex.Message);
                return null;
            }
        }

        public DataTable GetListOfPopupFilter(string name)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("SELECT popup_id, name ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_POPUP);
                stringSQL.Append(" WHERE name LIKE @Name;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@Name", "%"+name+"%");

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                DatabaseClose();
                log.Info("SmoothDataLayer -- GetLisOfPopupFilter Success");
                return dt;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetLisOfPopupFilter(): " + ex.Message);
                return null;
            }
        }
    }
}
