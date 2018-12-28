using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothBusinessLogic
{
    public class ProductModel
    {
        private int productID;
        private string name;
        private string shortName;
        private string description;
        private int avaliable;
        private int productOfIngredientID;
        private int popupID;
        private int stock;
        private float price;
        private string imagePath;
        private int typeOfFood;
        private List<int> printerID;

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ShortName
        {
            get { return shortName; }
            set { shortName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Avaliable
        {
            get { return avaliable; }
            set { avaliable = value; }
        }

        public int ProductOfIngredientID
        {
            get { return productOfIngredientID; }
            set { productOfIngredientID = value; }
        }

        public int PopupID
        {
            get { return popupID; }
            set { popupID = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        public int TypeOfFood
        {
            get { return typeOfFood; }
            set
            {
                if (value < 1)
                    typeOfFood = 5;
                else
                    typeOfFood = value;
            }
        }

        public List<int> PrinterID
        {
            get { return printerID; }
            set { printerID = value; }
        }
    }
}
