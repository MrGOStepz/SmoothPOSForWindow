using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS
{
    public class Popup
    {
        private int popupID;
        private string popupName;

        public string PopupName
        {
            get { return popupName; }
            set { popupName = value; }
        }

        public int PopupID
        {
            get { return popupID; }
            set { popupID = value; }
        }

    }
}
