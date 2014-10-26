using System;
using System.Collections.Generic;
using System.Linq;

namespace StringDisperser
{
    class Program
    {
        static void Main(string[] args)
        {
            StringDisparser myDisparser = new StringDisparser("alabala", "shukar", "gingiribin",
                "alkahadram");

            // Demonstrate Deep Clone of IClonable implementation
            StringDisparser clonedDisparser = (StringDisparser)myDisparser.Clone();
            clonedDisparser.stringsInput[3] = "blkahadram";

            Console.WriteLine("First DIsparser : {0}\nCloned Disparser : {1}\n",myDisparser, clonedDisparser);

            List<StringDisparser> disparsers = new List<StringDisparser>() {myDisparser, clonedDisparser};

            // Demonstrate ICOmparable implementation
            var orderedDisparsers = disparsers.OrderBy(dispar => dispar).ToList();
            foreach (StringDisparser disparser in orderedDisparsers)
            {
                Console.WriteLine(disparser);
            }

            // Demonstrate IEnumerable implementation
            foreach (var ch in myDisparser)
            {
                Console.Write(ch + " ");
            }
        }
    }
}
