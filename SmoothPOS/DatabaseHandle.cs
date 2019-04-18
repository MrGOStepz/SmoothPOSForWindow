using SmoothDataBaseControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS
{
    public class DatabaseHandle : IProduct, IPopup, IStaff, IReport, ILocationMenu, ILocationTab, ISection, IPrinterLog, IPrinter
    {
        BusinessLogic _businessLogic;

        public DatabaseHandle()
        {
            _businessLogic = new BusinessLogic();
        }

        public int AddLocationMenu(string locationMenuDetail)
        {
            try
            {
                return _businessLogic.AddLocationMenu(locationMenuDetail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddLocationMenu : " + ex.Message);
                return -1;
            }
        }

        public int AddLocationTab(string name)
        {
            try
            {
                return _businessLogic.AddLocationTab(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddLocationTab : " + ex.Message);
                return -1;
            }
        }

        public int AddPopup(string popup)
        {
            try
            {
                return _businessLogic.AddNewPopupLogic(popup);
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddLocationTab : " + ex.Message);
                return -1;
            }

        }

        public int AddPrinter(string stringJSON)
        {
            try
            {
                return _businessLogic.AddPrinter(stringJSON);
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddPrinter : " + ex.Message);
                return -1;
            }
        }

        public int AddPrinterProduct(string stringJSON)
        {
            try
            {
                return _businessLogic.AddPrinterProduct(stringJSON);
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddPrinterProduct : " + ex.Message);
                return -1;
            }
        }

        public int AddPrintReceiptLog(int receiptID)
        {
            try
            {
                //return _businessLogic.AddPrintReceiptLog(receiptID);
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddPrintReceiptLog : " + ex.Message);
                return -1;
            }
        }

        public int AddProduct(string productDetail)
        {
            try
            {
                return _businessLogic.AddProductLogic(productDetail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddProduct : " + ex.Message);
                return -1;
            }

        }

        public int AddSectionTable(string name)
        {
            try
            {
                return _businessLogic.AddSectionTable(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddSectionTable : " + ex.Message);
                return -1;
            }
        }

        public int AddStaff(string staff)
        {
            try
            {
                //return _businessLogic.AddStaff(staff);
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddStaff : " + ex.Message);
                return -1;
            }
        }

        public int AddTable(string tableDetail)
        {
            try
            {
                return _businessLogic.AddTable(tableDetail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddTable : " + ex.Message);
                return -1;
            }
        }

        public int CheckStaffStatus(int staffID)
        {
            try
            {
                return _businessLogic.CheckStaffStatus(staffID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("CheckStaffStatus : " + ex.Message);
                return -1;
            }
        }

        public int DeleteReceipt(int receiptID)
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

        public string FilterReport(string dateFrom, string dateTo)
        {
            throw new NotImplementedException();
        }

        public string GetListLocationMenu()
        {
            try
            {
                return _businessLogic.GetListLocationMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetListLocationMenu : " + ex.Message);
                return null;
            }
        }

        public string GetListOfLocationTab()
        {
            try
            {
                return _businessLogic.GetListOfLocationTab();
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetListOfLocationTab : " + ex.Message);
                return null;
            }
        }

        public string GetListOfPrinter()
        {
            try
            {
                return _businessLogic.GetListOfPrinter();
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetListOfPrinter : " + ex.Message);
                return null;
            }
        }

        public string GetListOfPrinterLog()
        {
            try
            {
                return _businessLogic.GetListOfPrinterLog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetListOfPrinterLog : " + ex.Message);
                return null;
            }
        }

        public string GetListOfSection()
        {
            try
            {
                return _businessLogic.GetListOfSection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetListOfSection : " + ex.Message);
                return null;
            }
        }

        public string GetListTable()
        {
            try
            {
                return _businessLogic.GetListOfTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetListTable : " + ex.Message);
                return null;
            }
        }

        public string GetPopupDetail(int popupID)
        {
            try
            {
                return _businessLogic.GetPopupDetail(popupID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetListTable : " + ex.Message);
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
                Console.WriteLine("GetStaffDetailByPassword : " + ex.Message);
                return null;
            }

        }

        public string ListOfPopup()
        {
            try
            {
                return _businessLogic.GetListOfPopup();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ListOfPopup : " + ex.Message);
                return null;
            }
        }

        public string ListOfPopupFilter(string name)
        {
            try
            {
                return _businessLogic.GetListOfPopupFilter(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ListOfPopupFilter : " + ex.Message);
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

        public string ListOfReport(int rowTotal)
        {
            try
            {
                return _businessLogic.ListOfReport(rowTotal);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ListOfPopupFilter : " + ex.Message);
                return null;
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

        public int RemoveLocationMenu(int LocationMenuID)
        {
            throw new NotImplementedException();
        }

        public int RemoveLocationTab(int locationID)
        {
            throw new NotImplementedException();
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

        public int RemovePrinter(int PritnerID)
        {
            throw new NotImplementedException();
        }

        public int RemovePrinterProduct(int PritnerID, int ProductID)
        {
            throw new NotImplementedException();
        }

        public int RemoveProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public int RemoveSectionTable(int sectionID)
        {
            throw new NotImplementedException();
        }

        public int RemoveStaff(int staffID)
        {
            throw new NotImplementedException();
        }

        public int RemoveTable(int tableID)
        {
            throw new NotImplementedException();
        }

        public int UpdateLocationMenu(string locationMenuDetail)
        {
            throw new NotImplementedException();
        }

        public int UpdateLocationTab(int locationTabID, string name)
        {
            throw new NotImplementedException();
        }

        public int UpdatePrinter(string stringJSON)
        {
            throw new NotImplementedException();
        }

        public int UpdateProduct(string product)
        {
            throw new NotImplementedException();
        }

        public int UpdateSectiontable(int sectionID, string name)
        {
            throw new NotImplementedException();
        }

        public int UpdateStaffStatus(int staffID, int statusID)
        {
            try
            {
                return _businessLogic.UpdateEmployeeStatus(staffID, statusID);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public int UpdateTable(string tableDetail)
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

        public string ViewReceiptDetail(int receiptID)
        {
            throw new NotImplementedException();
        }
    }

}
