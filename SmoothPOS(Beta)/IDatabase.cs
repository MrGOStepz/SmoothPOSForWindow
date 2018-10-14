using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS_Beta_
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
        string ListOfStaff();
        string FilterOfStaff(string staff);
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

    interface IPrinterLog
    {
        int AddPrinter(string printer);
        int RemovePrinter(int printerID);
        string ListOfPrinter();

        int AddPrintReceiptLog(int receiptID);
        int AddPrintLog(int printOrderID);

    }

    interface IReport
    {
        string ListOfReport(int rowTotal);
        string ViewReceiptDetail(int receiptID);
        string FilterReport(string dateFrom, string dateTo);
        int DeleteReceipt(int receiptID);
    }
}
