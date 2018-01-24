using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SmoothBusinessLogic;

namespace SmoothService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PrinterService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PrinterService.svc or PrinterService.svc.cs at the Solution Explorer and start debugging.
    public class PrinterService : IPrinterService
    {
        private PrinterLogic _printerLogic;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string PrintOrder(string stringJSON)
        {
            log.Info("SmoothService :: PrintOrder :: " + stringJSON);
            _printerLogic = new PrinterLogic();
            return _printerLogic.GetPrinter(stringJSON, "Front");

        }

        /*public string GetPrinterCenter(string stringJSON)
        {
            log.Info("SmoothService :: GetPrinterFront :: " + stringJSON);
            _printerLogic = new PrinterLogic();
            return _printerLogic.GetPrinter(stringJSON, "Center");
        }

        public string GetPrinterBack(string stringJSON)
        {
            log.Info("SmoothService :: GetPrinterFront :: " + stringJSON);
            _printerLogic = new PrinterLogic();
            return _printerLogic.GetPrinter(stringJSON, "Back");
        }*/
    }
}
