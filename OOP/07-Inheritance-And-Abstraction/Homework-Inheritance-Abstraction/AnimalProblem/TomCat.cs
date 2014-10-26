using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProblem
{
    class TomCat : Animal
    {
        public const Genders gander = Genders.Male;

        public TomCat(string name, int age)
            : base(name, age, Genders.Male)
        {
            
        }

        public void ProduceSound()
        {
            Console.WriteLine("TomCat {0} say MiauuHHHrrr.", this.Name);
         
        }
    }
}
