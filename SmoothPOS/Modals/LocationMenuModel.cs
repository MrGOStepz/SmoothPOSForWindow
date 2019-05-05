using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS
{
    public class LocationMenu
    {
        public int LocationMenuID { get; set; }
        public int ProductID { get; set; }
        public int LocationTabID { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
    }

    public class LocationTab
    {
        public int LocationTabID { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }
    }
}

