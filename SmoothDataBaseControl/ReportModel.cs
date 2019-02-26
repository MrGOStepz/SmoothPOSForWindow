using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDataBaseControl
{
    public class OrderDetailModel
    {

    }

    public class OrderModel
    {
        public int OrderID { get; set; }
        public DateTime OrderTime { get; set; }
        public int OrderTypeID { get; set; }
        public int EmployeeID { get; set; }
        public int TableSectionID { get; set; }
        public int OrderStatusID { get; set; }
        public int PaymentTypeID { get; set; }
        public int CustomerID { get; set; }
    }

    public class OrderTypeModel
    {
        public int OrderTypeID { get; set; }
        public string Name { get; set; }
    }

    public class OrderStatusModel
    {
        public int OrderStatusID { get; set; }
        public string Name { get; set; }
    }

    public class PaymentTypeModel
    {
        public int PaymentTypeID { get; set; }
        public string Name { get; set; }
    }
}
