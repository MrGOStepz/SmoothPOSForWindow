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
    public class ProductDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeDAO));

        private MySqlConnection _conn;

        private const string TABLE_PRODUCT = "tb_product";


        private void DatabaseOpen()
        {
            string connectionPath = ConfigurationManager.ConnectionStrings["SmoothDB"].ConnectionString;  //ConfigurationManager.ConnectionStrings["SmoothDB"].ConnectionString;
            _conn = new MySqlConnection(connectionPath);
            _conn.Open();
        }

        private void DatabaseClose()
        {
            _conn.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Sname"></param>
        /// <param name="Description"></param>
        /// <param name="PopupID"></param>
        /// <param name="PriceInc"> Price Include Tax</param>
        /// <param name="Stock"></param>
        /// <param name="Avaliable"></param>
        /// <param name="PdInID"> Product of Ingredient ID</param>
        /// <param name="ImagePath"></param>
        /// <returns></returns>
        public int AddProduct(string Name, string Sname, string Description, int PopupID, float PriceInc, int Stock, int Avaliable, int PdInID, string ImagePath)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append(TABLE_PRODUCT);
                stringSQL.Append(" (name, short_name, description, avaliable, product_ingredient_id, popup_id, stock, price, image_path)");
                stringSQL.Append(" VALUES (@Name, @ShortName, @Description, @Avaliable, @PdInID, @PopupID, @Stock, @Price, @ImagePath);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@ShortName", Sname);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Avaliable", Avaliable);
                cmd.Parameters.AddWithValue("@PdInID", PdInID);
                cmd.Parameters.AddWithValue("@PopupID", PopupID);
                cmd.Parameters.AddWithValue("@Stock", Stock);
                cmd.Parameters.AddWithValue("@Price", PriceInc);
                cmd.Parameters.AddWithValue("@ImagePath", ImagePath);

                cmd.ExecuteNonQuery();

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

        public int UpdateProduct(int ProductID, string Name, string Sname, string Description, int PopupID, float PriceInc, int Stock, int Avaliable, int PdInID, string ImagePath)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_PRODUCT);
                stringSQL.Append(" SET (name = @Name, short_name = @ShortName, description = @Description, avaliable = @Avaliable, product_ingredient_id = @PdInID, popup_id = @PopupID, stock = @Stock, price = @Price, image_path = @ImagePath)");
                stringSQL.Append(" WHERE product_id = @ProductID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@ShortName", Sname);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Avaliable", Avaliable);
                cmd.Parameters.AddWithValue("@PdInID", PdInID);
                cmd.Parameters.AddWithValue("@PopupID", PopupID);
                cmd.Parameters.AddWithValue("@Stock", Stock);
                cmd.Parameters.AddWithValue("@Price", PriceInc);
                cmd.Parameters.AddWithValue("@ImagePath", ImagePath);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- Update Product Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => UpdatProduct(): " + ex.Message);
                return -1;
            }
        }

        public int DeleteProduct(int ProductID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("DELECT FORM ");
                stringSQL.Append(TABLE_PRODUCT);
                stringSQL.Append(" WHERE product_id = @ProductID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- Delete Product Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => DeleteProduct(): " + ex.Message);
                return -1;
            }
        }

        public DataTable GetListOfProduct()
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("SELECT product_id, name, description, stock, popup_id, price, avaliable, ingredient_id, type_id ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_PRODUCT + ";");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                DatabaseClose();
                log.Info("SmoothDataLayer -- GetListOfProduct Success");
                return dt;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetListOfProduct(): " + ex.Message);
                return null;
            }
        }

        public DataTable GetListOfProductFilter(string name)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("SELECT product_id, name, description, stock, popup_id, price, avaliable, ingredient_id, type_id ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_PRODUCT);
                stringSQL.Append(" WEHRE name LIKE % @Name %;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@Name", name);

                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Dispose();
                DatabaseClose();
                log.Info("SmoothDataLayer -- GetLisOfProductFilter Success");
                return dt;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetLisOfProductFilter(): " + ex.Message);
                return null;
            }
        }



    }
}
