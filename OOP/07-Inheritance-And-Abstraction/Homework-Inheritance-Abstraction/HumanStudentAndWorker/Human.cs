using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentAndWorker
{
    abstract class Human
    {

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Human()
        {
            
        }
    }
}
