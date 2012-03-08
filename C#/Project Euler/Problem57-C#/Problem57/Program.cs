using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

//http://projecteuler.net/problem=57
namespace Problem57
{
    class Program
    {
        static void Main()
        {
            var timer = new Stopwatch();
            timer.Start();

            var set = ExpandedSet().Take(1000).Where(u => u.Numerator.ToString().Count() > u.Denominator.ToString().Count());
            Console.WriteLine(
                string.Format("There are {0} numbers where the Numerator has more digits than the Denominator", set.Count()));

            timer.Stop();
            Console.WriteLine(string.Format("Time elapsed - {0}", timer.Elapsed));
            Console.ReadLine();
        }

        static IEnumerable<Fraction> ExpandedSet()
        {
            for (var i = 1; ; i++)
            {
                yield return 1 + Expand(i);
            }
        }

        static Fraction Expand(int count)
        {
            return count == 1 ? new Fraction(1, 2) : new Fraction(1, 2 + Expand(count - 1));
        }
    }
}
