using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmoothPOS_Beta_.ProductService;
using SmoothPOS_Beta_.PopupService;
using SmoothPOS_Beta_.EmployeeService;

namespace SmoothPOS_Beta_
{
    public class DatabaseHandle : IProduct, IPopup, IStaff
    {
        ProductService.ProductServiceClient _productService;
        PopupService.PopupServiceClient _popupService;
        EmployeeService.EmployeeServiceClient _employeeService;

        public int AddPopup(string popup)
        {
            _popupService = new PopupServiceClient();
            return _popupService.AddPopup(popup);
        }

        public int AddProduct(string productDetail)
        {
            _productService = new ProductServiceClient();
            return _productService.AddProduct(productDetail);
        }

        public int AddStaff(string staff)
        {
            throw new NotImplementedException();
        }

        public string FilterOfProduct(string product)
        {
            throw new NotImplementedException();
        }

        public string FilterOfStaff(string staff)
        {
            throw new NotImplementedException();
        }

        public string GetPopupDetail(int popupID)
        {
            _popupService = new PopupServiceClient();
            return _popupService.GetPopupDetail(popupID);
        }

        public string GetStaffDetailByPassword(string password)
        {
            _employeeService = new EmployeeServiceClient();
            return _employeeService.GetEmployeeDetailByPassword(password);
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

        public string ListOfStaff()
        {
            throw new NotImplementedException();
        }

        public int RemovePopup(int popupID)
        {
            _popupService = new PopupServiceClient();
            return _popupService.RemovePopup(popupID);
        }

        public int RemoveProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public int RemoveStaff(int staffID)
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

        public int UpdatStaff(string staff)
        {
            throw new NotImplementedException();
        }
    }
}
