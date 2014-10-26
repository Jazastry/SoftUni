using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student : People
    {
        private string classNumb;

        public string ClassNumb
        {
            get { return this.classNumb; }
            set
            {
                if ((value == null))
                {
                    throw new ArgumentException("ClassNumber property is null or invalid value.");
                }
                this.classNumb = value;
            }
        }

        private string studentDetails = "";


        public Student(string name, string classNumb, string details = "")
            : base(name)
        {
            this.ClassNumb = classNumb;
            this.studentDetails = details;

        }
    }
}
