using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS
{
    public class LocationMenuModel
    {
        public int LocationMenuID { get; set; }
        public int ProductID { get; set; }
        public int LocationTabID { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
    }

    public class LocationTabModel
    {
        public int LocationTabID { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }
    }
}

