using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS
{
    interface IProduct
    {
        int AddProduct(string product);
        int UpdateProduct(string product);
        int RemoveProduct(int productID);
        string ListOfProduct();
        string FilterOfProduct(string product);
    }

    interface IPopup
    {
        int AddPopup(string popup);
        int UpdatPopup(string popup);
        int RemovePopup(int popupID);
        string GetPopupDetail(int popupID);
        string ListOfPopup();
        string ListOfPopupFilter(string name);
    }

    interface IIngredient
    {
        int AddIngredient(string ingredient);
        int UpdatIngredient(string ingredient);
        int RemoveIngredient(int ingredientID);
        string ListOfIngredient();
    }

    interface IComboSet
    {
        int AddComboSet(string comboSet);
        int UpdatComboSet(string comboSet);
        int RemoveComboSet(int comboSetID);
        string ListOfComboSet();
    }

    interface IStaff
    {
        int AddStaff(string staff);
        int UpdatStaff(string staff);
        int RemoveStaff(int staffID);
        int UpdateStaffStatus(int staffID, int status);
        int CheckStaffStatus(int staffID);
        string ListOfStaff();
        string FilterOfStaff(string staff);
        string GetStaffDetailByPassword(string password);
    }

    interface IRoster
    {
        int AddRoster(string roster);
        int UpdatRoster(string roster);
        int RemoveRoster(int rosterID);
    }

    interface IWages
    {
        int AddWages(string wages);
        int UpdatWages(string wages);
        int RemoveWages(int wagesID);
        string ListOfWeges();
    }

    interface IPrinter
    {
        int AddPrinter(string stringJSON);
        int UpdatePrinter(string stringJSON);
        int RemovePrinter(int PritnerID);
        string GetListOfPrinter();
    }

    interface IPrinterLog
    {
        int AddPrinterProduct(string stringJSON);
        int RemovePrinterProduct(int PritnerID, int ProductID);
        string GetListOfPrinterLog();

        int AddPrintReceiptLog(int receiptID);

    }

    interface IReport
    {
        string ListOfReport(int rowTotal);
        string ViewReceiptDetail(int receiptID);
        string FilterReport(string dateFrom, string dateTo);
        int DeleteReceipt(int receiptID);
    }

    interface ITable
    {
        int AddTable(string tableDetail);
        int UpdateTable(string tableDetail);
        int RemoveTable(int tableID);
        string GetListTable();
    }

    interface ISection
    {
        int AddSectionTable(string name);
        int UpdateSectiontable(int sectionID, string name);
        int RemoveSectionTable(int sectionID);
        string GetListOfSection();
    }

    interface ILocationMenu
    {
        int AddLocationMenu(string locationMenuDetail);
        int UpdateLocationMenu(string locationMenuDetail);
        int RemoveLocationMenu(int LocationMenuID);
        string GetListLocationMenu();
    }

    interface ILocationTab
    {
        int AddLocationTab(string name);
        int UpdateLocationTab(int locationTabID, string name);
        int RemoveLocationTab(int locationID);
        string GetListOfLocationTab();
    }
}
