using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SmoothBusinessLogic;

namespace SmoothService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Customer" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Customer.svc or Customer.svc.cs at the Solution Explorer and start debugging.
    public class Customer : ICustomer
    {
        private CustomerLogic _customerlogic;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void DoWork()
        {
        }

        public int AddNewCustomer(string stringJSON)
        {
            log.Info("SmoothService :: AddNewCustomer :: " + stringJSON);
            _customerlogic = new CustomerLogic();
            return _customerlogic.AddNewEmployeeLogic(stringJSON);
        }

        public int UpdateCustomer(string stringJSON)
        {
            log.Info("SmoothService :: UpdateCustomer ::" + stringJSON);
            _customerlogic = new CustomerLogic();
            return _customerlogic.UpdateCustomer(stringJSON);
        }
    }
}
