using System;

namespace LinqExtensions
{
    class TestsLinqExtensions
    {
        static void Main()
        {
            // WhereNot example
            int[] intInArray = new int[10];

            for (int i = 0; i < 10; i++)
            {
                intInArray[i] = i;
            }

            Console.WriteLine("WhereNot : ");
            var intOutList = intInArray.WhereNot(x => x < 5);
            foreach (var item in intOutList)
            {
                Console.Write(item);
            }

            Console.WriteLine();

            // Repeat
            var outTestRepeat = intInArray.Repeat(3);
            Console.WriteLine("\nRepeat : ");
            foreach (var item in outTestRepeat)
            {
                Console.Write(item);
            }

            // WhereEndsWith
            string[] stringTestArray =
            {
                "amara",
                "rocky",
                "figure",
                "burbon",
                "strobe",
                "salvare",
                "figura"
            };
            string[] sufixes = { "ra", "re" };
            var outTestEndsWith = stringTestArray.WhereEndsWith<string>(sufixes);

            Console.WriteLine("\n\nWhereEndsWith");
            foreach (var item in outTestEndsWith)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }
    }
}
