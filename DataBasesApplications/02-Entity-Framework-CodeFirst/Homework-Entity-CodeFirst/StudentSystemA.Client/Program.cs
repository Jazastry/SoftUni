using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Data;
using StudentSystem.Model;
using StudentSystemA.Data.Migrations;
using System.Runtime.InteropServices.ComTypes;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace StudentSystemA.Client
{
    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDBContext, Configuration>());

            var db = new StudentSystemDBContext();

            var studentsWithSubmissions = from h in db.Homeworks
                                          from s in db.Students
                                          where s.Id == h.SubmissionStudent.Id
                                          select s.Name + " " + h.Content;
            foreach (var item in studentsWithSubmissions.ToList())
            {
                Console.WriteLine(item.ToString());
            }

            db.Courses.ToList().ForEach(c => c.Resources.ToList().ForEach(r => Console.WriteLine(c.Name + " " + r.Name)));

            Course courseOne = new Course()
            {
                Name = "Guga Buga Course",
                StartDate = new DateTime(2222, 3, 1),
                Price = 354
            };
            
            Resource resourceVideo = new Resource() 
            {
                Name = "Video resource",
                TypeOfResource = ResourceType.Video,
                Link = "The Link"
            };
            Resource resourceDocs = new Resource()
            {
                Name = "Docs resource",
                TypeOfResource = ResourceType.Document,
                Link = "The Link"
            };
            Resource resourceOther = new Resource()
            {
                Name = "Other resource",
                TypeOfResource = ResourceType.Other,
                Link = "The Link"
            };
            courseOne.Resources.Add(resourceDocs);
            courseOne.Resources.Add(resourceOther);
            courseOne.Resources.Add(resourceVideo);

            Student student = new Student()
            {
                Name = "Gargandiua",
                BirthDay = new DateTime(1835, 1, 1),
                RegistrationDate = new DateTime(2020, 3, 3)
            };
            student.Courses.Add(courseOne);

            Resource resourceNew = new Resource() 
            {
                Name = "The New RECOURCE",
                Link = "The New Link",
                TypeOfResource = ResourceType.Presentation
            };

            db.Courses.Add(courseOne);
            db.Students.Add(student);
            db.Resources.Add(resourceDocs);
            db.Resources.Add(resourceNew);
            db.Resources.Add(resourceOther);
            db.Resources.Add(resourceVideo);
            db.SaveChanges();
        }
    }
}
