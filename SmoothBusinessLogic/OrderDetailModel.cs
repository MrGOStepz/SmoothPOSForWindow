using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothBusinessLogic
{
    class OrderDetailModel
    {
        private int orderDetailID;
        private int productID;
        private int popUpItemID;
        private int orderID;
        private int productQty;
        private float amount;
        private string comment;

        public int OrderDetailID
        {
            get { return orderDetailID; }
            set { orderDetailID = value; }
        }

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public int PopUpItemID
        {
            get { return popUpItemID; }
            set { popUpItemID = value; }
        }
        public int OrderID
        {
            get { return orderID; }
            set { orderID = value;}
        }
        public int ProductQty
        {
            get { return productQty; }
            set { productQty = value; }
        }
        public float Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
}
