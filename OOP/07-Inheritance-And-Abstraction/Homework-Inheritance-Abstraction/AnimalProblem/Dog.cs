using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProblem
{
    class Dog : Animal
    {
        public Dog(string name, int age, Genders gender)
            : base(name, age, gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public void ProduceSound()
        {
            Console.WriteLine("Dog {0} say Bauuu.", this.Name);
        }
    }
}
