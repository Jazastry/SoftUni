using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    public abstract class Person : IPerson
    {
        private int id;
        private string firstName;
        private string lastName;

        public int Id
        {
            get { return this.id; }
            set
            {
                if ((value < 0 ) || (value > 999999999))
                {
                    throw  new ArgumentOutOfRangeException("{0} {1} id value is invalid.", this.FirstName, this.LastName);
                }
                else
                {
                    this.id = value;
                }
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if ((String.IsNullOrEmpty(value) || (value.Length < 2))) 
                {
                    throw new ArgumentException("First Name of {0} have invalid value.", this.firstName);
                }
                else
                {
                    this.firstName = value;
                }
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if ((String.IsNullOrEmpty(value) || (value.Length < 2)))
                {
                    throw new ArgumentException("Last Name of {0} have invalid value.", this.lastName);
                }
                else
                {
                    this.lastName = value;
                }
            }
        }

        public Person(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        protected Person()
        {
        }

        public abstract string ToString();
    }
}
