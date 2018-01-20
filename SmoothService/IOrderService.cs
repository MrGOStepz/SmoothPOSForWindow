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

        [OperationContract]
        int AddOrderDetail(string stringJSON);

        [OperationContract]
        string GetListOfOrderTable();

        [OperationContract]
        string GetListofOrderType();

        [OperationContract]
        string GetListofOrderStatus();

        [OperationContract]
        string GetListOfOrderDetail();

        //[OperationContract]
        //string GetListOfATable(string stringJSON);
    }
}
