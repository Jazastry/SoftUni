using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Homework
{
    class Program
    {       
        static void Main(string[] args)
        {
            SoftUniEntities db = new SoftUniEntities();

            var employees = db.Employees.ToList();

            foreach (var item in employees)
            {
                Console.WriteLine(item.LastName);
            }
          
           
        }
    }
}
