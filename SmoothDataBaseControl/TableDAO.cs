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

        public int AddSectionTable(string Name)
        {
            try
            {
                using (var db = new SmoothDBEntities())
                {
                    var ds = db.tb_section.Add(new tb_section()
                    {
                        name = Name
                    });

                    db.SaveChanges();
                }
             
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
                using (var db = new SmoothDBEntities())
                {
                    var update = db.tb_table_section.Where(o => (o.section_id == SectionID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.name = Name;
                    }

                    db.SaveChanges();
                }

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
                using (var db = new SmoothDBEntities())
                {
                    var update = db.tb_section.Where(o => (o.section_id == SectionID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.is_active = 0;
                    }

                    db.SaveChanges();
                }

                log.Info("SmoothDataLayer -- RemoveSectionTable Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => RemoveSectionTable(): " + ex.Message);
                return -1;
            }
        }

        public List<tb_section> GetListOfSection()
        {
            try
            {
                using (var db = new SmoothDBEntities())
                {
                    var ds = (from c in db.tb_section
                              select c).ToList();

                    // Assign to DataGridView
                    if (ds.Count() > 0)
                    {
                        log.Info("SmoothDataLayer -- GetListSection Success");
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
                log.Error("SmoothDataLayer => GetListOfSection(): " + ex.Message);
                return null;
            }
        }

        public int AddTable(string UName, string Name, int SectionID, float MarginTop, float MarginBot, float MarginLeft, float MarginRight)
        {
            try
            {

                using (var db = new SmoothDBEntities())
                {
                    var ds = db.tb_table_section.Add(new tb_table_section()
                    {
                        name = Name,
                        section_id = SectionID,
                        margin_top = MarginTop,
                        margin_bottom = MarginBot,
                        margin_left = MarginLeft,
                        margin_right = MarginRight,
                        height = 75,
                        width = 75,
                        is_active = 1
                        
                    });

                    db.SaveChanges();
                    log.Info("SmoothDataLayer -- AddTable Success");
                    return ds.table_section_id;
                }

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
                using (var db = new SmoothDBEntities())
                {
                    var update = db.tb_table_section.Where(o => (o.table_section_id == TableID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.margin_top = MarginTop;
                        update.margin_bottom = MarginBot;
                        update.margin_left = MarginLeft;
                        update.margin_right = MarginRight;
                    }

                    db.SaveChanges();
                }

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
                using (var db = new SmoothDBEntities())
                {
                    var update = db.tb_table_section.Where(o => (o.table_section_id == TableID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.is_active = 0;
                    }

                    db.SaveChanges();
                }

                log.Info("SmoothDataLayer -- RemoveTable Success");
                return 1;

            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => RemoveTable(): " + ex.Message);
                return -1;
            }
        }

        public List<tb_table_section> GetListTable()
        {
            try
            {
                using (var db = new SmoothDBEntities())
                {
                    var ds = (from c in db.tb_table_section
                              select c).ToList();

                    // Assign to DataGridView
                    if (ds.Count() > 0)
                    {
                        log.Info("SmoothDataLayer -- GetListTable Success");
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
