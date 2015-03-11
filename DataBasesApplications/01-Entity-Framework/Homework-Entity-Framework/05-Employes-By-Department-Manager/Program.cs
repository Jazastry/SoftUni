using Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03_04_Find_Employes_with_Projects;

namespace _05_Employes_By_Department_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftUniEntities db = new SoftUniEntities();

            // MANAGER NAMES AND DEPARTMENTS 
            //KenSanchez - Executive
            //JeffHay - Production
            //CynthiaRandall - Production
            //DavidLiu - Finance
            //LauraNorman - Executive
            //YuhongLi - Production
            //JamesHamilton - Production

            var employees = EmployeeMethods.FindEmployeeByDepartmentAndManager("Engineering", "Roberto", "Tamburello");

           
        }
    }
}
