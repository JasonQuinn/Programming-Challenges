using System;
using System.Collections.Generic;
using System.Diagnostics;

// A number chain is created by continuously adding the square of the digits in a number to form a new number until it has been seen before.
// 
// For example,
// 
// 44 -> 32 -> 13 -> 10 -> 1 -> 1
// 85 -> 89 -> 145 -> 42 -> 20 -> 4 -> 16 -> 37 -> 58 -> 89
// 
// Therefore any chain that arrives at 1 or 89 will become stuck in an endless loop. What is most amazing is that EVERY starting number will eventually arrive at 1 or 89.
// 
// How many starting numbers below ten million will arrive at 89?
namespace Problem92
{
    class Program
    {
        static void Main()
        {
            var timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Count-{0}", CountTimes());
            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.ReadLine();
        }

        private static int CountTimes()
        {
            var dictionary = CreateDictionary();
            var count = 0;
            for (var i = 1; i < 10000000; i++)
            {
                var number = Next(i);
                while (number != 1 && number != 89)
                {
                    dictionary.TryGetValue(number,out number);
                }
                if (number == 89)
                {
                    count++;
                }
            }
            return count;
        }

        private static Dictionary<int, int> CreateDictionary()
        {
            var dictionary = new Dictionary<int, int>();
            for (var i = 1; i <= 587; i++)
            {
                dictionary.Add(i, Next(i));
            }
            return dictionary;
        }

        private static int Next(int n)
        {
            var result = 0;
            while (n > 0)
            {
                result += (n % 10) * (n % 10);
                n /= 10;
            }
            return result;
        }
    }
}
