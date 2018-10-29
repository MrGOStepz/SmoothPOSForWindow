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
    public partial class RemovePrinterForm : Form
    {
        public RemovePrinterForm()
        {
            InitializeComponent();
            InitilizePrinter();
        }

        private void InitilizePrinter()
        {
            //TODO Get List of Pritner

            List<string> lstPritner = new List<string>();

            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                lstPritner.Add(printer);
            }
        }

        private void btnRemovePrinter_Click(object sender, EventArgs e)
        {
            //TODO Remove pritner in Database
        }
    }
}
