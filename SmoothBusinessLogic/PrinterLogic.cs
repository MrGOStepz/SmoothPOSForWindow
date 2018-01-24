using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmoothDataLayer;
using System.Web.Script.Serialization;

namespace SmoothBusinessLogic
{
    public class PrinterLogic
    {
        private PrinterDAO _printerDAO;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeLogic));

        public PrinterLogic()
        {
            _printerDAO = new PrinterDAO();
        }

        public string GetPrinter(string stringJSON, string prtLocation)
        {
            string ret = null;
            try
            {
                OrderDetailModel orderDetailModel = JsonConvert.DeserializeObject<OrderDetailModel>(stringJSON);
                log.Info("BusinessLogic :: AddOrderDetail");

                string orderNo = orderDetailModel.OrderID.ToString();

                //ret = _printerDAO.GetListForPrint(orderNo, prtLocation);

                DataTable dt = new DataTable();
                dt = _printerDAO.GetListForPrint(orderDetailModel.OrderID, prtLocation);

                //Convert DataTable to JSON
                //Add Refernces System.Web.Extension
                //Import using System.Web.Script.Serialization;
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }

                //Return to JSON format
                //return JsonConvert.SerializeObject(rows);
                return serializer.Serialize(rows);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddOrderDetail" + ex.Message);
                ret = null;
            }
            return ret;

        }
    }
}
