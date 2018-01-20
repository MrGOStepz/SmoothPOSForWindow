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

        private const string TABLE_ORDER = "tb_order";
        private const string TABLE_ORDERTYPE = "tb_order_type";
        private const string TABLE_ORDERSTATUS = "tb_order_status";
        private const string TABLE_ORDERDETAIL = "tb_order_detail";

        public void DoWork()
        {
        }

        public int AddNewOrder(string stringJSON)
        {
            log.Info("SmoothService :: AddNewOrder :: " + stringJSON);
            _orderLogic = new OrderLogic();
            return _orderLogic.AddNewOrderLogic(stringJSON);
        }

        public int AddOrderDetail(string stringJSON)
        {
            log.Info("SmoothService :: AddOrderDetail ::" + stringJSON);
            _orderLogic = new OrderLogic();
            return _orderLogic.AddOrderDetailLogic(stringJSON);
        }

        public string GetListOfOrderTable()
        {
            log.Info("SmoothService :: OderService :: GetListOfATable");
            _orderLogic = new OrderLogic();
            return _orderLogic.GetListOfATABLE(TABLE_ORDER);
        }

        public string GetListofOrderType()
        {
            log.Info("SmoothService :: OderService :: GetListOfATable");
            _orderLogic = new OrderLogic();
            return _orderLogic.GetListOfATABLE(TABLE_ORDERTYPE);
        }

        public string GetListofOrderStatus()
        {
            log.Info("SmoothService :: OderService :: GetListOfATable");
            _orderLogic = new OrderLogic();
            return _orderLogic.GetListOfATABLE(TABLE_ORDERSTATUS);
        }

        public string GetListOfOrderDetail()
        {
            log.Info("SmoothService :: OderService :: GetListOfATable");
            _orderLogic = new OrderLogic();
            return _orderLogic.GetListOfATABLE(TABLE_ORDERDETAIL);

        }

        /*public string GetListOfATable(string stringJSON)
        {
            log.Info("SmoothService :: OderService :: GetListOfATable");
            _orderLogic = new OrderLogic();
            return _orderLogic.GetListOfATABLE(stringJSON);
        }*/
    }
}
