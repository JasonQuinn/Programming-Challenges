using System.Numerics;

namespace Problem57
{
    public class Fraction
    {
        public BigInteger Numerator { get; private set; }

        public BigInteger Denominator { get; private set; }

        public Fraction(BigInteger numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction(BigInteger numerator, Fraction denominator)
        {
            Numerator = numerator * denominator.Denominator;
            Denominator = denominator.Numerator;
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", Numerator, Denominator);
        }

        public void Add(BigInteger number)
        {
            Numerator = number * Denominator + Numerator;
        }

        public static Fraction Add(BigInteger number, Fraction fraction)
        {
            fraction.Add(number);
            return fraction;
        }

        public static Fraction operator +(BigInteger c1, Fraction c2)
        {
            return Add(c1, c2);
        }

        public static Fraction operator +(Fraction c1, BigInteger c2)
        {
            return Add(c2, c1);
        }
    }
}
