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
    public class LocationDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(LocationDAO));

        private MySqlConnection _conn;

        private const string TABLE_LOCATION_MENU = "tb_location_menu";
        private const string TABLE_LOCATION_TAB = "tb_location_tab";

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

        public int AddLocationTab(string Name)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_LOCATION_TAB);
                stringSQL.Append(" (name)");
                stringSQL.Append(" VALUES (@Name);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@Name", Name);

                cmd.ExecuteNonQuery();
                DatabaseClose();

                
                log.Info("SmoothDataLayer -- AddLocationTab Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddLocationTab(): " + ex.Message);
                return -1;
            }
        }

        public int UpdateLocationTab(int LocationTabID, string Name)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_LOCATION_TAB);
                stringSQL.Append(" SET name = @Name");
                stringSQL.Append(" WHERE location_tab_id = @LocationTabID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@LocationTabID", LocationTabID);
                cmd.Parameters.AddWithValue("@Name", Name);


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

        public int RemoveLocationTab(int LocationTabID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_LOCATION_TAB);
                stringSQL.Append(" SET is_active = 0");
                stringSQL.Append(" WHERE location_tab_id = @LocationTabID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@LocationTabID", LocationTabID);
                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- RemoveLocationTab Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => RemoveLocationTab: " + ex.Message);
                return -1;
            }
        }

        public DataTable GetListOfLocationTab()
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("SELECT location_tab_id, name, is_active ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_LOCATION_TAB);
                stringSQL.Append(" WHERE is_active = 1; ");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                DatabaseClose();
                log.Info("SmoothDataLayer -- GetListOfLocationTab Success");
                return dt;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetListOfLocationTab(): " + ex.Message);
                return null;
            }
        }

        public int AddLocationMenu(int ProductID, int LocationTabID, int Column, int Row)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_LOCATION_MENU);
                stringSQL.Append(" (product_id, location_tab_id, column_no, row_no)");
                stringSQL.Append(" VALUES (@ProductID, @LocationTabID, @Column, @Row);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@LocationTabID", LocationTabID);
                cmd.Parameters.AddWithValue("@Column", Column);
                cmd.Parameters.AddWithValue("@Row", Row);

                cmd.ExecuteNonQuery();

                long tableID = cmd.LastInsertedId;
                DatabaseClose();

                int tID = int.Parse(tableID);

                
                log.Info("SmoothDataLayer -- AddLocationMenu Success");
                return tID;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddLocationMenu: " + ex.Message);
                return -1;
            }
        }

        //TODO Review
        public int UpdateLocationMenu(int TableID, float MarginTop, float MarginBot, float MarginLeft, float MarginRight)
        {
            try
            {

                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_TABLE_SECTION);
                stringSQL.Append(" SET margin_top = @MarginTop, margin_bottom = @MarginBot, margin_right = @MarginRight, margin_left = @MarginLeft");
                stringSQL.Append(" WHERE table_section_id = @TableID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@TableID", TableID);
                cmd.Parameters.AddWithValue("@MarginTop", MarginTop);
                cmd.Parameters.AddWithValue("@MarginBot", MarginBot);
                cmd.Parameters.AddWithValue("@MarginLeft", MarginLeft);
                cmd.Parameters.AddWithValue("@MarginRight", MarginRight);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- UpdateTable Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => UpdateTable(): " + ex.Message);
                return -1;
            }
        }

        public int RemoveLocationMenu(int LocationMenuID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("DELETE FROM ");
                stringSQL.Append(TABLE_LOCATION_MENU);
                stringSQL.Append(" WHERE location_menu_id = @LocationMenuID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@LocationMenuID", LocationMenuID);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- RemoveTable Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => RemoveTable(): " + ex.Message);
                return -1;
            }
        }

        public DataTable GetListLocationMenu()
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("SELECT location_menu_id, product_id, location_tab_id, column_on, row_on ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_LOCATION_MENU + ";");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                DatabaseClose();
                log.Info("SmoothDataLayer -- GetListTable Success");
                return dt;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetListTable(): " + ex.Message);
                return null;
            }
        }
    }

}
