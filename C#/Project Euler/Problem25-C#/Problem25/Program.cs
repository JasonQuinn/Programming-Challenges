using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Numerics;

namespace Problem25
{
    class Program
    {
        static void Main(string[] args)
        {
            int Count = FibonacciNumbers().TakeWhile(u => u.ToString().Count() < 1000).Count() + 1;
            Console.WriteLine(Count);
            Console.Read();
        }

        private static IEnumerable<BigInteger> FibonacciNumbers()
        {
            BigInteger[] fibonacciList = new BigInteger[2] { 1, 1 };
            yield return 1;
            yield return 1;
            while (true)
            {
                BigInteger fibonacciNumber = fibonacciList[0] + fibonacciList[1];
                Debug.Assert(fibonacciNumber > 0, "Overflow in fibonacciNumber");
                fibonacciList[0] = fibonacciList[1];
                fibonacciList[1] = fibonacciNumber;
                yield return fibonacciNumber;
            }
        }
    }
}
