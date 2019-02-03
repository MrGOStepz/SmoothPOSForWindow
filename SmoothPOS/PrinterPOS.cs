using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SmoothPOS
{

    public class PrinterPOS
    {
        public class PrintText
        {
            public PrintText(string text, Font font) : this(text, font, new StringFormat()) { }

            public PrintText(string text, Font font, StringFormat stringFormat)
            {
                Text = text;
                Font = font;
                StringFormat = stringFormat;
            }

            public string Text { get; set; }

            public Font Font { get; set; }

            /// <summary> Default is horizontal string formatting </summary>
            public StringFormat StringFormat { get; set; }
        }

        private class ReceiptItem
        {
            public string Name { get; set; }

            public decimal Cost { get; set; }

            public int Amount { get; set; }

            public int Discount { get; set; }

            public decimal Total { get { return Cost * Amount; } }

            public int TypeFood { get; set; }
        }

        const int FIRST_COL_PAD = 28;
        const int SECOND_COL_PAD = 7;
        const int THIRD_COL_PAD = 28;

        public void Print()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintDialog pdi = new PrintDialog();

            PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();
            //// preview the assigned document or you can create a different previewButton for it
            printPrvDlg.Document = printDoc;
            printPrvDlg.ShowDialog();

            //pdi.document = printdoc;
            //printdoc.print();
        }

        public void PrintReceipt(ref PrintPageEventArgs e)
        {
            HeaderPrint(ref e, 10000);
            BodyPrint(ref e);
        }

        private void HeaderPrint(ref PrintPageEventArgs e, int InvNo)
        {
            //Logo Print
            using (Image imagelogo = Properties.Resources.Logo)
            {
                e.Graphics.DrawImage(imagelogo, 75, 5, 150, 75);
            }

            //Restaurant Infromation
            StringBuilder strB = new StringBuilder();
            strB.AppendLine("ATOM THAI RESTAURANT");
            strB.Append(string.Format("Invoice").PadRight(FIRST_COL_PAD));
            strB.Append(string.Format(InvNo.ToString()).PadLeft(THIRD_COL_PAD));
            strB.AppendLine();
            strB.Append(string.Format("ABN").PadRight(FIRST_COL_PAD));
            strB.Append(string.Format("9848487").PadLeft(THIRD_COL_PAD));
            strB.AppendLine();
            strB.AppendLine("=====================================");

            e.Graphics.DrawString(strB.ToString(), new Font("Arial", 10), Brushes.Black, 5, 85, new StringFormat());
        }

        private void BodyPrint(ref PrintPageEventArgs e)
        {          
            StringBuilder strB = new StringBuilder();
            strB.Append("Entree");

            e.Graphics.FillRectangle(Brushes.Black, 1, 150, 280, 25);
            e.Graphics.DrawString(strB.ToString(), new Font("Arial", 10), Brushes.White, 5, 155, new StringFormat());
        }

        private void FootPrint(ref PrintPageEventArgs e, int Offset)
        {

        }

        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            try
            {
                PrintReceipt(ref e);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
