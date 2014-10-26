using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer 
{
    // •	Define a class Customer, which contains data about a customer –
    // first name, middle name and last name, ID (EGN), permanent address,
    // mobile phone, e-mail, list of payments and customer type. 
    // •	Define an enumeration for the customer type, 
    // holding the following types of customers: One-time , Regular, Golden, Diamond.
    class Customer : ICloneable, IComparable
    {
        public Customer Current { get; private set; }
        private string firstName;
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        private int id;
        public string PermanentAddress { get; private set; }
        public string MobilePhone { get; private set; }
        public string Email { get; private set; }
        public List<Payment> Payments { get; private set; }
        public CustumerType CustomerType { get; private set; }

        public string FirstName {
            get { return this.firstName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("FirstName value is not assigned !");
                }
                this.firstName = value;
            }
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value < 1)
                {
                   throw new ArgumentNullException("ID can't be null !");
                }
                this.id = value;
            }
        }

        public Customer(string firstName, string middleName,
            string lastName, string email, string mobilePhone, string permanentAddress, int id
            , List<Payment> payment, CustumerType costumerType)
        {
            this.FirstName = firstName;
            this.Payments = payment;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Email = email;
            this.MobilePhone = mobilePhone;
            this.PermanentAddress = permanentAddress;
            this.Id = id;
            this.CustomerType = costumerType;
        }

        public Customer()
        {
           
        }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;

            if (customer == null)
            {
                return false;   
            }
            if (!Object.Equals(this.Id, customer.Id))
            {
                return false;
            }

            return true;
        }
        public static bool operator ==(Customer Customer1,
                               Customer Customer2)
        {
            return Customer.Equals(Customer1, Customer2);
        }
        public static bool operator !=(Customer Customer1,
                           Customer Customer2)
        {
            return !(Customer.Equals(Customer1, Customer2));
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ MiddleName.GetHashCode() ^
                LastName.GetHashCode() ^ Id.GetHashCode();
        }

        public int CompareTo(object other)
        {
            Customer otherCust = (Customer)other;
            int firstNameCompare = this.FirstName.CompareTo(otherCust.FirstName);
            int egnCompare = this.Id.CompareTo(otherCust.Id);
            if (firstNameCompare == 0)
            {
                return egnCompare;
            }
            return firstNameCompare;
        }

        public object Clone()
        {
            Customer clonedCustomer = new Customer(this.FirstName, this.MiddleName, this.LastName,
                this.Email, this.MobilePhone, this.PermanentAddress, this.Id, 
                new List<Payment>(this.Payments), this.CustomerType);
            return clonedCustomer;
        }

        public override string ToString()
        {
            string payments = "";
            this.Payments.ForEach(p => payments += " Payments :" + p.ProductName + " - " + p.Price + "\n");

            string result = String.Format("\n {0}\n {1}\n {2}\n {3}\n {4}\n {5}\n Id : {6}\n {7}\n{8}\n",
                this.FirstName, this.MiddleName, this.LastName,
                this.Email, this.MobilePhone, this.PermanentAddress, this.Id, this.CustomerType, payments);

            return result;
        }
    }
}
