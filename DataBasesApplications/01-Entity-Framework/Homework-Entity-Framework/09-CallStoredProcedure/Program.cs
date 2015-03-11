using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework;

namespace _09_CallStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniEntities())
            {
                var firstEmployee = from e in db.Employees
                                    where e.EmployeeID == 1
                                    select e;
                string fName = firstEmployee.FirstOrDefault().FirstName;
                string lName = firstEmployee.FirstOrDefault().LastName;

                var projectsByEmp = db.usp_Project_By_Employee(fName, lName).ToList<usp_Project_By_Employee_Result>();

                foreach (var item in projectsByEmp)
                {
                    Console.WriteLine("Project Name: {0}\nDescription: {1}\nStartDate: {2}\nEmployee Name: {3}\n",
                        item.Name, item.Description, item.StartDate, item.Employee);

                }
            }
        }
    }
}
