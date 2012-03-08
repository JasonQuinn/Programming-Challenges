using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Diagnostics;

namespace Problem48
{
    class Program
    {
        /// <summary>
        /// The series, 1^(1) + 2^(2) + 3^(3) + ... + 10^(10) = 10405071317.
        /// Find the last ten digits of the series, 1^(1) + 2^(2) + 3^(3) + ... + 1000^(1000).
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            var sum = GetSumOfSeries(1000).ToString();
            Console.WriteLine("Last 10 digits-{0}", sum.Substring(sum.Count() - 10));
            timer.Stop();
            Console.WriteLine("Time taken-{0}", timer.Elapsed);
            Console.Read();
        }

        /// <summary>
        /// Returns the sum of the numbers in the series 1^(1) + 2^(2) + ... + n-1^(n-1) + n^(n)
        /// </summary>
        /// <param name="number">n</param>
        /// <returns>The sum of the numbers</returns>
        private static BigInteger GetSumOfSeries(int number)
        {
            BigInteger sum = new BigInteger();
            for (int i = 1; i <= number; i++)
            {
                BigInteger power = new BigInteger(i);
                for (int j = 1; j < i; j++)
                {
                    power = power * i;
                }
                sum += power;
            }
            return sum;
        }
    }
}
