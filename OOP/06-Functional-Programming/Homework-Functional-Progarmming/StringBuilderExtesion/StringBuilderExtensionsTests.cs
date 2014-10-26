using System;
using System.Text;
using ;

class StringBuilderExtensionsTests
{
    private static void Main()
    {
        string testSubstring = "abcde";
        testSubstring = testSubstring.Substring(4, 1);
        Console.WriteLine(testSubstring);

        StringBuilder testRemoveString = new StringBuilder("Softuruniurur");
        testRemoveString.RemoveText("ur");
        Console.WriteLine(testRemoveString);

        int[] headArrayInt = { 1, 2, 3, 4, 5 };
        int[] tailArrayInt = { 6, 7, 8 };
        string apended = headArrayInt.AppendAll<int>(tailArrayInt);
        Console.WriteLine(apended);

        string[] headArrayString = { "Rock", " and", " roll" };
        string[] tailArrayString = { " ba", "by !" };
        apended = headArrayString.AppendAll<string>(tailArrayString);
        Console.WriteLine(apended);
    }
}

