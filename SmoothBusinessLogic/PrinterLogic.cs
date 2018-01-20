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

                //ret = _printerDAO.GetListForPrint(orderDetailModel.OrderID,prtLocation);
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
