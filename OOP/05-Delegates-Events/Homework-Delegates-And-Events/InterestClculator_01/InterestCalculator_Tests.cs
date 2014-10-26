using System;
using InterestClculator;

public class InterestCalculator_Tests
{
    static void Main()
    {
        CalculateInterestDelegate delegateSimpleInterest = new CalculateInterestDelegate(InterestCalculator.GetSimpleInterest);
        InterestCalculator calculateSimpleInterest = new InterestCalculator(2500, 7.2, 15, delegateSimpleInterest);
        Console.WriteLine(calculateSimpleInterest);

        CalculateInterestDelegate delegateCompoundInterest = new CalculateInterestDelegate(InterestCalculator.GetCompoundInterest);
        InterestCalculator calculateCompoundInterest = new InterestCalculator(500, 5.6, 10, delegateCompoundInterest);
        Console.WriteLine(calculateCompoundInterest);
    }
}

