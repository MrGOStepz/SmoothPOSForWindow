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
    public class PrinterDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(PrinterDAO));

        private MySqlConnection _conn;

        private const string TABLE_PRINTER_PRODUCT = "tb_printer_product";
        private const string TABLE_PRINTER = "tb_printer";
        private const string TABLE_PRINTER_LOG = "tb_printer_log";

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

        public int AddPrinter(string Name,string PrinterIP, string PritnerPort)
        {
            try
            {
                using (var db = new SmoothDBEntities())
                {
                    var ds = db.tb_printer.Add(new tb_printer()
                    {
                        name = Name,
                        printer_ip = PrinterIP,
                        printer_port = PritnerPort
                    });

                    db.SaveChanges();
                }

                log.Info("SmoothDataLayer -- AddPrinter Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddPrinter(): " + ex.Message);
                return -1;
            }
        }

        public int UpdatePrinter(int PrinterID, string Name)
        {
            try
            {
                using (var db = new SmoothDBEntities())
                {
                    var update = db.tb_printer.Where(o => (o.printer_id == PrinterID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.name = Name;
                    }

                    db.SaveChanges();
                }

                log.Info("SmoothDataLayer -- UpdatePrinter Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => UpdatePrinter(): " + ex.Message);
                return -1;
            }
        }

        public int RemovePrinter(int PrinterID)
        {
            try
            {
                using (var db = new SmoothDBEntities())
                {
                    var update = db.tb_printer.Where(o => (o.printer_id == PrinterID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.is_active = 0;
                    }

                    db.SaveChanges();
                }

                log.Info("SmoothDataLayer -- RemovePrinter Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => RemovePrinter(): " + ex.Message);
                return -1;
            }
        }

        public List<tb_printer> GetListOfPrinter()
        {
            try
            {
                using (var db = new SmoothDBEntities())
                {
                    var ds = (from c in db.tb_printer
                              where c.is_active == 1
                              select c).ToList();

                    // Assign to DataGridView
                    if (ds.Count() > 0)
                    {
                        log.Info("SmoothDataLayer -- GetListOfPrinter Success");
                        return ds;
                    }
                    else
                    {
                        log.Error("SmoothDataLayer => GetListOfPrinter():");
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetListOfPrinter(): " + ex.Message);
                return null;
            }
        }

        public int AddPrinterProduct(int PrinterID, int ProdudctID)
        {
            try
            {
                using (var db = new SmoothDBEntities())
                {
                    var ds = db.tb_printer_product.Add(new tb_printer_product()
                    {
                        product_id = ProdudctID,
                        printer_id = PrinterID
                    });

                    db.SaveChanges();
                }

                log.Info("SmoothDataLayer -- AddPrinterProduct Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddPrinterProduct(): " + ex.Message);
                return -1;
            }
        }

        public int RemovePrinterProduct(int PrinterID, int ProductID)
        {
            try
            {
                using (var db = new SmoothDBEntities())
                {
                    var update = db.tb_printer_product.Where(o => (o.printer_id == PrinterID)).Where(o => (o.product_id == ProductID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.is_active = 0;
                    }

                    db.SaveChanges();
                }

                log.Info("SmoothDataLayer -- RemovePrinterProduct Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => RemovePrinterProduct(): " + ex.Message);
                return -1;
            }
        }

        public int AddPrinterLog(int PrinterID, string DT, string stringJson)
        {
            try
            {
                using (var db = new SmoothDBEntities())
                {
                    var ds = db.tb_printer_log.Add(new tb_printer_log()
                    {
                        printer_id = PrinterID,
                        print_dt = DateTime.Parse(DT),
                        printer_detail = stringJson

                    });

                    db.SaveChanges();
                }

                log.Info("SmoothDataLayer -- AddPrinterLog Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => AddPrinterLog(): " + ex.Message);
                return -1;
            }
        }

        public List<tb_printer_log> GetListOfPrinterLog()
        {
            try
            {
                using (var db = new SmoothDBEntities())
                {
                    var ds = (from c in db.tb_printer_log
                              select c).Take(50).ToList();

                    // Assign to DataGridView
                    if (ds.Count() > 0)
                    {
                        log.Info("SmoothDataLayer -- GetListOfPrinterLog Success");
                        return ds;
                    }
                    else
                    {
                        log.Error("SmoothDataLayer => GetListOfPrinter():");
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("SmoothDataLayer => GetListOfPrinterLog(): " + ex.Message);
                return null;
            }
        }

    }
}
