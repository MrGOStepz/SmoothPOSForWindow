using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SmoothService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PopupService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PopupService.svc or PopupService.svc.cs at the Solution Explorer and start debugging.
    public class PopupService : IPopupService
    {
        public int AddPopup(string stringJSON)
        {
            throw new NotImplementedException();
        }

        public string FilterOfPopup(string popupName)
        {
            throw new NotImplementedException();
        }

        public string ListOfPopup()
        {
            throw new NotImplementedException();
        }

        public int RemovePopup(int productID)
        {
            throw new NotImplementedException();
        }

        public int UpdatePopup(string stringJSON)
        {
            throw new NotImplementedException();
        }
    }
}
