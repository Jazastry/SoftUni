using System;
using System.Data.Entity;
using System.Data;
using Homework;

namespace FindEmployes
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = EmployeeMethods.AllEmployeesWIthProjectsAfter();

            EmployeeMethods.ListEmployees(employees);

            var employeesQuery = EmployeeMethods.AllCustomersWithOrdersQuery();

            EmployeeMethods.ListEmployees(employeesQuery);

            employees = EmployeeMethods.FindEmployeesByDepartmentAndManager("Engineering", "Roberto", "Tamburello");

            EmployeeMethods.ListEmployees(employees);
        }
    }
}
