using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS
{
    public class TableSection
    {
        
    }

    public class TableDetail
    {
        public int SectionID { get; set; }
        public string Name { get; set; }
        public float MarginTop { get; set; }
        public float MarginRight { get; set; }
        public float MarginButtom { get; set; }
        public float MarginLeft { get; set; }
        public int is_active { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

    }
}
