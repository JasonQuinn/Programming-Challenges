using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> fibonacciList = new List<int>();
            fibonacciList.Add(1);
            fibonacciList.Add(2);
            while ((fibonacciList[fibonacciList.Count - 2] + fibonacciList[fibonacciList.Count - 1]) <= 4000000)
            {
                fibonacciList.Add(fibonacciList[fibonacciList.Count - 2] + fibonacciList[fibonacciList.Count - 1]);
            }
            Console.Write("Sum=" + fibonacciList.Where(u => u % 2 == 0).Sum(u => u));
            Console.ReadLine();
        }
    }
}
