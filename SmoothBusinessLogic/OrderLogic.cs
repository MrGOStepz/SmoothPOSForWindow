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
    public class OrderLogic
    {
        private OrderDAO _orderDAO;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeLogic));

        public OrderLogic()
        {
            _orderDAO = new OrderDAO();
        }

        public int AddNewOrderLogic(string stringJSON)
        {
            int ret = 0;
            try
            {
                log.Info("BusinessLogic => AddNewOrder - Begin");
                OrderModel orderModel = JsonConvert.DeserializeObject<OrderModel>(stringJSON);
                ret = _orderDAO.AddNewOrder(orderModel.OrderDateTime, orderModel.OrderTypeID, orderModel.EmployeeID, orderModel.Table, orderModel.OrderStatusID, orderModel.PaymentID, orderModel.CustomerID);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddNewEmployee" + ex.Message);
                ret = -1;
            }
            return ret;
        }

        public string GetListOfATABLE(string stringJSON)
        {
            try
            {
                DataTable dt = new DataTable();
                OrderModel orderModel = JsonConvert.DeserializeObject<OrderModel>(stringJSON);
                dt = _orderDAO.GetListOfATable(orderModel.TableName);

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
                log.Error("BussinessLogic => GetListOfEmployee()" + ex.Message);
                return null;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
