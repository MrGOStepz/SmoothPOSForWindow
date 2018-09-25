using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS_Beta_
{
    public class DatabaseHandle : IProduct
    {
        #region IProduct
        public int AddProduct(string product)
        {
            throw new NotImplementedException();
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
