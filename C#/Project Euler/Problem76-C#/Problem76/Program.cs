using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// It is possible to write five as a sum in exactly six different ways:
// 
//                           4 + 1
//                           3 + 2
//                           3 + 1 + 1
//                           2 + 2 + 1
//                           2 + 1 + 1 + 1
//                           1 + 1 + 1 + 1 + 1
// 
// How many different ways can one hundred be written as a sum of at least two positive integers?
namespace Problem76
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Number-{0}", NumberOfPos(100));
            Console.ReadLine();
        }

        private static long NumberOfPos(int number)
        {
            var sum = 0L;
            for (long k = 1; k < number; k++)
            {
                sum += TNK(number, k);
            }
            return sum;
        }

        private static long TNK(long n, long k)
        {
            if (k == 1 || n == k)
            {
                return 1;
            }
            if (k > n)
            {
                return 0;
            }
            return TNK(n - 1, k - 1) + TNK(n - k, k);
        }
    }
}
