using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MathNet.Numerics;

namespace Problem121
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            const int n = 15;
            const int r = (n - 1)/2;

            //create a array with 1 as the 1st value
            var p = new long[r+1];
            p[0] = 1;


            for (var k = 0; k < n+1; k++)
            {
                for (var i = r; i > 0; i--)
                {
                    p[i] += checked(k*p[i - 1]);
                }
            }
            Console.WriteLine(Math.Floor(SpecialFunctions.Factorial(n + 1)/p.Sum()));
            stopWatch.Stop();

            Console.WriteLine("Time -" + stopWatch.Elapsed);
            Console.ReadLine();
        }
    }
}
