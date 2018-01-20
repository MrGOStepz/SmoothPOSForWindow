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
    public class CustomerLogic
    {
        private CustomerDAO _customerDAO;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CustomerLogic));

        public CustomerLogic()
        {
            _customerDAO = new CustomerDAO();
        }

        public int AddNewEmployeeLogic(string stringJSON)
        {
            int ret = 0;
            try
            {
                log.Info("BusinessLogic => AddNewEmplouee - Begin");
                CustomerModel customerModel = JsonConvert.DeserializeObject<CustomerModel>(stringJSON);
                return _customerDAO.AddNewCustomer(customerModel.FirstName, 
                    customerModel.LastName,
                    customerModel.Phone,
                    customerModel.Address,
                    customerModel.LastActive,
                    customerModel.Dob,
                    customerModel.Card,
                    customerModel.Email);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic :: AddNewCustomer" + ex.Message);
                ret = -1;
            }

            return ret;
        }

        public int UpdateCustomer(string stringJSON)
        {
            int ret = 0;
            try
            {
                log.Info("BusinessLogic :: UpdateCustomer - Begin");
                CustomerModel customerModel = JsonConvert.DeserializeObject<CustomerModel>(stringJSON);
                return _customerDAO.UpdateCustomer(customerModel.CustomerID,
                    customerModel.FirstName,
                    customerModel.LastName,
                    customerModel.Phone,
                    customerModel.Address,
                    customerModel.TotalOrder,
                    customerModel.LastActive,
                    customerModel.Dob,
                    customerModel.Card,
                    customerModel.Email);
            }
            catch (Exception ex)
            {
                log.Error("BusinessLogic :: UpdateCustomer" + ex.Message);
                ret = -1;
            }

            return ret;
        }

        public string GetCustomerByPhoneNumber(string stringJSON)
        {
            try
            {
                DataTable dt = new DataTable();
                CustomerModel customerModel = JsonConvert.DeserializeObject<CustomerModel>(stringJSON);
                dt = _customerDAO.GetCustomerByPhoneNumber(customerModel.Phone);

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
                log.Error("BussinessLogic :: GetCustomerByPhoneNumber()" + ex.Message);
                return null;
            }
        }
    }               
}
