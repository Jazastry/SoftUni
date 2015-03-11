namespace StudentSystemA.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentSystem.Data;
    using StudentSystem.Model;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "StudentSystem.Data.StudentSystemDBContext";
        }

        protected override void Seed(StudentSystemDBContext context)
        {
            // Fill a few students, courses, resources and homework submissions

            if(context.Students.Any())
            {
                return;
            }
            Student ivan = new Student() 
            {
                Name = "Ivan",
                RegistrationDate = new DateTime(2010, 2, 12),
                PhoneNumber = "287621876"
            };            
            context.Students.AddOrUpdate(ivan);


            Student pesho = new Student()
            {
                Name = "Pesho",
                RegistrationDate = new DateTime(2012, 2, 12),
                PhoneNumber = "987876174614"
            };
            context.Students.AddOrUpdate(pesho);

            Student kiro = new Student()
            {
                Name = "Kiro",
                RegistrationDate = new DateTime(2011, 2, 12),
                PhoneNumber = "435324616897"
            };
            context.Students.AddOrUpdate(kiro);
            context.Students.Add(kiro);
            context.Students.Add(ivan);
            context.Students.Add(pesho);


            Resource resoureOne = new Resource()
            {
                Name = "Homework resource",
                TypeOfResource = ResourceType.Document,
                Link = "http:/myHomework.com"
            };
            context.Resources.AddOrUpdate(resoureOne);

            Resource resoureTwo = new Resource()
            {
                Name = "Lecture Resource",
                TypeOfResource = ResourceType.Video,
                Link = "http:/myLecture.com"
            };
            context.Resources.AddOrUpdate(resoureTwo);

            Resource resoureThree = new Resource()
            {
                Name = "Seminar Resource",
                TypeOfResource = ResourceType.Presentation,
                Link = "http:/mySeminar.com"
            };
            context.Resources.AddOrUpdate(resoureThree);
            context.Resources.Add(resoureOne);
            context.Resources.Add(resoureTwo);
            context.Resources.Add(resoureThree);

            Course cSharp = new Course()
            {
                Name = "C#",
                StartDate = new DateTime(2014, 1, 1),
                Price = 234
            };
            cSharp.Resources.Add(resoureOne);
            cSharp.Resources.Add(resoureThree);
            context.Courses.AddOrUpdate(cSharp);

            Course phpBasics = new Course()
            {
                Name = "PHP Basics",
                StartDate = new DateTime(2014, 3, 1),
                Price = 100
            };
            phpBasics.Resources.Add(resoureTwo);
            phpBasics.Resources.Add(resoureThree);
            context.Courses.AddOrUpdate(phpBasics);

            Course jsAps = new Course()
            {
                Name = "JS Apps",
                StartDate = new DateTime(2014, 5, 1),
                Price = 500
            };
            jsAps.Resources.Add(resoureThree);
            jsAps.Resources.Add(resoureTwo);
            context.Courses.AddOrUpdate(jsAps);
            context.Courses.Add(cSharp);
            context.Courses.Add(phpBasics);
            context.Courses.Add(jsAps);

            Homework homeworkIvan = new Homework()
            {
                Content = "C# homework",
                ContentType = ContentType.Zip,
                HomeworkDate = new DateTime(2015, 3, 5),
                SubmissionStudent = ivan
            };
            context.Homeworks.AddOrUpdate(homeworkIvan);

            Homework homeworkKiro = new Homework()
            {
                Content = "PHP homework",
                ContentType = ContentType.Zip,
                HomeworkDate = new DateTime(2015, 3, 3),
                SubmissionStudent = kiro
            };
            context.Homeworks.AddOrUpdate(homeworkKiro);

            Homework homeworkPesho = new Homework()
            {
                Content = "JS homework",
                ContentType = ContentType.Zip,
                HomeworkDate = new DateTime(2015, 3, 3),
                SubmissionStudent = pesho
            };
            context.Homeworks.AddOrUpdate(homeworkPesho);
            context.Homeworks.Add(homeworkIvan);
            context.Homeworks.Add(homeworkKiro);
            context.Homeworks.Add(homeworkPesho);

            context.SaveChanges();
        }
    }
}
