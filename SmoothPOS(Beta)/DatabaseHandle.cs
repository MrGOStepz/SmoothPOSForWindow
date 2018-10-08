using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmoothPOS_Beta_.ProductService;

namespace SmoothPOS_Beta_
{
    public class DatabaseHandle : IProduct
    {
        ProductService.ProductServiceClient _productService;
        #region IProduct
        public int AddProduct(string productDetail)
        {
            _productService = new ProductServiceClient();
            return _productService.AddProduct(productDetail);
        }

        public string FilterOfProduct(string product)
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

        public int UpdateProduct(string product)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
