using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
    class SolutionCompanyHierarchy
    {
        static void Main()
        {
            // Create several employees of type Manager,
            // SalesEmployee and Developer and add them in a 
            // single collection. Finally, print them in a for-each loop.

            List<Sale> sales = new List<Sale>()
            {
                new Sale("Big Sale", new DateTime(2014, 10, 5), 20000),
                new Sale("Medium Sale", new DateTime(2013, 1, 25), 100000),
                new Sale("Big Sale", new DateTime(2012, 3, 14), 30000000)
            };
            List<Project> projects = new List<Project>()
            {
                new Project("BIg Project", new DateTime(2010, 3, 27)),
                new Project("BIg Project", new DateTime(2011, 4, 27)),
                new Project("BIg Project", new DateTime(2012, 5, 27))
            };

            SalesEmployee ivo = new SalesEmployee(346527889, "Ivo", "Ivov", Department.Sales, 1000, sales);
            SalesEmployee miivo = new SalesEmployee(346787889, "Mvo", "Ivov", Department.Sales, 1200, sales);
            SalesEmployee bivo = new SalesEmployee(346213889, "Bvo", "Ivov", Department.Sales, 1300, sales);

            Console.WriteLine(ivo.ToString());

            Developer zoro = new Developer(346213889, "Zoro", "Ziskov", Department.Production, 10000, projects);
            Developer mzoro = new Developer(346213889, "Mzoro", "Hiskov", Department.Production, 2300, projects);
            Developer dzoro = new Developer(346213889, "Dzoro", "Ivimivov", Department.Production, 50000, projects);

            Manager rashko = new Manager(123764897, "Rashko", "Rashkov", Department.Sales, 1500,
                new List<Employee>() {ivo, mzoro, bivo});
            Manager bashko = new Manager(123764897, "Brashko", "Rashkov", Department.Production, 1500,
                new List<Employee>() {miivo, zoro, dzoro});

            List<Employee> employees = new List<Employee>()
            {
                ivo, miivo, mzoro, zoro, dzoro, bivo, rashko, bashko
            };

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee.ToString() + "\n");
            }
        }
    }
}
