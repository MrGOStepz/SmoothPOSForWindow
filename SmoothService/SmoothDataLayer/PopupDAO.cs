using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        public int AddPopup(string Name, List<string> lstName, List<float> lstPrice, List<string> lstImagePath)
        {
            try
            {

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

                //cmd.ExecuteNonQuery();
                int popupID = Convert.ToInt32(cmd.ExecuteScalar());
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
                log.Info("SmoothDataLayer -- Add Product Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => AddProduct(): " + ex.Message);
                return -1;
            }
        }
    }
}
