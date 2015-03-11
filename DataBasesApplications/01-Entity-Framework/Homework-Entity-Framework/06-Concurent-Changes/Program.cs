using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using Homework;
using _02_Create_DAO_Class;

namespace _06_Concurent_Changes
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftUniEntities dbOne = new  SoftUniEntities();
            SoftUniEntities1 dbTwo = new SoftUniEntities1();

            var empOne = dbOne.Employees.Where(e => e.DepartmentID == 1).ToArray();
            var empTwo = dbOne.Employees.Where(e => e.DepartmentID == 1).ToArray();

            for (int i = 0; i < empOne.Length; i++)
            {
                empOne[i].FirstName = "Huhum";
                empTwo[i].FirstName = "Zazum";
            }

            dbOne.SaveChanges();
            dbTwo.SaveChanges();
            
        }
    }
}
