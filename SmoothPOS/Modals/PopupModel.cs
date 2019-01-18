using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS
{
    public class PopupModel
    {
        public int PopupID { get; set; }
        public string Name { get; set; }
        public List<ListPopup> ListSubPopup = new List<ListPopup>();
    }

    public class ListPopup
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Image64 { get; set; }
    }
}
