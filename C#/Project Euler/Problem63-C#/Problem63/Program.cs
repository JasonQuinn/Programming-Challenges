using System;
using System.Numerics;

// The 5-digit number, 16807=7^5, is also a fifth power. Similarly, the 9-digit number, 134217728=8^9, is a ninth power.
// 
// How many n-digit positive integers exist which are also an nth power?
namespace Problem63
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Count-{0}",NumberOfNDigitIntegers());
            Console.ReadLine();
        }

        private static int NumberOfNDigitIntegers()
        {
            var count = 0;
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 21; j++)
                {
                    var power = BigInteger.Pow(i, j);
                    if (power.ToString().Length == j)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}