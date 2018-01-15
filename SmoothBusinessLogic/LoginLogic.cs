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

        public bool FindUserByPW(string stringJSON)
        {
            bool ret = false;
            try
            {
                EmployeeModel employeeModel = JsonConvert.DeserializeObject<EmployeeModel>(stringJSON);
                ret = _employeeDAO.FindData(employeeModel.Password, "password");
                log.Info("BusinessLogic => Log in");
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => Login failed" + ex.Message);
            }
            return ret;
        }
    }
}
