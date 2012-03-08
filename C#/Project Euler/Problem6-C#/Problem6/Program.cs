using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SquareOfSums(100) - SumOfSquares(100));
            Console.Read();
        }

        private static int SumOfSquares(int numberOfNumbers)
        {
            int sumOfSquares = 0;
            for (int i = 1; i <= numberOfNumbers; i++)
            {
                sumOfSquares += (int)Math.Pow(i, 2);
            }
            return sumOfSquares;
        }

        private static int SquareOfSums(int numberOfNumbers)
        {
            int sum = 0;
            for (int i = 1; i <= numberOfNumbers; i++)
            {
                sum += i;
            }
            return (int)Math.Pow(sum, 2);
        }
    }
}
