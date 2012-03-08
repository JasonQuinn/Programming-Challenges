using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem9
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(GetPythagoreanTriplet(1000));
            Console.Read();
        }

        private static int GetPythagoreanTriplet(int total)
        {
            for (int a = 1; a < total; a++)
            {
                for (int b = a; b < total; b++)
                {
                    for (int c = b; c < total; c++)
                    {
                        if (a + b + c == total && Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2))
                        {
                            return (a * b * c);
                        }
                    }
                }
            }
            return -1;
        }
    }
}
