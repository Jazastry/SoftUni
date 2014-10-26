using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProblem
{
    class Kitten : Cat,ISound
    {
        public Genders gender = Genders.Female;

        public Kitten(string name, int age)
            : base(name, age, Genders.Female)
        {
            
        }

        public void ProduceSound()
        {
            Console.WriteLine("Kitten {0} say MiauuHHHrrr.", this.Name);
         
        }
    }
}
