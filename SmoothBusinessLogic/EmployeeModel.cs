using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothBusinessLogic
{
    public class EmployeeModel
    {
        private int employeeID;
        private string firstName;
        private string lastName;
        private string phone;
        private string email;
        private int shiftID;
        private int levelID;
        private int password;

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int Password
        {
            get { return password; }
            set { password = value; }
        }


        public int ShiftID
        {
            get { return shiftID; }
            set
            {
                if (value < 1 && value > 3)
                {
                    shiftID = 1;
                }
                else
                {
                    shiftID = value;
                }
            }
        }

        public int LevelID
        {
            get { return levelID; }
            set
            {
                if (value < 1 && value > 3)
                {
                    levelID = 1;
                }
                else
                {
                    levelID = value;
                }
            }
        }

    }
}
