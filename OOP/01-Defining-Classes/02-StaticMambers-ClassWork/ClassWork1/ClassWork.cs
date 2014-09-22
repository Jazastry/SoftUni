using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Person
{
    private static int instCount = 0;
    private static DateTime startDate;
    static Person()
    {
        Console.WriteLine("I`m Static const");
        Person.startDate = DateTime.Now;
    }
    public static int InstCount
    {
        get
        {
            return Person.instCount;
        }
    }
    public string Name { get; set; }
    public Person(string name = null)
    {
        this.Name = name;
        Person.instCount++;
    }
}
class Test
{
    static void Main()
    {
        Person p = new Person("Pesho");
        Console.WriteLine(p);

        Person empty = new Person();
        Console.WriteLine(empty);
    }
}

