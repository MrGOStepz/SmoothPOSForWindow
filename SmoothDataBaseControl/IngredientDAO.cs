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

        public int AddIngredient(string Name, string ImagePath)
        {
            try
            {

                try
                {
                    using (var db = new smoothdbEntities())
                    {
                        var ds = db.tb_ingredient.Add(new tb_ingredient()
                        {
                            name = Name,
                            image_path = ImagePath
                        });

                        db.SaveChanges();
                    }
                    return 1;
                }
                catch (Exception ex)
                {
                    log.Error("DataLayer => AppNewEmployee(): " + ex.Message);
                    return -1;
                }

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
                using (var db = new smoothdbEntities())
                {
                    var update = db.tb_ingredient.Where(o => (o.ingredient_id == IngredientID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.name = Name;
                        update.image_path = ImagePath;
                    }

                    db.SaveChanges();
                }
                log.Info("Update UpdateIngredient Success");
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
                using (var db = new smoothdbEntities())
                {
                    var del = db.tb_ingredient.Where(o => (o.ingredient_id == IngredientID)).FirstOrDefault();
                    if (del != null)
                    {
                        db.tb_ingredient.Remove(del);
                    }

                    db.SaveChanges();
                }

                log.Info("Delete Ingredient Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => DeleteIngredient(): " + ex.Message);
                return -1;
            }
        }

        public List<tb_ingredient> GetListOfIngreient()
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var ds = (from c in db.tb_ingredient
                              select c).ToList();

                    // Assign to DataGridView
                    if (ds.Count() > 0)
                    {
                        log.Info("Get List Of Ingredient Success");
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
                log.Error("SmoothDataLayer => GetListOfIngredient(): " + ex.Message);
                return null;
            }
        }

        public List<tb_ingredient> GetListOfIngredientFilter(string Name)
        {
            try
            {
                using (var db = new smoothdbEntities())
                {
                    var ds = (from c in db.tb_ingredient
                              where c.name == Name
                              select c).ToList();

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
                log.Error("SmoothDataLayer => GetLisOfPopupFilter(): " + ex.Message);
                return null;
            }
        }
    }
}
