using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS_Beta_
{
    public class Users
    {
        public int ID { get; set; }
        public int Level { get; set; }
        public string FirstName { get; set; }

    }

    public class Admin:Users
    {

    }

    public class Staff: Users
    {

    }

    public class Manage: Users
    {

    }

}
