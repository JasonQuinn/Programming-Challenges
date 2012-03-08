using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem36
{
    /// <summary>
    /// The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.
    /// 
    /// Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.
    /// 
    /// (Please note that the palindromic number, in either base, may not include leading zeros.)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Sum of palindromic numbers-{0}", GetSumOfPalindromicNumbers(1000000));
            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.Read();
        }

        private static int GetSumOfPalindromicNumbers(int maxNumber)
        {
            int sum = 0;
            for (int i = 1; i < maxNumber; i++)
            {
                if (IsPalidrome(i.ToString()))
                {
                    if (IsPalidrome(Convert.ToString(i, 2)))
                    {
                        sum += i;
                        Debug.Assert(sum > 0, "Overflow at sum");
                    }
                }
            }
            return sum;
        }

        private static bool IsPalidrome(string number)
        {
            char[] multipliedString = number.ToCharArray();
            if (number.ToCharArray().SequenceEqual(multipliedString.Reverse()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
