using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS
{
    public class PrinterModel
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

    public class PrinterSmooth
    {
        public List<string> GetListOfPrinter()
        {
            try
            {
                List<string> lstPrinter = new List<string>();
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {                
                    lstPrinter.Add(printer);
                }
                return lstPrinter;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

}
