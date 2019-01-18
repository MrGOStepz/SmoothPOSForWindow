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
    public class IngredientDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(IngredientDAO));

        private MySqlConnection _conn;

        private const string TABLE_INGREDIENT = "tb_ingredient";

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

        public int AddIngredient(string Name, string ImagePath)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_INGREDIENT);
                stringSQL.Append(" (name, image_path)");
                stringSQL.Append(" VALUES (@Name, @ImagePath);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@ImagePath", ImagePath);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- Add Ingredient Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddIngredient(): " + ex.Message);
                return -1;
            }
        }

        public int UpdateIngredient(int IngredientID, string Name, string ImagePath)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_INGREDIENT);
                stringSQL.Append(" SET name = @Name, image_path = @ImagePath");
                stringSQL.Append(" WHERE ingredient_id = @IngredientID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@IngredientID", IngredientID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@ImagePath", ImagePath);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- Update Ingredient Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => UpdateIngredient(): " + ex.Message);
                return -1;
            }
        }

        public int DeleteIngredient(int IngredientID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("DELECT FORM ");
                stringSQL.Append(TABLE_INGREDIENT);
                stringSQL.Append(" WHERE ingredient_id = @IngredientID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@IngredientID", IngredientID);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- Delete Ingredient ID " + IngredientID + " Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => DeleteIngredient(): " + ex.Message);
                return -1;
            }
        }

        public DataTable GetListOfIngreient()
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("SELECT ingredient_id, name, image_path ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_INGREDIENT + ";");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                DatabaseClose();
                log.Info("SmoothDataLayer -- GetListOfIngredient Success");
                return dt;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetListOfIngredient(): " + ex.Message);
                return null;
            }
        }

        public DataTable GetListOfIngredientFilter(string Name)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("SELECT ingredient_id, name, image_path ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_INGREDIENT);
                stringSQL.Append(" WHERE name LIKE @Name;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@Name", "%" + Name + "%");

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
