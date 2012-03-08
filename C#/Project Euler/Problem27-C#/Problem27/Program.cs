using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem27
{
    /// <summary>
    /// Euler published the remarkable quadratic formula:
    /// 
    /// n² + n + 41
    /// 
    /// It turns out that the formula will produce 40 primes for the consecutive values n = 0 to 39. However, when n = 40, 402 + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, and certainly when n = 41, 41² + 41 + 41 is clearly divisible by 41.
    /// 
    /// Using computers, the incredible formula  n²  79n + 1601 was discovered, which produces 80 primes for the consecutive values n = 0 to 79. The product of the coefficients, 79 and 1601, is 126479.
    /// 
    /// Considering quadratics of the form:
    /// 
    /// n² + an + b, where |a|  1000 and |b|  1000
    /// 
    /// where |n| is the modulus/absolute value of n
    /// e.g. |11| = 11 and |4| = 4
    /// Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            Func<int, int, int, int> Quadratic = (n, a, b) => (int)Math.Pow(n, 2) + a * n + b;

            List<int> primes = GetPrimes().TakeWhile(u => u <= Quadratic(100, 999, 999)).ToList();

            timer.Start();
            int maxA = 0;
            int maxB = 0;
            int maxCount = 0;

            for (int a = -999; a < 1000; a++)
            {
                for (int b = primes[0], c = 0; b < 999; b = primes[c++])
                {
                    int n = 0;
                    int quadraticValue = Quadratic(n, a, b);

                    while (primes.TakeWhile(u => u <= quadraticValue).LastOrDefault() == quadraticValue)
                    {
                        n++;
                        quadraticValue = Quadratic(n, a, b);
                    }
                    if (n - 1 > maxCount)
                    {
                        Debug.Assert(primes.LastOrDefault() > quadraticValue);
                        maxA = a;
                        maxB = b;
                        maxCount = n - 1;
                    }
                }
            }
            Console.WriteLine("Product of a and b={0}", maxA * maxB);
            timer.Stop();
            Console.WriteLine("Time={0}", timer.Elapsed);
            Console.Read();
        }

        private static IEnumerable<int> GetPrimes()
        {
            yield return 2;
            var primesSoFar = new List<long>();
            primesSoFar.Add(2);

            Func<long, bool> IsPrime = n => primesSoFar.TakeWhile(p => p <= (long)Math.Sqrt(n)).FirstOrDefault(p => n % p == 0) == 0;
            for (int i = 3; true; i += 2)
            {
                if (IsPrime(i))
                {
                    yield return i;
                    primesSoFar.Add(i);
                }
            }
        }
    }
}
