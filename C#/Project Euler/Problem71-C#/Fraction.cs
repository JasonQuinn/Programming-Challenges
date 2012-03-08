using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Problem71
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

        public Fraction Add(BigInteger number)
        {
            Numerator = number * Denominator + Numerator;
            return this;
        }

        private static Fraction Add(BigInteger number, Fraction fraction)
        {
            return fraction.Add(number);
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
