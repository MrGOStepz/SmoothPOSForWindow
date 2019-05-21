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

        public int AddLocationTab(string Name)
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var ds = db.tb_location_tab.Add(new tb_location_tab()
                    {
                        name = Name
                    });

                    db.SaveChanges();
                }

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
                using (var db = new smoothdbEntities())
                {
                    var update = db.tb_location_tab.Where(o => (o.location_tab_id == LocationTabID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.name = Name;
                    }

                    db.SaveChanges();
                }
                log.Info("Update Profile Employee Success");
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
                using (var db = new smoothdbEntities())
                {
                    var update = db.tb_location_tab.Where(o => (o.location_tab_id == LocationTabID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.is_active = 0;
                    }

                    db.SaveChanges();
                }
                log.Info("Update Profile Employee Success");
                return 1;

            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => RemoveLocationTab: " + ex.Message);
                return -1;
            }
        }

        public List<tb_location_tab> GetListOfLocationTab()
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var ds = (from c in db.tb_location_tab
                              select c).ToList();

                    // Assign to DataGridView
                    if (ds.Count() > 0)
                    {
                        log.Info("Get List Of Location Tab Success");
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
                log.Error("SmoothDataLayer => GetListOfLocationTab(): " + ex.Message);
                return null;
            }
        }

        public int AddLocationMenu(int ProductID, int LocationTabID, int Column, int Row)
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    
                    var ds = db.tb_location_menu.Add(new tb_location_menu()
                    {
                        product_id = ProductID,
                        tb_location_tab_id = LocationTabID,
                        column_no = Column,
                        row_no = Row
                    });

                    db.SaveChanges();

                    return ds.product_id ?? -1;
                    
                }

            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddLocationMenu: " + ex.Message);
                return -1;
            }
        }

        //TODO Review
        public int UpdateLocationMenu(int LocationMenuID, int ProductID, int LocationTabID, int Column, int Row)
        {
            try
            {

                using (var db = new smoothdbEntities())
                {
                    var update = db.tb_location_menu.Where(o => (o.tb_location_menu_id == LocationMenuID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.product_id = ProductID;
                        update.tb_location_tab_id = LocationTabID;
                        update.column_no = Column;
                        update.row_no = Row;
                    }

                    db.SaveChanges();
                }
                log.Info("SmoothDataLayer -- UpdateLocationMenu Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => UpdateLocationMenu(): " + ex.Message);
                return -1;
            }
        }

        public int RemoveLocationMenu(int LocationMenuID)
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var update = db.tb_location_menu.Where(o => (o.tb_location_menu_id == LocationMenuID)).FirstOrDefault();
                    if (update != null)
                    {
                        
                        update.is_active = 0;
                    }

                    db.SaveChanges();
                }
                log.Info("Update Profile Employee Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => RemoveTable(): " + ex.Message);
                return -1;
            }
        }

        public List<tb_location_menu> GetListLocationMenu()
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var ds = (from c in db.tb_location_menu
                              select c).ToList();

                    // Assign to DataGridView
                    if (ds.Count() > 0)
                    {
                        log.Info("Get List Of Employee Success");
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
                log.Error("SmoothDataLayer => GetListTable(): " + ex.Message);
                return null;
            }
        }
    }

}
