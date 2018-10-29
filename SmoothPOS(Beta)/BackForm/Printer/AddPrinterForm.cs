using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmoothPOS_Beta_
{
    public partial class AddPrinterForm : Form
    {
        public AddPrinterForm()
        {
            InitializeComponent();
            InitializePrinter();
        }

        private void InitializePrinter()
        {
            List<string> lstPrinter = new List<string>();

            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                lstPrinter.Add(printer);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO Add Printer to Database
        }
    }
}
