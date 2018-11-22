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
    public class EmployeeLogic
    {
        private EmployeeDAO _employeeDAO;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeLogic));

        public EmployeeLogic()
        {
            _employeeDAO = new EmployeeDAO();
        }

        public int AddNewEmployeeLogic(string stringJSON)
        {
            try
            {
                log.Info("BusinessLogic => AddNewEmplouee - Begin");
                EmployeeModel employeeModel = JsonConvert.DeserializeObject<EmployeeModel>(stringJSON);
                return _employeeDAO.AddNewEmployee(employeeModel.FirstName, employeeModel.LastName, employeeModel.Phone, employeeModel.Email, employeeModel.Password);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddNewEmployee" + ex.Message);
                return -1;
            }
        }

        public int UpdateEmployeeLogic(string stringJSON)
        {
            log.Info("BusinessLogic -- UpdateEmployee");
            try
            {
                EmployeeModel employeeModel = JsonConvert.DeserializeObject<EmployeeModel>(stringJSON);
                if(employeeModel.EmployeeID == 0)
                {
                    log.Info("BusinessLogic => UpdateEmployeeProfile, EmployeeID == 0");
                    return 0;
                }
                else
                    return _employeeDAO.UpdateProfileEmployee(employeeModel.EmployeeID, employeeModel.FirstName, employeeModel.LastName, employeeModel.NickName, employeeModel.Phone, employeeModel.Email, employeeModel.Password);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddNewEmployee" + ex.Message);
                return -1;
            }
        }

        public string GetListOfEmployeeLogic()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = _employeeDAO.GetListOfEmployee();

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
                log.Error("BussinessLogic => GetListOfEmployeeLogic()" + ex.Message);
                return null;
            }
        }

        public string GetEmployeeDetailByPassword(string Password)
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                DataTable dataTable = new DataTable();
                dataTable = _employeeDAO.GetEmployeeDetailByPassword(Password);

                if (dataTable != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        employeeModel = new EmployeeModel();
                        employeeModel.EmployeeID = (int)row["employee_id"];
                        employeeModel.FirstName = row["first_name"].ToString();
                        employeeModel.LastName = row["last_name"].ToString();
                        employeeModel.Phone = row["phone"].ToString();
                        employeeModel.Email = row["email"].ToString();
                        employeeModel.StatusID = (int)row["status_id"];
                        employeeModel.LevelID = (int)row["level_id"];
                    }

                    string stringJSON = JsonConvert.SerializeObject(employeeModel);

                    return stringJSON;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => GetEmployeeDetailByPassword" + ex.Message);
                return null;
            }
        }
    }
}
