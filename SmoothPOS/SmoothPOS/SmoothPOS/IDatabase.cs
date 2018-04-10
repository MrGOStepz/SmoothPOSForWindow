using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS
{
    interface IProductDB
    {
        int AddProduct(string productDetail);
        int UpdateProduct(string productDetail);

        ProductDetail GetProductDetail(int productID);
        List<ProductDetail> GetListProduct();
        

        int DeleteProduct(int productID);
    }

    interface IIngedientDB
    {
        int AddIngedient(string ingedientDetail);
        int UpdateIngedient(string ingedientDetail);

        string GetListIngedient();

        int DeleteIngedient(int ingedientID);

    }

    interface IPopup
    {
        int AddPopup(string popupDetail);
        int UpdatePopup(string popupDetail);
        int DeletePopup(string popupDetail);

        string GetListPopup();
    }

    interface IUserDB
    {
        int AddUser(string userDetail);
        int UpdateUser(string userDetail);
        int UpdateLevelUser(int userID, int userLevel);

    }

    interface IPrinterDB
    {
        int AddPrinter(string printerDetail);
        int UpdatePrinter(string printerDetail);
        int DeletePrinter(int pritnerID);
        string GetListPrinter();
    }

    interface ITableDB
    {
        string GetTableDetail();
    }

    interface IReceiptDB
    {
        int AddReceipt(string receiptDetail);
        int UpdateRecipt(string receiptDetail);
        int MergeRecipt(string receipt1, string receipt2);

    }
}
