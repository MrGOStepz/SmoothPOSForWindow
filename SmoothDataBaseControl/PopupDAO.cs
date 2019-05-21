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
    public class PopupDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(PopupDAO));

        private MySqlConnection _conn;

        private const string TABLE_POPUP = "tb_popup";
        private const string TABLE_POPUP_ITEM = "tb_popup_item";
        private const string TABLE_PRODUCT = "tb_product";

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
                if (lstName.Count != lstPrice.Count && lstPrice.Count != lstImagePath.Count && lstName.Count != lstImagePath.Count)
                {
                    return -1;
                }

                using (var db = new smoothdbEntities())
                {
                    var ds = db.tb_popup.Add(new tb_popup()
                    {
                        name = Name

                    });

                    int tempId = ds.popup_id;
                    for (int i = 0; i < lstName.Count; i++)
                    {
                        var dspop = db.tb_popup_item.Add(new tb_popup_item()
                        {
                            popup_id = tempId,
                            name = lstName[i],
                            price = lstPrice[i],
                            image_path = lstImagePath[i]
                        }) ;
                    }
                        db.SaveChanges();
                    log.Info("SmoothDataLayer -- Add Popup Success");
                    return ds.popup_id;
                }

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

                using (var db = new smoothdbEntities())
                {
                    var update = db.tb_popup.Where(o => (o.popup_id == PopupID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.name = Name;
                    }

                    db.SaveChanges();
                    for (int i = 0; i < lstSupPopupID.Count; i++)
                    {
                        var updateItem = db.tb_popup_item.Where(o => (o.popup_id == PopupID)).FirstOrDefault();
                        if (updateItem != null)
                        {
                            updateItem.name = lstName[i];
                            updateItem.popup_id = PopupID;
                            updateItem.price = lstPrice[i];
                            updateItem.image_path = lstImagePath[i];
                        }
                    }
                }

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

                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_PRODUCT);
                stringSQL.Append(" SET popup_id = 1");
                stringSQL.Append(" WHERE popup_id = @PopupID;");

                stringSQL.Append("DELETE FROM ");
                stringSQL.Append(TABLE_POPUP_ITEM);
                stringSQL.Append(" WHERE popup_id = @PopupID;");

                stringSQL.Append("DELETE FROM ");
                stringSQL.Append(TABLE_POPUP);
                stringSQL.Append(" WHERE popup_id = @PopupID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@PopupID", PopupID);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                log.Info("SmoothDataLayer -- Delete Popup Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => DeletePopup(): " + ex.Message);
                return -1;
            }
        }

        public List<tb_popup> GetListOfPopup()
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var ds = (from c in db.tb_popup
                              where c.is_active == 1
                              orderby c.popup_id descending
                              select c).ToList();

                    // Assign to DataGridView
                    if (ds.Count() > 0)
                    {
                        log.Info("SmoothDataLayer -- GetListOfPopup Success");
                        return ds;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetListOfPopup(): " + ex.Message);
                return null;
            }
        }

        public List<tb_popup> GetListOfPopupFilter(string name)
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var ds = (from c in db.tb_popup
                              where c.name.Contains(name)
                              where c.is_active == 1                           
                              orderby c.popup_id descending
                              select c).ToList();

                    // Assign to DataGridView
                    if (ds.Count() > 0)
                    {
                        log.Info("SmoothDataLayer -- GetLisOfPopupFilter Success");
                        return ds;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetLisOfPopupFilter(): " + ex.Message);
                return null;
            }
        }

        public List<DataTable> GetPopupDetail(int PopupID)
        {
            try
            {
                List<DataTable> lstDataTables = new List<DataTable>();

                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();

                stringSQL.Append("SELECT popup_id, name ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_POPUP);
                stringSQL.Append("WHERE popup_id = @PopupID");
                stringSQL.Append(";");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@PopupID", PopupID);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adp.Fill(dt);

                //Index 0 = Main Popup             
                lstDataTables.Add(dt);

                stringSQL.Clear();
                stringSQL.Append("SELECT popup_item_id, name, popup_id, price, image_path ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_POPUP_ITEM);
                stringSQL.Append(" WHERE popup_id = @PopupID");
                stringSQL.Append(";");


                cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@PopupID", PopupID);
                adp = new MySqlDataAdapter(cmd);

                dt = new DataTable();
                adp.Fill(dt);

                //Index 1 = Sup Popup
                lstDataTables.Add(dt);

                cmd.Dispose();
                DatabaseClose();
                log.Info("SmoothDataLayer -- GetPopupDetail Success");
                return lstDataTables;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetPopupDetail(): " + ex.Message);
                return null;
            }
        }
    }
}
