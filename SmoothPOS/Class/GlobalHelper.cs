using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS
{
    public static class GlobalHelper
    {
        public static EmployeeModel EmployeeDetail;
        public static EmployeeLevel EmployeeLevel;
    }

    public enum ServiceStatus
    {
        Running,
        Stopped,
        Paused,
        Stoping,
        Starting,
        Changing
    }
}
