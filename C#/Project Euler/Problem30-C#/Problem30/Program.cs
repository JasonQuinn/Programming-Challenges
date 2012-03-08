using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem30
{
    class Program
    {
        /// <summary>
        /// Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:
        /// 
        /// 1634 = 1^(4) + 6^(4) + 3^(4) + 4^(4)
        /// 8208 = 8^(4) + 2^(4) + 0^(4) + 8^(4)
        /// 9474 = 9^(4) + 4^(4) + 7^(4) + 4^(4)
        /// 
        /// As 1 = 1^(4) is not a sum it is not included.
        /// The sum of these numbers is 1634 + 8208 + 9474 = 19316.
        /// Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Sum of numbers-{0}", SumOfNumbers(7, 5));
            timer.Stop();
            Console.WriteLine("Time-{0}", timer);
            Console.Read();
        }

        private static int SumOfNumbers(int maxNumberOfDigits, int power)
        {
            Func<int, int, bool> NumberEqualsSumOfPowers = (n, p) => n.ToString().Select(d => Math.Pow(int.Parse(d.ToString()), p)).Sum() == n ? true : false;
            int sum = 0;
            for (int i = 2; i < maxNumberOfDigits * (Math.Pow(9, power)); i++)
            {
                if (NumberEqualsSumOfPowers(i, power))
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}
