using SmoothDataBaseControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS
{
    public class DatabaseHandle : IProduct, IPopup, IStaff
    {
        BusinessLogic _businessLogic;

        public DatabaseHandle()
        {
            _businessLogic = new BusinessLogic();
        }

        public int AddPopup(string popup)
        {
            try
            {
                return _businessLogic.AddNewPopupLogic(popup);
            }
            catch (Exception)
            {
                return -1;
            }

        }

        public int AddProduct(string productDetail)
        {
            try
            {
                return _businessLogic.AddProductLogic(productDetail);
            }
            catch (Exception)
            {
                return -1;
            }

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
            try
            {
                return _businessLogic.GetPopupDetail(popupID);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public string GetStaffDetailByPassword(string password)
        {
            try
            {
                return _businessLogic.GetEmployeeDetailByPassword(password);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public string ListOfPopup()
        {
            try
            {
                return _businessLogic.GetListOfPopup();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string ListOfPopupFilter(string name)
        {
            try
            {
                return _businessLogic.GetListOfPopupFilter(name);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public string ListOfProduct()
        {
            try
            {
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ListOfStaff()
        {
            try
            {
                return _businessLogic.GetListOfEmployeeLogic();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public int RemovePopup(int popupID)
        {
            try
            {
                return _businessLogic.DeletePopup(popupID);
            }
            catch (Exception)
            {
                return -1;
            }
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
