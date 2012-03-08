﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

// Pentagonal numbers are generated by the formula, Pn=n(3n-1)/2. The first ten pentagonal numbers are:
// 
// 1, 5, 12, 22, 35, 51, 70, 92, 117, 145, ...
// 
// It can be seen that P4 + P7 = 22 + 70 = 92 = P8. However, their difference, 70 - 22 = 48, is not pentagonal.
// 
// Find the pair of pentagonal numbers, Pj and Pk, for which their sum and difference is pentagonal and D = |Pk - Pj| is minimised; what is the value of D?
namespace Problem44
{
    class Program
    {
        static void Main()
        {
            var timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("D-{0}", TestPentagonalNumbers());
            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.ReadLine();
        }

        private static long TestPentagonalNumbers()
        {
            var pentagonalList = new List<long>();
            for (int i = 1; ; i++)
            {
                var p = PentagonalNumber(i);
                foreach (var j in pentagonalList)
                {
                    var diff = p - j;
                    if(IsPentagonal(diff))
                    {
                        var intSum = p + j;
                        if(IsPentagonal(intSum))
                        {
                            return diff;
                        }
                    }
                }
                pentagonalList.Add(p);
            }
        }

        private static bool IsPentagonal(long x)
        {
            var n = (Math.Sqrt((24 * x) + 1) + 1) / 6;
            return n%1 == 0 && n > 0;
        }

        private static long PentagonalNumber(long n)
        {
            return (n * (3 * n - 1)) / 2;
        }
    }
}
