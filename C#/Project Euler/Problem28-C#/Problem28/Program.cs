using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Numerics;

namespace Problem28
{
    class Program
    {
        
        /// <summary>
        /// Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:
        /// 
        /// 21 22 23 24 25
        /// 20  7  8  9 10
        /// 19  6  1  2 11
        /// 18  5  4  3 12
        /// 17 16 15 14 13
        /// 
        /// It can be verified that the sum of the numbers on the diagonals is 101.
        /// What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Sum-{0}", GetSum(1001));
            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.Read();
        }

        private static BigInteger GetSum(int spiralSize)
        {
            var value = new BigInteger(1);
            var sum = new BigInteger(1);
            var increment = new BigInteger(2);
            var i = 1;
            while (i < spiralSize * 2 - 1)
            {
                value += increment;
                sum += value;
                if (i % 4 == 0)
                {
                    increment += 2;
                }
                i++;
            }
            return sum;
        }
    }
}
