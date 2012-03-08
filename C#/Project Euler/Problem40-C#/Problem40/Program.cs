using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem40
{
    /// <summary>
    /// An irrational decimal fraction is created by concatenating the positive integers:
    /// 
    /// 0.123456789101112131415161718192021...
    /// 
    /// It can be seen that the 12th digit of the fractional part is 1.
    /// 
    /// If dn represents the nth digit of the fractional part, find the value of the following expression.
    /// 
    /// d1 x d10  d100 x d1000 x d10000 x d100000 x d1000000
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            StringBuilder irrationalDecimalFraction = new StringBuilder();
            int i = 1;
            while (irrationalDecimalFraction.Length < 1000000)
            {
                irrationalDecimalFraction.Append(i);
                i++;
            }
            int value = int.Parse(irrationalDecimalFraction[0].ToString()) * int.Parse(irrationalDecimalFraction[9].ToString()) *
                int.Parse(irrationalDecimalFraction[99].ToString()) * int.Parse(irrationalDecimalFraction[999].ToString()) *
                int.Parse(irrationalDecimalFraction[9999].ToString()) * int.Parse(irrationalDecimalFraction[99999].ToString()) *
                int.Parse(irrationalDecimalFraction[999999].ToString());
            Console.WriteLine("Value-{0}", value);
            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.Read();
        }
    }
}
