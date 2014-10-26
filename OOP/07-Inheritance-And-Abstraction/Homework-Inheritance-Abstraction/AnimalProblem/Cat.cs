using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProblem
{
    class Cat : Animal,ISound
    {
        public Cat(string name, int age, Genders gender)
            : base(name, age, gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public void ProduceSound()
        {
            Console.WriteLine("Cat {0} say Miauuu.", this.Name);
        }
    }
}
