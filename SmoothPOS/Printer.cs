using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS
{
    public class Printer
    {
        private int printerID;
        private string printerName;

        public string PrinterName
        {
            get { return printerName; }
            set { printerName = value; }
        }


        public int PrinterID
        {
            get { return printerID; }
            set { printerID = value; }
        }

        public int PrintRecript()
        {
            return 1;
        }
    }
}
