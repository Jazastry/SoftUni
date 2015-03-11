using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Homework;

namespace _02_Create_DAO_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeDAO.InsertEmployee("Saso", "Sasov", "Production Technician", "Production", DateTime.Now, 1500);

            EmployeeDAO.ShowEmployee("Saso");

            EmployeeDAO.ModifyEmployee("Saso", "Zargan");

            EmployeeDAO.ShowEmployee("Zargan");

            EmployeeDAO.RemoveEmployee("Zargan");

            EmployeeDAO.ShowEmployee("Zargan");
        }
    }
}
