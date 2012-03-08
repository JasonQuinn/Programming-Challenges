using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem31
{
    /// <summary>
    /// In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:
    /// 
    /// 1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
    /// It is possible to make £2 in the following way:
    /// 
    /// 1x£1 + 1x50p + 2x20p + 1x5p + 1x2p + 3x1p
    /// How many different ways can £2 be made using any number of coins?
    /// </summary>
    class Program
    {
        static int[] coins = { 200, 100, 50, 20, 10, 5, 2, 1 };

        static int FindCount(int money, int maxcoin)
        {
            int sum = 0;
            if (maxcoin == 7)
            {
                return 1;
            }
            for (int i = maxcoin; i < 8; i++)
            {
                if (money - coins[i] == 0)
                {
                    sum += 1;
                }
                if (money - coins[i] > 0)
                {
                    sum += FindCount(money - coins[i], i);
                }
            }
            return sum;
        }

        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Count={0}", FindCount(200, 0));
            timer.Stop();
            Console.WriteLine("Time={0}", timer.Elapsed);
            Console.Read();
        }
    }
}
