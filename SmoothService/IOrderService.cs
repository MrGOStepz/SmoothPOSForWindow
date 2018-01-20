using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmoothService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOrderService" in both code and config file together.
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        int AddNewOrder(string stringJSON);

        //For getting a list of Data in a table
        //For instance
        //"tb_order";
        //"tb_order_type";
        //"tb_order_status";
        //"tb_order_detail";
        //To use the function :: set table_name parameter in orderModel 
        [OperationContract]
        string GetListOfATable(string stringJSON);
    }
}
