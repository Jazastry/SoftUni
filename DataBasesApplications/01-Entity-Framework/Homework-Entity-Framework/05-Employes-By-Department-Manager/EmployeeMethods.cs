using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Homework;
using System.Collections;
using System.Data.Entity.Utilities;

namespace _05_Employes_By_Department_Manager
{
    class EmployeeMethods
    {
        public static List<Employee> FindEmployeeByDepartmentAndManager(string department, string managerFirstName, string managerLastName)
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
