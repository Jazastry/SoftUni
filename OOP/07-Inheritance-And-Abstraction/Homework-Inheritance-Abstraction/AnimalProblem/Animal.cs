using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProblem
{

    public abstract class Animal
    {
        private string name;
        private int age;
        private Genders gender;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name is null or empty.");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if ((value < 0) || (value > 150))
                {
                    throw new ArgumentOutOfRangeException("Age is not correct.");
                }
                this.age = value;
            }
        }
        public Genders Gender
        {
            get { return this.gender; }
            set
            {
                this.gender = value;
            }
        }
        public Animal(string name, int age, Genders gender)
        {
            this.Age = age;
            this.Name = name;
            this.Gender = gender;
        }

        public Animal()
        {
        }
    }
}
