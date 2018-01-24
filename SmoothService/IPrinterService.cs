using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SmoothService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPrinterService" in both code and config file together.
    [ServiceContract]
    public interface IPrinterService
    {
        [OperationContract]
        string PrintOrder(string stringJSON);

        //[OperationContract]
        //string GetPrinterCenter(string stringJSON);

        //[OperationContract]
        //string GetPrinterBack(string stringJSON);

    }
}
