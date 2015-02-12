using System;

namespace DynamicListExecutable
{
    using CustomLinkedList;

    class Program
    {
        static void Main(string[] args)
        {
            DynamicList<int> list = new DynamicList<int>();

            Console.WriteLine(list);
        }
    }
}
