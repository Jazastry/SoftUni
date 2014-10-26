using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProblem
{
    class AnimalSolution
    {
        static void Main()
        {
            List<Cat> cats = new List<Cat>()
            {
                new Cat("Miki", 3, Genders.Female),
                new Cat("Gigi", 5, Genders.Male),
                new Cat("Shushi", 2, Genders.Female)
            };

            List<Dog> dogs = new List<Dog>()
            {
                new Dog("Rex", 10, Genders.Male),
                new Dog("Horhe", 6, Genders.Male),
                new Dog("Lasi", 20, Genders.Female)
            };

            List<Kitten> kitten = new List<Kitten>()
            {
                 new Kitten("Sisi", 1),
                 new Kitten("Fufi", 3),
                 new Kitten("Buxi", 4)
            };

            List<TomCat> tomCats = new List<TomCat>()
            {
                 new TomCat("Alfons", 12),
                 new TomCat("Gerom", 12),
                 new TomCat("Salam", 12)
            };

            Console.WriteLine("Cats average age is {0:.00}", Average(cats));
            Console.WriteLine("Dogs average age is {0:.00}", Average(dogs));
            Console.WriteLine("Kitten average age is {0:.00}", Average(kitten));
            Console.WriteLine("Tomcats average age is {0:.00}", Average(tomCats));

        }

        private static double Average(IEnumerable<Animal> items)
        {
            double total = 0;
            var internalItems = items.ToList();
            internalItems.ForEach(cat => total += cat.Age);
            double average = total / internalItems.Count;
            return average;
        }

    }
}
