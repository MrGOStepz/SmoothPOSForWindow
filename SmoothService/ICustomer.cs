using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SmoothService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomer" in both code and config file together.
    [ServiceContract]
    public interface ICustomer
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        int AddNewCustomer(string stringJSON);

        [OperationContract]
        int UpdateCustomer(string stringJSON);

    }

    
}
