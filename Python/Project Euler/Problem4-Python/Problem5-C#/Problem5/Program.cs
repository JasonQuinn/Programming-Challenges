using System;
using System.Diagnostics;

namespace Problem5
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            var i=20;
            while (!IsDivisible(i))
            {
                i+=20;
            }
            Console.Write(i);

            timer.Stop();
            Console.WriteLine("Timer-{0}", timer.Elapsed);
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
