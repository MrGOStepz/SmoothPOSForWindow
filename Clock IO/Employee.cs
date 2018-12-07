using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock_IO
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int ClockInStatus { get; set; }

    }

    public class EmployeeTimeSheet
    {
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
