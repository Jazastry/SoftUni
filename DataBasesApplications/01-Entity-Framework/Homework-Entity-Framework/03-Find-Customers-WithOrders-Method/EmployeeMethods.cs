using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using Homework;

namespace FindEmployes
{
    public class EmployeeMethods
    {
        public static List<Employee> AllEmployeesWIthProjectsAfter()
        {
            using (var db = new SoftUniEntities())
            {
                DateTime date = new DateTime(2000);
                var employees = db.Employees.Where(e => e.Projects.All(p => p.StartDate > date)).ToList();

                return employees;
            }
        }

        public static List<Employee> AllCustomersWithOrdersQuery()
        {
            using (var db = new SoftUniEntities())
            {   
                string query = "SELECT * FROM Employees e WHERE e.EmployeeID IN (SELECT EmployeeID FROM EmployeesProjects ep JOIN Projects p ON ep.ProjectID = p.ProjectID WHERE p.StartDate > '2002-01-01 00:00:00')";
                var queryResult = db.Database.SqlQuery<Employee>(query).ToList();

                List<Employee> emp = queryResult.ToList();

                return queryResult;
            }
        }

        public static void ListEmployees(List<Employee> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine(emp.FirstName + " " + emp.LastName);
            }
        }

        public static List<Employee> FindEmployeesByDepartmentAndManager(string department, string managerFirstName, string managerLastName)
        {
            using (var db = new SoftUniEntities())
            {
                var employees = from e in db.Employees
                                where e.Department.Name == department &&
                                      (e.Manager.FirstName == managerFirstName) &&
                                      (e.Manager.LastName == managerLastName)
                                select e;

                return employees.ToList();
            }
        }
    }
}
