using System;
using System.Diagnostics;
using System.Numerics;

namespace Problem53
{
    //There are exactly ten ways of selecting three from five, 12345:
    //123, 124, 125, 134, 135, 145, 234, 235, 245, and 345

    //In combinatorics, we use the notation, 5C3 = 10.

    //In general,
    //nCr =	n!
    //    _______
    //    r!(n-r)!
    //,where r  n, n! = n(n1)...321, and 0! = 1.

    //It is not until n = 23, that a value exceeds one-million: 23C10 = 1144066.

    //How many, not necessarily distinct, values of  nCr, for 1  n  100, are greater than one-million?
    static class Program
    {
        static void Main()
        {
            var timer = new Stopwatch();
            timer.Start();

            Console.WriteLine("Count over 1 million-{0}", CountValuesOver1Million());

            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.Read();
        }

        private static int CountValuesOver1Million()
        {
            int overMillionCount = 0;

            for (int n = 23; n <= 100; n++)
            {
                for (int r = 0; r <= n; r++)
                {
                    if (C(n, r) > 1000000)
                    {
                        overMillionCount++;
                    }
                }
            }
            return overMillionCount;
        }

        static BigInteger C(BigInteger n, BigInteger r)
        {
            BigInteger bottomSection = Factorial(r) * Factorial(n - r);
            if (bottomSection != 0)
            {
                return Factorial(n) / bottomSection;
            }
            return -1;
        }

        static BigInteger Factorial(BigInteger number)
        {
            if (number <= 1)
            {
                return 1;
            }
            return number * Factorial(number - 1);
        }
    }
}
