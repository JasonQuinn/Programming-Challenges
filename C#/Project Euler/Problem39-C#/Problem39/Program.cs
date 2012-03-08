using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem39
{
    //If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.
    //
    //{20,48,52}, {24,45,51}, {30,40,50}
    //
    //For which value of p <= 1000, is the number of solutions maximised?
    class Program
    {
        #region Answer 2

        private static int[] perimeter = new int[1000];

        static void Main(string[] args)
        {
            int a, b, c;
            int total;

            for (int m = 2; m < 22; m++)
            {
                for (int n = m % 2 + 1; n < m; n += 2)
                {
                    if (gcd(m, n) == 1)
                    {

                        a = m * m - n * n;
                        b = 2 * m * n;
                        c = m * m + n * n;

                        total = a + b + c;

                        for (int loop = total; loop < 1000; loop += total)
                        {
                            perimeter[loop]++;
                        }
                    }
                }
            }

            int max = -1;
            int maxIndex = -1;

            for (int loop = 0; loop < 1000; loop++)
            {
                if (perimeter[loop] > max)
                {

                    max = perimeter[loop];
                    maxIndex = loop;
                }
            }

            Console.WriteLine("Maximum perimeter: " + maxIndex);
            Console.Read();

        }

        private static int gcd(int a, int b)
        {

            if (a == 1 || b == 1)
                return 1;
            else if (a % b == 0)
                return b;
            else if (b % a == 0)
                return a;
            else if (a > b)
                return gcd(a - (a / b) * b, b);
            else
                return gcd(a, b - (b / a) * a);

        }
        #endregion

        #region Answer 1
        //static void Main(string[] args)
        //{
        //    NumberOfSolutions(120);
        //    int maxNumberOfSolutions = 0;
        //    int maxP = 0;
        //    for (int p = 1; p <= 1000; p++)
        //    {
        //        int numSolutions = NumberOfSolutions(p);
        //        if (numSolutions > maxNumberOfSolutions)
        //        {
        //            maxNumberOfSolutions = numSolutions;
        //            maxP = p;
        //        }
        //    }
        //    Console.WriteLine("Max number of solutions-{0}", maxP);
        //    Console.Read();
        //}

        //static int NumberOfSolutions(int p)
        //{
        //    int count = 0;
        //    for (int a = 1; a < p; a++)
        //    {
        //        for (int b = a; a + b < p; b++)
        //        {
        //            for (int c = b; a + b + c <= p; c++)
        //            {
        //                if (a + b + c == p && Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)) == c)
        //                {
        //                    count++;
        //                }
        //            }
        //        }
        //    }
        //    return count;
        //}
        #endregion
    }
}
