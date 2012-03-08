using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetMaxLength(1000000));
            Console.Read();
        }

        private static int GetMaxLength(int p)
        {
            int maxCount = -1;
            int maxCountNumber = -1;
            for (int i = 1; i < p; i++)
            {
                int count = GetCount(i);
                if (count > maxCount)
                {
                    maxCount = count;
                    maxCountNumber = i;
                }
            }
            return maxCountNumber;
        }

        private static int GetCount(long n)
        {
            int count = 1;
            while (n != 1)
            {
                n=GetNextInt(n);
                count++;
            }
            return count;
        }

        private static long GetNextInt(long p)
        {
            Debug.Assert(p > 0, "OverFlow");
            if (p % 2 == 0)
            {
                return p / 2;
            }
            else
            {
                return (3 * p) + 1;
            }            
        }
    }
}
