using System;
using System.Collections.Generic;
using Exceptions_Homework;

class Exceptions
{
    static void Main()
    {
        var substr = Extensions.Subsequence("Hello!".ToCharArray(), 2, 5);
        Console.WriteLine(substr);

        var subarr = Extensions.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Extensions.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Extensions.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(Extensions.ExtractEnding("I love C#", 2));
        Console.WriteLine(Extensions.ExtractEnding("Nakov", 4));
        Console.WriteLine(Extensions.ExtractEnding("beer", 4));
        Console.WriteLine(Extensions.ExtractEnding("Hi", 100));

        Extensions.CheckPrime(23);
        Extensions.CheckPrime(33);

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
