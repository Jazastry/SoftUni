using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Class
    {
        public string ClassIndentifier { get; private set; }
        public List<Teacher> ClassTeachers { get; private set; }
        public string classDetails { get; private set; }

        public Class(string classIdentifier, List<Teacher> classTeachers, string details = "")
        {
            this.ClassIndentifier = classIdentifier;
            this.ClassTeachers = classTeachers;
            this.classDetails = details;
        }
    }
}
