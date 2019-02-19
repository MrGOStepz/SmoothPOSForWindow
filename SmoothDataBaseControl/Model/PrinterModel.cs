using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDataBaseControl
{
    public class PrinterProductModel
    {
        public int PrinterProductID { get; set; }
        public int ProductID { get; set; }
        public int PrinterID { get; set; }
    }

    public class PrinterLogModel
    {
        public int PrinterLogID { get; set; }
        public int PrinterID { get; set; }
        public DateTime PrinterDateTime { get; set; }
        public string PrinterDetail { get; set; }
    }

    public class PrinterModel
    {
        public int PrinterID { get; set; }
        public string Name { get; set; }
        public string PrinterIP { get; set; }
        public string PrinterPort { get; set; }
        public int IsActive { get; set; }
    }
}
