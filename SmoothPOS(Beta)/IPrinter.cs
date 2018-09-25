using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS_Beta_
{
    interface IPrinter
    {
        int ReprintReceipt(int receiptID);
    }
}
