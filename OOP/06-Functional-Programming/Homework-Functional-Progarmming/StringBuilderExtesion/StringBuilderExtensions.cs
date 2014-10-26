using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Extensions
{
    public static object Substring(this StringBuilder stringIn, int startIndex, int length)
    {
        if ((startIndex < 0) || (startIndex > stringIn.Length))
        {
            throw new IndexOutOfRangeException("Start Index");
        }
        else if ((length < 1) || (length > stringIn.Length))
        {
            throw new IndexOutOfRangeException("Length");
        }
        object result;
        result = stringIn.Remove(0, startIndex).Remove(startIndex + length, stringIn.Length);
        return result;
    }

    public static object RemoveText(this StringBuilder stringToClean, string textToMatch)
    {
        object result;
        result = stringToClean.Replace(textToMatch, "");
        return result;
    }

    public static string AppendAll<T>(this IEnumerable<T> head, IEnumerable<T> tail)
    {
        string result = String.Empty;
        head = head.Concat(tail);
        head.ToList().ForEach(x => result += x.ToString());
        return result;
    }
}

