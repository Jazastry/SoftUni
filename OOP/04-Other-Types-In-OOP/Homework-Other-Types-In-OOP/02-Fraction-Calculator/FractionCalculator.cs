using System;

public struct Fraction
{
    private int numerator;
    private int denominator;
    public int Numerator
    {
        get { return this.numerator; }
        set { this.numerator = value; }
    }

    public int Denominator
    {
        get { return this.denominator; }
        set
        {
            if (value == 0)
            {
                throw new ArgumentException("Denumenator can't be 0.");
            }
            else
            {
                this.denominator = value;
            }
        }
    }

    public Fraction(int numer, int denum) : this()
    {
        this.Numerator = numer;
        this.denominator = denum;
    }

    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        Fraction result = new Fraction();
        int a = f1.numerator;
        int b = f1.denominator;
        int c = f2.numerator;
        int d = f2.denominator;
        result.numerator = ((a * d) + (b * c));
        result.denominator = b * d;
        return result;
    }

    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        Fraction result = new Fraction();
        int a = f1.numerator;
        int b = f1.denominator;
        int c = f2.numerator;
        int d = f2.denominator;
        result.numerator = ((a * d) - (b * c));
        result.denominator = b * d;
        return result;
    }

    public override string ToString()
    {
        double result = (double)this.numerator / (double)this.denominator;
        return result.ToString();
    }
}


