using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmoothService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        int AddProduct(string stringJSON);

        [OperationContract]
        int UpdateProduct(string stringJSON);

        [OperationContract]
        int RemoveProduct(int productID);

        [OperationContract]
        string ListOfProduct();

        [OperationContract]
        string FilterOfProduct(string productName);
    }
}
