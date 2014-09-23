using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Person
{
    class Person
    {
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("Name");
                }
                else 
                {
                    this.name = value;
                }
            }
        }
        private int age;
        public int Age
        {
            get
            {
                return this.age;
            }
            set 
            {
                if ((value < 1) || (value > 100))
                {
                    throw new IndexOutOfRangeException("Age");
                }
                else 
                {
                    this.age = value;
                }
            }
        }
        private string email = "";
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if((value != "") && (value.Contains("@")) || (value == null))
                {
                    this.email = value;
                }
                else 
                {
                    throw new ArgumentException("Input doesn't contain @ symbol.");
                }
            }
        }
        public Person(string name, int age, string email = "")
            :this (name, age)
        {
            this.Email = email;
        }
        public Person(string name, int age)            
        {
            this.Age = age;
            this.Name = name;
        }

        public override string ToString()
        {
            if (this.email == "" || this.email == null)
            {
                return String.Format("Person\nName:{0}\nAge:{1}", this.Name, this.Age);
            }
            return String.Format("Person\nName:{0}\nAge:{1}\nEmail:{2}", this.Name, this.Age, this.Email);
        }

        static void Main()
        {
            Person ivan = new Person("Ivan", 35);

            Console.WriteLine(ivan);
        }
    }
}
