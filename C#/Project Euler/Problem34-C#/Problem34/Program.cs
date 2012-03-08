using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem34
{
    /// <summary>
    /// 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
    /// 
    /// Find the sum of all numbers which are equal to the sum of the factorial of their digits.
    /// 
    /// Note: as 1! = 1 and 2! = 2 are not sums they are not included.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Sum Of Curious Numbers-{0}", SumCuriousNumber(100000));
            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.Read();
        }

        private static long SumCuriousNumber(int maxNumber)
        {
            long sum = 0;
            for (int i = 3; i < maxNumber; i++)
            {
                long sumOfDigitsFactorial = SumOfDigitsFactorial(i);
                if (i == sumOfDigitsFactorial)
                {
                    sum += sumOfDigitsFactorial;
                }
            }
            return sum;
        }

        private static long SumOfDigitsFactorial(long number)
        {
            return number.ToString().ToArray().Select(u => Factorial(long.Parse(u.ToString()))).Sum();
        }

        private static long Factorial(long number)
        {
            if (number <= 1)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }
    }
}
