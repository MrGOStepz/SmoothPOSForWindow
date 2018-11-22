using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothPOS_Beta_
{
    public class EmployeeModel
    {
        private int employeeID;
        private string firstName;
        private string lastName;
        private string nickName;
        private string phone;
        private string email;
        private int statusID;
        private int levelID;
        private string password;

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

        public string NickName
        {
            get { return nickName; }
            set { nickName = value; }
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

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        public int StatusID
        {
            get { return statusID; }
            set { statusID = value; }
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

    public enum EmployeeLevel
    {
        Admin,
        Manage,
        Staff,
        Trainee
    }
}
