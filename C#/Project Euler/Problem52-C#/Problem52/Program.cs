using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem52
{
    /// <summary>
    /// It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order.
    /// 
    /// Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            Console.WriteLine("Smallest number ={0}", SmallestNumber());

            timer.Stop();
            Console.WriteLine("Time={0}", timer.Elapsed);
            Console.Read();
        }

        private static int SmallestNumber()
        {
            Func<int, int, bool> ContainsTheSameDigits = (n, m) => n.ToString().OrderBy(u => u).Count() == (n * m).ToString().OrderBy(u => u).Count() ? (n.ToString().OrderBy(u => u).Intersect((n * m).ToString().OrderBy(u => u)).Count() == n.ToString().OrderBy(u => u).Count()) : false;

            int i = 1;
            while (true)
            {
                if (ContainsTheSameDigits(i, 2) && ContainsTheSameDigits(i, 3) && ContainsTheSameDigits(i, 4) && ContainsTheSameDigits(i, 5) && ContainsTheSameDigits(i, 6))
                {
                    break;
                }
                i++;
            }
            return i;
        }
    }
}
