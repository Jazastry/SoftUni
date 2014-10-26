using System;
using System.Collections.Generic;

namespace CompanyHierarchy
{
    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Calary value can't be negative.");
                }
                else
                {
                    this.salary = value;
                }
            }
        }
        public Department Department { get; private set; }

        public Employee(int id, string firstName, string lastName, Department department, decimal salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public Employee() {}

        public abstract override string ToString();
        public abstract string ListActivity();
    }
}
