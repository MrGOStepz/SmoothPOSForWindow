using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SmoothBusinessLogic;

namespace SmoothService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PopupService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PopupService.svc or PopupService.svc.cs at the Solution Explorer and start debugging.
    public class PopupService : IPopupService
    {
        private PopupLogic _popupLogic;
        public int AddPopup(string stringJSON)
        {
            _popupLogic = new PopupLogic();
            return _popupLogic.AddNewPopupLogic(stringJSON);
        }

        public string FilterOfPopup(string popupName)
        {
            _popupLogic = new PopupLogic();
            return _popupLogic.GetListOfPopupFilter(popupName);
        }

        public string GetPopupDetail(int popupID)
        {
            _popupLogic = new PopupLogic();
            return _popupLogic.GetPopupDetail(popupID);
        }

        public string ListOfPopup()
        {
            _popupLogic = new PopupLogic();
            return _popupLogic.GetListOfPopup();
        }

        public int RemovePopup(int PopupID)
        {
            _popupLogic = new PopupLogic();
            return _popupLogic.DeletePopup(PopupID);
        }

        public int UpdatePopup(string stringJSON)
        {
            _popupLogic = new PopupLogic();
            return _popupLogic.UpdatePopup(stringJSON);
        }
    }
}
