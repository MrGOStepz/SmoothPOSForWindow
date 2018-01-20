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
    public class LoginLogic
    {
        private EmployeeDAO _employeeDAO;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeLogic));

        public LoginLogic()
        {
            _employeeDAO = new EmployeeDAO();
        }

        public string FindUserByPW(string stringJSON)
        {
            try
            {
                DataTable dt = new DataTable();
                EmployeeModel employeeModel = JsonConvert.DeserializeObject<EmployeeModel>(stringJSON);
                dt = _employeeDAO.FindData(employeeModel.Password, "password");


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
                log.Error("BussicnessLogic => Login failed" + ex.Message);
                return null;
            }
        }
    }
}
