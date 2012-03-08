using System;
using System.Collections.Generic;

// A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:
// 
// 1/2	= 	0.5
// 1/3	= 	0.(3)
// 1/4	= 	0.25
// 1/5	= 	0.2
// 1/6	= 	0.1(6)
// 1/7	= 	0.(142857)
// 1/8	= 	0.125
// 1/9	= 	0.(1)
// 1/10	= 	0.1
// Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.
// 
// Find the value of d  1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
namespace Problem26
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 0;
            int maxd = 0;
            for (int d = 2; d < 1000; ++d)
            {
                var reminders = new HashSet<int>();
                int x = 1;
                int len = 0;
                while (x < d)
                {
                    x *= 10;
                }

                while (x != 0)
                {
                    if (reminders.Contains(x))
                    {
                        break;
                    }

                    reminders.Add(x);

                    while (x < d)
                    {
                        x *= 10;
                        len++;
                    }
                    x = x % d;
                }
                if (x != 0)
                {
                    if (len > max)
                    {
                        maxd = d;
                        max = len;
                    }
                }
            }
            Console.WriteLine(maxd);
            Console.ReadLine();
        }
    }
}
