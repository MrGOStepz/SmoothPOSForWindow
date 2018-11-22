using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SmoothWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        // TODO: Add your service operations here
        [OperationContract]
        int AddNewEmployeeDetail(string stringJSON);

        [OperationContract]
        int UpdateEmployeeDetail(string stringJSON);

        [OperationContract]
        string GetListOfEmployee();

        //Log in using password 
        [OperationContract] 
        bool LogIn(string passwordJson);

        [OperationContract]
        string GetEmployeeDetailByPassword(string Password);

    }

}
