using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS
{
    public class ProductDetail
    {
        private int productID;
        private string productName;
        private string description;
        private string shortCut;
        private int popupID;
        private List<int> listIngedientID;
        private float price;
        private float tax;
        private string imagePath;
        private List<int> listPrinterID;
        private ItemLayout itemsLayout;

        public ItemLayout ItemsLayout
        {
            get { return itemsLayout; }
            set { itemsLayout = value; }
        }


        public List<int> ListPrinterID
        {
            get { return listPrinterID; }
            set { listPrinterID = value; }
        }


        public string ImagePath
        {
            get
            {
                //TODO setImagePath if Emply 
                if (imagePath != null)
                    return imagePath;
                else
                    return "";
            }
            set { imagePath = value; }
        }


        public float Tax
        {
            get { return tax; }
            set { tax = value; }
        }


        public float Price
        {
            get { return price; }
            set { price = value; }
        }


        public List<int> IngedientsList
        {
            get { return listIngedientID; }
            set { listIngedientID = value; }
        }


        public int PopUpID
        {
            get { return popupID; }
            set { popupID = value; }
        }


        public string ShortCut
        {
            get { return shortCut; }
            set { shortCut = value; }
        }


        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }


        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

    }
}
