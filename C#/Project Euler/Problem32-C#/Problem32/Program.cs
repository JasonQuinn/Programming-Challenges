using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem32
{
    /// <summary>
    /// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.
    /// 
    /// The product 7254 is unusual, as the identity, 39 X 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.
    /// 
    /// Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
    /// 
    /// HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            Console.WriteLine("Sum-{0}",SumOfPandigitalNumbers());            

            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.Read();
        }

        private static int SumOfPandigitalNumbers()
        {
            List<int> pandigitalList = new List<int>();
            for (int i = 1; i < 9999; i++)
            {
                for (int j = 1; j < 9999; j++)
                {
                    string value = string.Concat(i, j, i * j);
                    if (value.Length > 9)
                    {
                        j = 9999;
                        break;
                    }
                    else
                    {
                        if (!pandigitalList.Contains(i * j) && IsPandigital(value))
                        {
                            pandigitalList.Add(i * j);
                        }
                    }
                }
            }
            return pandigitalList.Sum(u => u);
        }

        static bool IsPandigital(string number)
        {
            if (number.Length == 9)
            {
                if (number.Contains('1') && number.Contains('2') && number.Contains('3') && number.Contains('4') && number.Contains('5') &&
                    number.Contains('6') && number.Contains('7') && number.Contains('8') && number.Contains('9'))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
