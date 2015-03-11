using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework;

namespace _08_Insert_New_Project
{
    class ProjectMethods
    {
        public static void InsertProject(string name, string description, DateTime startDate)
        {
            using( var db = new SoftUniEntities())
            {
                 Project newProject = new Project()
                {
                    Name = name,
                    Description = description,
                    StartDate = startDate
                };

                db.Projects.Add(newProject);
                db.SaveChanges();
            }
        }

        public static void ListProjects(string name)
        {
            using(var db = new SoftUniEntities())
            {
                var projects = from p in db.Projects
                               where p.Name == name
                               select p.Name + ", start date : " + p.StartDate;

                foreach (var project in projects)
                {
                    Console.WriteLine(project);
                }
            }

        }
    }
}
