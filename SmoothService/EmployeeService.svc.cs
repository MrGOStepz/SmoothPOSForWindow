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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        private EmployeeLogic _employeeLogic;
        private LoginLogic _loginLogic; //For Login process

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public int AddNewEmployeeDetail(string stringJSON)
        {
            log.Info("SmoothService :: AddNewEmployeeDetail :: " + stringJSON);
            _employeeLogic = new EmployeeLogic();
            return _employeeLogic.AddNewEmployeeLogic(stringJSON);
        }

        public int UpdateEmployeeDetail(string stringJSON)
        {
            _employeeLogic = new EmployeeLogic();
            return _employeeLogic.UpdateEmployeeLogic(stringJSON);
        }

        public string GetListOfEmployee()
        {
            log.Info("SmoothService :: EmployeeService :: GetListOfEmployee");
            _employeeLogic = new EmployeeLogic();
            return _employeeLogic.GetListOfEmployeeLogic();
        }

        public string LogIn(string stringJSON)
        {
            _loginLogic = new LoginLogic();
            log.Info("Here is for Log in :: "+ stringJSON);
            return _loginLogic.FindUserByPW(stringJSON);
        }
    }
}
