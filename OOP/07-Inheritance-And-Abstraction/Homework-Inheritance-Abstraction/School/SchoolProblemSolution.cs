using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    class SchoolProblemSolution
    {
        private static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student("Ivan", "11"),
                new Student("Boril", "11"),
                new Student("Hristo", "11"),
                new Student("Svetla", "21"),
                new Student("Joro", "21"),
                new Student("Elena", "21"),
                new Student("Mira", "31"),
                new Student("Stoil", "31"),
                new Student("Todor", "31"),
                new Student("Draan", "12"),
                new Student("Pesho", "12"),
                new Student("Gosho", "12"),
                new Student("Mariela", "22"),
                new Student("Jordan", "22"),
                new Student("Ginka", "22"),
                new Student("Sneja", "32"),
                new Student("Stamat", "32"),
                new Student("Todor", "32")
            };
            Console.WriteLine("Student Objects :");

            students.ForEach(x => Console.WriteLine("{0} {1}", x.Name, x.ClassNumb));
            Console.WriteLine();

            List<Discipline> disciplines = new List<Discipline>()
            {
                new Discipline("PHP basics", 10, students.FindAll(student => student.ClassNumb.Equals("11"))),
                new Discipline("JavaScript basics", 10, students.FindAll(student => student.ClassNumb.Equals("21"))),
                new Discipline("C# basics", 10, students.FindAll(student => student.ClassNumb.Equals("31"))),
                new Discipline("JavaScript OOP", 10, students.FindAll(student => student.ClassNumb.Equals("12"))),
                new Discipline("PHP OOP", 10, students.FindAll(student => student.ClassNumb.Equals("22"))),
                new Discipline("C# OOP", 10, students.FindAll(student => student.ClassNumb.Equals("32")))
            };
            Discipline phpBasics = new Discipline("PHP basics", 10, students.FindAll(student => student.ClassNumb.Equals("11")));
            Discipline javaScriptBasics = new Discipline("JavaScript basics", 10, students.FindAll(student => student.ClassNumb.Equals("21")));
            Discipline cSharpBasics = new Discipline("C# basics", 10, students.FindAll(student => student.ClassNumb.Equals("31")));
            Discipline javaScriptOop = new Discipline("JavaScript OOP", 10, students.FindAll(student => student.ClassNumb.Equals("12")));
            Discipline phpOop = new Discipline("PHP OOP", 10, students.FindAll(student => student.ClassNumb.Equals("22")));
            Discipline cSharpOop = new Discipline("C# OOP", 10, students.FindAll(student => student.ClassNumb.Equals("32")));

            Console.WriteLine("Discipline Objects :");
            disciplines.ForEach(disc => disc.DisciplineStudents.ForEach(student => Console.WriteLine("{0} {1}", disc.DisciplineName, student.Name)));
            Console.WriteLine();

            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher("Gospodinov", new List<Discipline>() { phpBasics, javaScriptBasics }),
                new Teacher("Draganov", new List<Discipline>(){ cSharpBasics, cSharpOop}),
                new Teacher("Chervenkov", new List<Discipline>(){ phpOop, javaScriptBasics}),
                new Teacher("Sharanov", new List<Discipline>(){ javaScriptOop, cSharpBasics})
            };
            Teacher gospodinov = new Teacher("Gospodinov", new List<Discipline>() { phpBasics, javaScriptBasics });
            Teacher draganov = new Teacher("Draganov", new List<Discipline>(){ cSharpBasics, cSharpOop});
            Teacher chervenkov = new Teacher("Chervenkov", new List<Discipline>(){ phpOop, javaScriptBasics});
            Teacher sharanov = new Teacher("Sharanov", new List<Discipline>(){ javaScriptOop, cSharpBasics});

            List<Class> classes = new List<Class>
            {
                new Class("A1", teachers.Where(teacher => teacher.Disciplines.Any(disc => disc.DisciplineName.EndsWith("basics"))).ToList()),
                new Class("A2", teachers.Where(teacher => teacher.Disciplines.Any(disc => disc.DisciplineName.EndsWith("OOP"))).ToList())
            };
            Console.WriteLine("Class Objects : ");
            classes.ForEach(clas => clas.ClassTeachers
                .ForEach(teacher => teacher.Disciplines
                    .ForEach(discipline => Console.WriteLine("{0} - {1} : {2}", clas.ClassIndentifier, teacher.Name, discipline.DisciplineName))));
        }
    }
}
