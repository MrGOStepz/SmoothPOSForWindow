using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmoothPOS_Beta_.ProductService;
using SmoothPOS_Beta_.PopupService;

namespace SmoothPOS_Beta_
{
    public class DatabaseHandle : IProduct, IPopup
    {
        ProductService.ProductServiceClient _productService;
        PopupService.PopupServiceClient _popupService;

        public int AddPopup(string popup)
        {
            _popupService = new PopupServiceClient();
            return _popupService.AddPopup(popup);
        }
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

        public string ListOfPopup()
        {
            _popupService = new PopupServiceClient();
            return _popupService.ListOfPopup();
        }

        public string ListOfPopupFilter(string name)
        {
            _popupService = new PopupServiceClient();
            return _popupService.FilterOfPopup(name);
        }

        public string ListOfProduct()
        {
            throw new NotImplementedException();
        }

        public int RemovePopup(int popupID)
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

        public int UpdatPopup(string popup)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
