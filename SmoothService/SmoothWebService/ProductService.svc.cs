using SmoothBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmoothService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        ProductLogic _productLogic = null;

        public int AddProduct(string stringJSON)
        {
            _productLogic = new ProductLogic();
            return _productLogic.AddProduct(stringJSON);
        }

        public string FilterOfProduct(string productName)
        {
            throw new NotImplementedException();
        }

        public string ListOfProduct()
        {
            throw new NotImplementedException();
        }

        public int RemoveProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public int UpdateProduct(string stringJSON)
        {
            throw new NotImplementedException();
        }
    }
}
