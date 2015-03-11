using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Homework;

namespace _02_Create_DAO_Class
{
    class EmployeeDAO
    {
        public static void InsertEmployee(string firstName, string lastName, string jobTitle,
            string departmentName, DateTime hireDate, decimal salary)
        {
            using (var db = new SoftUniEntities())
            {
                var employee = new Employee() 
                {
                    FirstName = firstName,
                    LastName = lastName,
                    JobTitle = jobTitle,
                    DepartmentID = db.Departments
                        .Where(d => d.Name == departmentName)
                        .FirstOrDefault().DepartmentID,
                    HireDate = hireDate,
                    Salary = salary
                };            
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        public static void ModifyEmployee(string firstName, string newFirstName)
        {
            using (var db = new SoftUniEntities())
            {
                Employee employee = db.Employees.Where(x => x.FirstName == firstName).FirstOrDefault<Employee>();
                employee.FirstName = newFirstName;
                db.SaveChanges();
            }
        }

        public static void ListAllEmployees()
        {
            using (Homework.SoftUniEntities db = new Homework.SoftUniEntities())
            {
                var employees = db.Employees.ToList();
                foreach (var emp in employees)
                {
                    Console.WriteLine(emp.FirstName + " " + emp.LastName);
                }
            }
        }

        public static void ShowEmployee(string firstName)
        {
            using (Homework.SoftUniEntities db = new Homework.SoftUniEntities())
            {
                var employee = db.Employees.Where(e => e.FirstName == firstName).FirstOrDefault();

                Console.WriteLine(employee.FirstName + " " + employee.LastName);

            }
        }

        public static void RemoveEmployee(string name)
        {
            using (var db = new SoftUniEntities())
            {
                var customer = db.Employees.Where(x => x.FirstName == name).FirstOrDefault<Employee>();
                db.Employees.Remove(customer);
                db.SaveChanges();
            }
        }
    }
}
