using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    public class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        public List<Sale> Sales { get; private set; }

        public SalesEmployee(int id, string firstName, string lastName,
            Department department, decimal salary, List<Sale> sales)
            : base(id, firstName, lastName, department, salary)
        {
            this.Sales = sales;
        }

        public override string ToString()
        {
            string result = String.Format("{0} {1} : {2}\n Employee\n Department : Sales" +
                                          "\n Salary : {4}\n Sales : {5}",
                this.FirstName, this.LastName, this.Id, this.Department, this.Salary, ListActivity());
            return result;
        }

        public override string ListActivity()
        {
            string sales = "";
            foreach (Sale sale in this.Sales)
            {
                sales += sale.Name + ", " + sale.Date + ", " + sale.Price;
            }
            return sales;
        }
    }
}
