using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothBusinessLogic
{
    class OrderModel
    {
        private int orderID;
        private string orderDateTime;
        private int orderTypeID;
        private int employeeID;
        private int table;
        private int orderStatusID;
        private int paymentID;
        private int customerID;
        private string tableName;

        public string TableName
        {   
            get { return tableName; }
            set { tableName = value; }
        }

        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }
        public string OrderDateTime
        {
            get { return orderDateTime; }
            set { orderDateTime = value; }
        }
        public int OrderTypeID
        {
            get { return orderTypeID; }
            set
            {
                if (value < 1 && value > 3)
                {
                    orderTypeID = 1;
                }
                else
                {
                    orderTypeID = value;
                }
            }
        }
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        public int Table
        {
            get { return table; }
            set { table = value; }
        }
        public int OrderStatusID
        {
            get { return orderStatusID; }
            set
            {
                if (value < 0 && value > 3)
                {
                    orderStatusID = 1;
                }
                else
                {
                    orderStatusID = value;
                }
            }
        }
        public int PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
    }
}
