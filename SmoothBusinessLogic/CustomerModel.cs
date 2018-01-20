using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothBusinessLogic
{
    class CustomerModel
    {
        private int customerID;
        private string firstName;
        private string lastName;
        private int phone;
        private string address;
        private int totalOrder;
        private string lastActive;
        private string dob;
        private int card;
        private string email;

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
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

        public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public int TotalOrder
        {
            get { return totalOrder; }
            set { totalOrder = value; }
        }

        public string LastActive
        {
            get { return lastActive; }
            set { lastActive = value; }
        }

        public string Dob
        {
            get { return dob; }
            set { dob = value; }
        }

        public int Card
        {
            get { return card; }
            set { card = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

    }
}
