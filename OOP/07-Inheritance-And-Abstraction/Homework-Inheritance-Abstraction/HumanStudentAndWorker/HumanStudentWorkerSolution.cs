using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentAndWorker 
{
    class HumanStudentWorkerSolution : Human
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Ivan", "Ivanov", "112233"),
                new Student("Boril", "Hristov","112244"),
                new Student("Hristo", "Petkov", "113344"),
                new Student("Svetla", "Zarova","221122"),
                new Student("Joro", "Marov", "222133"),
                new Student("Elena", "Stoichkova","114421"),
                new Student("Mira", "Mirkova", "334431"),
                new Student("Stoil", "Moilov","334531"),
                new Student("Todor", "Kalashnikov", "123331"),
                new Student("Dragan", "Batmanov", "564312")
            };

            var studentsOrdered = students.OrderBy(student => student.FacultyNumber).ToList();
            Console.WriteLine("Students Ordered : ");
            studentsOrdered
                .ForEach(student => Console.WriteLine("{0} {1} : {2}",
                    student.FirstName, student.LastName, student.FacultyNumber));
            Console.WriteLine();

            List<Worker> workers = new List<Worker>()
            {
                new Worker("Hugo", "Iorgan", 150, 7),
                new Worker("Zil", "Haratov", 220, 10.5),
                new Worker("Cesho", "Penev", 120, 6.30),
                new Worker("Suzana", "Eleikova", 500, 12.5),
                new Worker("Druka", "Tamska", 150, 8.35),
                new Worker("Ginka", "Koicheva", 230, 8),
                new Worker("Meto", "Metov", 277.30, 9.20),
                new Worker("Strahil", "Golotov", 333, 3.33),
                new Worker("Gabargo", "Muhomorkov", 50, 3.27),
                new Worker("Zelka", "Zelenkova", 1000, 2.31)
            };
            var workersOrderd =
                workers.OrderByDescending(worker => worker
                    .MoneyPreHour(worker.WeekSalary, worker.WorkHoursPerDay)).ToList();

            Console.WriteLine("Workers Orderd : ");
            workersOrderd.ForEach(worker => Console.WriteLine("{0} {1} : {2:.00}",
                worker.FirstName, worker.LastName, worker.MoneyPreHour(worker.WeekSalary, worker.WorkHoursPerDay)));
            Console.WriteLine();

            Console.WriteLine("Students and Worers Ordered : ");
            IList<Human> studentsAndWorkers = new List<Human>();
            students.ForEach(o => studentsAndWorkers
                    .Add(new Student(o.FirstName, o.LastName)));

            workers.ForEach(o => studentsAndWorkers
                    .Add(new Worker(o.FirstName, o.LastName )));

            var orderedStudWork = studentsAndWorkers
                .OrderBy(human => human.FirstName)
                .ThenBy(human => human.LastName);

            foreach (var human in orderedStudWork)
            {
                Console.WriteLine(human.FirstName + " " + human.LastName);
            }
        }
    }
}
