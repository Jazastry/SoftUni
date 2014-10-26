using System;
using System.Collections.Generic;
using System.Linq;

namespace Customer
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer originalCustumer = new Customer("Krum", "Stefanov", "Georgiev", "krum@abv.bg",
                "+23426363", "Sofia Aleko No32", 1,
                    new List<Payment>() { new Payment("Taxes", 152), new Payment("Car Leasing", 3152) },
                        CustumerType.Regular);

            Customer clonedCustomer = (Customer)originalCustumer.Clone();
            clonedCustomer.FirstName = "Aleksander";
            clonedCustomer.Id = 2;

            List<Customer> customers = new List<Customer>(){originalCustumer, clonedCustomer};

            Console.WriteLine("NewCustomer - {0}", clonedCustomer);

            Console.WriteLine("Original Customer - {0}", originalCustumer);

            var orderedCustumers = customers.OrderBy(cust => cust).ToList();
            foreach (Customer customer in orderedCustumers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
 