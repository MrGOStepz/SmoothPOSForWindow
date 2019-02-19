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
    public class TableDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(PopupDAO));

        private MySqlConnection _conn;

        private const string TABLE_TABLE_SECTION = "tb_table_section";
        private const string TABLE_SECTION = "tb_section";

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

        public int AddSectionTable(string Name)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_SECTION);
                stringSQL.Append(" (name)");
                stringSQL.Append(" VALUES (@Name);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@Name", Name);

                cmd.ExecuteNonQuery();
                DatabaseClose();

                
                log.Info("SmoothDataLayer -- AddSectionTable Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddTable(): " + ex.Message);
                return -1;
            }
        }

        public int UpdateSectiontable(int SectionID, string Name)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_TABLE_SECTION);
                stringSQL.Append(" SET name = @Name");
                stringSQL.Append(" WHERE section_id = @SectionID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@SectionID", SectionID);
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

        public int RemoveSectionTable(int SectionID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_TABLE_SECTION);
                stringSQL.Append(" SET is_active = 0");
                stringSQL.Append(" WHERE section_id = @SectionID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@SectionID", SectionID);
                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- RemoveSectionTable Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => RemoveSectionTable(): " + ex.Message);
                return -1;
            }
        }

        public DataTable GetListOfSection()
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("SELECT section_id, name, is_active ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_TABLE_SECTION);
                stringSQL.Append(" WHERE is_active = 1; ");

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

        public int AddTable(string UName, string Name, int SectionID, float MarginTop, float MarginBot, float MarginLeft, float MarginRight)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_TABLE_SECTION);
                stringSQL.Append(" (u_name, name, section_id, margin_top, margin_bottom, margin_right, margin_left, height, width, is_active)");
                stringSQL.Append(" VALUES (@UName, @Name, @SectionID, @MarginTop, @MarginBot, @MarginLeft, @MarginRight, 75, 75, 1);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@UName", UName);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@SectionID", SectionID);
                cmd.Parameters.AddWithValue("@MarginTop", MarginTop);
                cmd.Parameters.AddWithValue("@MarginBot", MarginBot);
                cmd.Parameters.AddWithValue("@MarginLeft", MarginLeft);
                cmd.Parameters.AddWithValue("@MarginRight", MarginRight);

                cmd.ExecuteNonQuery();

                long tableID = cmd.LastInsertedId;
                DatabaseClose();

                int tID = (int)tableID;

                
                log.Info("SmoothDataLayer -- AddTable Success");
                return tID;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddTable(): " + ex.Message);
                return -1;
            }
        }

        public int UpdateTable(int TableID, float MarginTop, float MarginBot, float MarginLeft, float MarginRight)
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

        public int RemoveTable(int TableID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("DELETE FROM ");
                stringSQL.Append(TABLE_TABLE_SECTION);
                stringSQL.Append(" WHERE table_section_id = @TableID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@TableID", TableID);

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

        public DataTable GetListTable()
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("SELECT table_section_id, u_name, name, section_id, margin_top, margin_bottom, margin_right, margin_left, height, width, is_active ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_TABLE_SECTION + ";");

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
