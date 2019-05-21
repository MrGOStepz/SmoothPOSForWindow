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
    public class ProductDAO
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ProductDAO));

        public int AddProduct(string Name, string Sname, string Description, int PopupID, float PriceInc, int Stock, int Avaliable, int PdInID, int TypeOfFood, string ImagePath)
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var ds = db.tb_product.Add(new tb_product()
                    {
                        short_name = Sname,
                        description = Description,
                        avaliable = Avaliable,
                        product_ingredient_id = PdInID,
                        popup_id = PopupID,
                        stock = Stock,
                        price = PriceInc,
                        image_path = ImagePath,
                        type_food_id = TypeOfFood
                    });

                    db.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => AddProduct(): " + ex.Message);
                return -1;
            }
        }

        public int UpdateProduct(int ProductID, string Name, string Sname, string Description, int PopupID, float PriceInc, int Stock, int Avaliable, int PdInID, int typeOfFood, string ImagePath)
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var update = db.tb_product.Where(o => (o.product_id == ProductID)).FirstOrDefault();
                    if (update != null)
                    {

                        update.name = Name;
                        update.short_name = Sname;
                        update.description = Description;
                        update.avaliable = Avaliable;
                        update.product_ingredient_id = PdInID;
                        update.popup_id = PopupID;
                        update.stock = Stock;
                        update.price = PriceInc;
                        update.image_path = ImagePath;
                        update.type_food_id = typeOfFood;
                    }

                    db.SaveChanges();
                    
                }
                log.Info("Update UpdateProduct Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => UpdateProduct(): " + ex.Message);
                return -1;
            }
        }

        public int DeleteProduct(int ProductID)
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var update = db.tb_product.Where(o => (o.product_id == ProductID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.is_active = 0;
                    }

                    db.SaveChanges();

                }
                log.Info("SmoothDataLayer -- Delete Product Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => DeleteProduct(): " + ex.Message);
                return -1;
            }
        }

        public List<tb_product> GetListOfProduct()
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var ds = (from c in db.tb_product
                              select c).ToList();

                    // Assign to DataGridView
                    if (ds.Count() > 0)
                    {
                        log.Info("Get List Of Product Success");
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
                log.Error("SmoothDataLayer => GetListOfProduct(): " + ex.Message);
                return null;
            }
        }

        public List<tb_product> GetListOfProductFilter(string Name)
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var ds = (from c in db.tb_product
                              where c.name == Name
                              select c).ToList();

                    // Assign to DataGridView
                    if (ds.Count() > 0)
                    {
                        log.Info("Get List Of Product Success");
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
                log.Error("SmoothDataLayer => GetLisOfProductFilter(): " + ex.Message);
                return null;
            }
        }
    }
}
