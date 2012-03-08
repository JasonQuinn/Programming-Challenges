using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem5
{
    class Program
    {
        static void Main(string[] args)
        {
            int i=1;
            while (!IsDivisible(i))
            {
                i++;
            }
            Console.Write(i);
            Console.ReadLine();
        }

        private static bool IsDivisible(int number)
        {
            for (int i = 1; i <= 20; i++)
            {
                if (number % i != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
