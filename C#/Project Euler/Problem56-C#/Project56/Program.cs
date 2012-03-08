using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Diagnostics;

namespace Project56
{
    //A googol (10^100) is a massive number: one followed by one-hundred zeros; 100^100 is almost unimaginably large: one followed by two-hundred zeros. Despite their size, the sum of the digits in each number is only 1.
    //
    //Considering natural numbers of the form, a^b, where a, b  100, what is the maximum digital sum?
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            Console.WriteLine("Max Sum of digits-{0}", GetMaxSum());

            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.Read();
        }

        private static BigInteger GetMaxSum()
        {
            Func<BigInteger, int> SumOfDigits = n => n.ToString().Sum(u => int.Parse(u.ToString()));

            BigInteger max = new BigInteger();

            for (int i = 1; i < 100; i++)
            {
                for (int j = 1; j < 100; j++)
                {
                    BigInteger tempSum = SumOfDigits(Power(i, j));
                    if (tempSum > max)
                    {
                        max = tempSum;
                    }
                }
            }
            return max;
        }

        private static BigInteger Power(int a, int b)
        {
            if (a <= 1)
            {
                return b;
            }
            else
            {
                return b * Power(--a, b);
            }
        }
    }
}
