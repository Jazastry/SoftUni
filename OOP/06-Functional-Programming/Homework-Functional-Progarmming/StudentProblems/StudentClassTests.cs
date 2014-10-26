using System;
using System.Collections.Generic;
using System.Linq;
using Tests;

namespace StudentProblems
{
    class StudentClassTests
    {
        // :::::::  UNCOMMENT COMMENTED LINES TO SHOW THE RESULT  :::::::::
        private static void Main()
        {
            List<Student> students = new List<Student>

        {
            new Student("Ivan", "Ivanov", 22, "+359878345678", "ivan@mail.bg", new List<int> {3, 5, 6}, 2,          120313, "Web Developer"),
            new Student("Todor", "Todorov", 23, "+3592345678", "todor@hotmail.bg", new List<int> {3, 6, 6}, 2,      381214, "QA Engineer"),
            new Student("Bistra", "Georgieva", 19, "+35902555678", "bistrar@gmail.com", new List<int> {4, 5, 6}, 3, 141012, "Web Developer"),
            new Student("Svilen", "Zahariev", 22, "02367679", "svilen@abv.bg", new List<int> {2, 5, 2}, 2,          100910, "Web Developer"),
            new Student("Zlatna", "Petrova", 20, "024/777378", "zlatnar@gmail.bg", new List<int> {5, 4, 3}, 1,      310209, "PHP Developer"),
            new Student("Pesho", "Peshev", 19, "+359 344 34 56 78", "petar@gmail.com", new List<int> {5, 5, 5}, 3,  220514, "QA Engineer"),
            new Student("Marina", "Hristova", 20, "+359 2 34 73 78", "mar@mail.bg", new List<int> {5, 3, 6}, 2,     240411, "QA Engineer"),
            new Student("Gergana", "Ivanova", 21, "+359 038 345678", "gergran@abv.bg", new List<int> {6, 4, 6}, 1,  130314, "PHP Developer"),
            new Student("Hristina", "Stoilova", 17, "+3592/345678", "gergran@abv.bg", new List<int> {6, 3, 6}, 1,   121212, "PHP Developer"),
            new Student("Georgi", "Stamenov", 33, "+359 038 345678", "gergran@abv.bg", new List<int> {6, 6, 6}, 4,  131110, "Web Developer"),
            new Student("Dimitar", "Tenev", 28, "042 345678", "gergran@abv.bg", new List<int> {3, 4, 2}, 3,         141010, "PHP Developer")
        };

        List<StudentSpeciality> specialityes = new List<StudentSpeciality>
        {
            new StudentSpeciality(120313, "Web Developer"),
            new StudentSpeciality(381214, "QA Engineer"),
            new StudentSpeciality(141012, "Web Developer"),
            new StudentSpeciality(100910, "Web Developer"),
            new StudentSpeciality(310209, "PHP Developer"),
            new StudentSpeciality(220514, "QA Engineer"),
            new StudentSpeciality(240411, "QA Engineer"),
            new StudentSpeciality(130314, "PHP Developer"),
            new StudentSpeciality(121212, "PHP Developer"),
            new StudentSpeciality(131110, "Web Developer"),
            new StudentSpeciality(141010, "PHP Developer")
        };
            
            var filterByGroupTwo =
                from student in students
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;
            //filterByGroupTwo.ToList().ForEach(x => Console.WriteLine(x));

            var filterLastBeforeFirstName =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;
            //filterLastBeforeFirstName.ToList().ForEach(x => Console.WriteLine(x));

            var filterByAge =
                from student in students
                where (student.Age > 17) && (student.Age < 25)
                orderby student.Age
                select student.LastName + " " + student.FirstName + " " + student.Age + "\n";
            //filterByAge.ToList().ForEach(x => Console.WriteLine(x));

            var filterFistThenLastNameLAMBDA = students
                .OrderByDescending(x => x.FirstName)
                .ThenByDescending(x => x.LastName)
                .Select(x => x + "\n");
            //filterFistThenLastNameLAMBDA.ToList().ForEach(x => Console.WriteLine(x));

            var filterFistThenLastNameLINQ =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;
            //filterFistThenLastNameLINQ.ToList().ForEach(x => Console.WriteLine(x));

            var filterByABVmail = students
                .Where(x => x.Email.Contains("@abv.bg"))
                .OrderBy(x => x.FirstName)
                .Select(x => x);
            //filterByABVmail.ToList().ForEach(x => Console.WriteLine(x));

            var filterBySofiaPhone = students
                .Where(x => x.Phone.StartsWith("+359 2") ||
                    x.Phone.StartsWith("+3592") ||
                    x.Phone.StartsWith("+359 2"))
                .Select(x => x);
            //filterBySofiaPhone.ToList().ForEach(x => Console.WriteLine(x));

            var studentsWithSixMark = students
                .Where(x => x.Marks.Contains(6))
                .Select(x => new { Name = x.FirstName + " " + x.LastName, marks = x.MarksToString() });
            //studentsWithSixMark.ToList().ForEach(x => Console.WriteLine(x));

            var studentsWithTwoMark = students
                .Where(x => x.Marks.ContainsCuantity(2, 2))
                .Select(x => new { Name = x.FirstName + " " + x.LastName, marks = x.MarksToString() });
            //studentsWithTwoMark.ToList().ForEach(x => Console.WriteLine(x));

            var filterByYear = students
                .Where(x => (x.FacultyNumber.ToString().Substring(4, 2) == "14"))
                .Select(x => x.FirstName + " " + x.LastName + "marks : " + x.MarksToString());
            //filterByYear.ToList().ForEach(x => Console.WriteLine(x));

            var filterByGroupName =
                from student in students
                group student by student.GroupName;

            //filterByGroupName.ToList()
            //    .ForEach(group => group.ToList()
            //        .ForEach(student => Console.WriteLine("{0} : {1} {2}",
            //            student.GroupName, student.FirstName, student.LastName)));

            // Problem 14.	* Students Joined To Specialties
            var studentsJoinedSpecialityes =
                from member in specialityes
                join student in students on member.SpecialityNumber equals student.FacultyNumber
                orderby student.FirstName
                select student.FirstName + " " + student.LastName + " - " + member.SpecialityNumber + " : " + member.SpecialityName;
            studentsJoinedSpecialityes.ToList().ForEach(x => Console.WriteLine(x));

        }
    }
}
