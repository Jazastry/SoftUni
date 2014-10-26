namespace InterestClculator
{
    using System;

    public class InterestCalculator 
    {
        public double Money { get; private set; }
        public double Interest { get; private set; }
        public int Years { get; private set; }
        public static string CalcType { get; set; }
        public double Result { get; set; }

        public InterestCalculator(double money, double interest, int years, CalculateInterestDelegate calc)
        {
            this.Money = money;
            this.Interest = interest;
            this.Years = years;
            this.Result = calc(money, interest, years);
        }

        public static double GetSimpleInterest(double sum, double interest, int years)
        {
            double result = sum * (1 + ((interest/100) * years));
            CalcType = "simple";
            return result;            
        }
        public static double GetCompoundInterest(double sum, double interest, int years)
        {
            int n = 12;
            double result = sum * Math.Pow((1 + ((interest / 100)/n)), years*n);
            CalcType = "compound";
            return result;
        }

        public override string ToString()
        {
            string result = String.Format(
                        " sum : {0}\n interest : {1}%\n years : {2}\n type of interest : {3}\n Result : {4:.0000}\n",
                        this.Money, this.Interest, this.Years, CalcType, this.Result);
            return result;
        }
    }
}

