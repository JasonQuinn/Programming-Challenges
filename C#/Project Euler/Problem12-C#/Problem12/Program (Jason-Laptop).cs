using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem12
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(SolveUsingLinq(500));
            Console.Read();
        }

        static int SolveUsingLinq(int numberOfFactors)
        {
            var test = EnumSequenceOfTriangleNumbers().TakeWhile(u => CountFactor(u) <= (numberOfFactors));
            int number=EnumSequenceOfTriangleNumbers().ElementAt(test.Count());
            return number;
        }

        /// <summary>
        /// Returns a stream of triangle numbers, starting from the second triangle number: 3.
        /// </summary>
        static IEnumerable<int> EnumSequenceOfTriangleNumbers()
        {
            int i = 2;
            int n = 1;
            while (true)
            {
                n += i++;
                yield return n;
            }
        }

        /// <summary>
        /// Returns the number of factors / divisors for the given number using the steps outlined.
        /// </summary>
        /// <param name="n">The number to have its factors counted.</param>
        /// <returns>The number of factors.</returns>
        static int CountFactor(int n)
        {
            int count = 2;
            int divisor = 2;
            int quotient = n / divisor;

            while (quotient > divisor)
            {
                if (n % divisor == 0)
                {
                    count += 2;
                }
                quotient = n / ++divisor;
            }

            if (quotient == divisor && n % divisor == 0)
            {
                count++;
            }
            return count;
        }
    }
}