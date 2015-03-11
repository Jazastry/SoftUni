using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Insert_New_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            ProjectMethods.InsertProject("First Project", "A PHP Project", DateTime.Now);
            ProjectMethods.InsertProject("Biiiiig Project", "A C# Project", DateTime.Now);

            ProjectMethods.ListProjects("First Project");
            ProjectMethods.ListProjects("Biiiiig Project");
        }
    }
}
