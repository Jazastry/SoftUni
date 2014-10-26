using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentAndWorker
{
    class Student : Human
    {
        private string facultyNumber;

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (value.Length < 6)
                {
                    throw  new ArgumentOutOfRangeException("StudentFacultyNumber is not valid.");
                }
                this.facultyNumber = value;
            }
        }

        public Student(string firstName, string lastName, string facultyNumber = "000000")
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }
    }
}
