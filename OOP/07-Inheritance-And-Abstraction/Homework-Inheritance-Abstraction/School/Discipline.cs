using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Discipline
    {
        public string DisciplineName { get; private set; }
        public int NumberOfLectires { get; private set; }
        public List<Student> DisciplineStudents { get; private set; }
        public string disciplineDetails { get; private set; }

        public Discipline(string disciplineName, int numberOfLectures, List<Student> disciplineStudents, string disciplineDetails = "")
        {
            this.DisciplineName = disciplineName;
            this.NumberOfLectires = numberOfLectures;
            this.DisciplineStudents = disciplineStudents;
            this.disciplineDetails = disciplineDetails;
        }
    }
}
