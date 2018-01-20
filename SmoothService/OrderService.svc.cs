using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SmoothBusinessLogic;

namespace SmoothService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrderService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OrderService.svc or OrderService.svc.cs at the Solution Explorer and start debugging.
    public class OrderService : IOrderService
    {
        private OrderLogic _orderLogic;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void DoWork()
        {
        }

        public int AddNewOrder(string stringJSON)
        {
            log.Info("SmoothService :: AddNewOrder :: " + stringJSON);
            _orderLogic = new OrderLogic();
            return _orderLogic.AddNewOrderLogic(stringJSON);
        }

        public string GetListOfATable(string stringJSON)
        {
            log.Info("SmoothService :: OderService :: GetListOfATable");
            _orderLogic = new OrderLogic();
            return _orderLogic.GetListOfATABLE(stringJSON);
        }
    }
}
