using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Teacher : People
    {
        public List<Discipline> Disciplines { get; private set; }
        public string Details { get; private set; }

        public Teacher(string name, List<Discipline> disciplines, string details = "")
            : base(name)
        {
            this.Disciplines = disciplines;
            this.Details = details;
        }
    }
}
