using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmoothService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PrintService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PrintService.svc or PrintService.svc.cs at the Solution Explorer and start debugging.
    public class PrintService : IPrintService
    {
        public void DoWork()
        {
            throw new NotImplementedException();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();

            printDoc.PrintPage += PrintDoc_PrintPage;

            //PrintDialog pdi = new PrintDialog();

            //PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();

            //// preview the assigned document or you can create a different previewButton for it
            //printPrvDlg.Document = printDoc;
            //printPrvDlg.ShowDialog();

            //pdi.Document = printDoc;
            printDoc.Print();


        }

        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                int y = 0;
                long totalTime = 0;
                if (lstEmployeeTimeSheets != null && lstEmployeeTimeSheets.Count != 0)
                {
                    e.Graphics.DrawString(lstEmployeeTimeSheets[0].Name + " | " + dtFrom.ToShortDateString() + " - " + dtTo.ToShortDateString(), new Font("Arial", 10), Brushes.Black, 5, 5, new StringFormat());

                    for (int i = 0; i < lstEmployeeTimeSheets.Count; i++)
                    {
                        long timeTick = lstEmployeeTimeSheets[i].DateTo.Ticks - lstEmployeeTimeSheets[i].DateFrom.Ticks;
                        totalTime += timeTick;
                        TimeSpan elapsedSpan = new TimeSpan(timeTick);
                        e.Graphics.DrawString(lstEmployeeTimeSheets[0].DateTo.ToShortDateString() + " | " + lstEmployeeTimeSheets[i].DateFrom.ToShortTimeString() + " - " + lstEmployeeTimeSheets[i].DateTo.ToShortTimeString() + " | " + String.Format("{0} hr, {1} m",
                   elapsedSpan.Hours, elapsedSpan.Minutes), new Font("Arial", 7), Brushes.Black, 5, 10 + ((i + 1) * 13), new StringFormat());
                        y = 10 + ((i + 1) * 15);
                    }

                    TimeSpan eSpan = new TimeSpan(totalTime);
                    e.Graphics.DrawString("Total " + String.Format("{0} hr, {1} m", eSpan.Hours, eSpan.Minutes), new Font("Arial", 8), Brushes.Black, 5, y + 8, new StringFormat());
                }


            }
            catch (Exception)
            {

            }
        }
    }
}
