using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem23
{
    /// <summary>
    /// A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
    /// 
    /// A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
    /// 
    /// As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.
    /// 
    /// Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
    /// </summary>
    class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            List<int> abundant = GetAbundant();
            int total = 0;
            bool[] sumabundant = new bool[56248];
            for (int i = 0, d = 0; i < abundant.Count && d < 28124; i++)
            {
                d = abundant[i];
                for (int f = 0, g = 0; f < abundant.Count && g < 28124; f++)
                {
                    g = abundant[f];
                    sumabundant[d + g] = true;
                }
            }
            for (int i = 1; i < 28124; i++)
            {
                if (sumabundant[i] == false)
                {
                    total += i;
                }
            }
            Console.WriteLine(total);

            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.Read();
        }

        private static List<int> GetAbundant()
        {
            int number = 2;
            int divider;
            int totalDiv;
            List<int> abundant = new List<int>();
            while (number < 28124)
            {
                divider = 2;
                totalDiv = 1;
                while ((number / 2) >= divider)
                {
                    if (number % divider == 0)
                    {
                        totalDiv += divider;
                    }
                    divider++;
                }
                if (totalDiv > number)
                {
                    abundant.Add(number);
                }
                number++;
            }
            return abundant;
        }
    }
}