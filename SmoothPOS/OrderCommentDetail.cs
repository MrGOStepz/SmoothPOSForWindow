using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS
{
    public class OrderCommentDetail
    {
        public bool VG { get; set; }
        public bool GF { get; set; }
        public int SpicyLevel { get; set; }
        public string Comment { get; set; }
        public List<string> ListComment { get; set; }
    }
}
