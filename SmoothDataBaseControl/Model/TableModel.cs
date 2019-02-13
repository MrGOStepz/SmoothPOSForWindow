using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDataBaseControl
{
    public class TableModal
    {
        public int TableID { get; set; }
        public int SectionID { get; set; }
        public string uniName { get; set; }
        public string Name { get; set; }
        public float MarginTop { get; set; }
        public float MarginRight { get; set; }
        public float MarginBottom { get; set; }
        public float MarginLeft { get; set; }
        public int is_active { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
    }

    public class SectionModel
    {
        public int SectionID { get; set; }  
        public string Name { get; set; }       
    }
}
