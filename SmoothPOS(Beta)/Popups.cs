using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS_Beta_
{
    public class PopupDish
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<SubPopupDish> ListSubPopup;
    }

    public class SubPopupDish
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float PriceExtra { get; set; }
    }
}
