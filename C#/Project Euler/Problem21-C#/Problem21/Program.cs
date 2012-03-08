using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem21
{
    /// <summary>
    /// Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
    /// If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
    /// 
    /// For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
    /// 
    /// Evaluate the sum of all the amicable numbers under 10000.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Sum of Amicable Numbers-{0}", GetAmicableNumbers(10000).Sum());
            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.Read();
        }

        private static IEnumerable<int> GetAmicableNumbers(int maxNumber)
        {
            List<int> amicableNumberList = new List<int>();
            for (int i = 2; i < maxNumber; i++)
            {
                int factorSum = GetFactorsSum(i);
                if (i != factorSum)// a ≠ b
                {
                    if (i == GetFactorsSum(factorSum))
                    {
                        if (!amicableNumberList.Contains(i))
                        {
                            amicableNumberList.Add(i);
                            amicableNumberList.Add(factorSum);
                        }
                    }
                }
            }
            return amicableNumberList;
        }

        private static int GetFactorsSum(int number)
        {
            return GetFactors(number).Sum();
        }

        /// <summary>
        /// Gets The factors of a number
        /// </summary>
        /// <param name="startingNumber"></param>
        /// <returns></returns>
        private static IEnumerable<int> GetFactors(int startingNumber)
        {
            List<int> factors = new List<int>();
            for (int i = 1; i < startingNumber; i++)
            {
                if (startingNumber % i == 0)
                {
                    factors.Add(i);
                }
            }
            return factors;
        }
    }
}
