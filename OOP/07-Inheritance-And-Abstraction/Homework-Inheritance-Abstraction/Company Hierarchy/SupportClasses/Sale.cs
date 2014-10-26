using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyHierarchy
{
    // A sale holds product name, date and price.
    public class Sale
    {
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public Decimal Price { get; private set; }

        public Sale(string name, DateTime date, Decimal price)
        {
            this.Name = name;
            this.Date = date;
            this.Price = price;
        }
    }
}
