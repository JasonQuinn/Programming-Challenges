using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

// It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a prime and twice a square.
// 
// 9  = 7 + 2x1^2
// 15 = 7 + 2x2^2
// 21 = 3 + 2x3^2
// 25 = 7 + 2x3^2
// 27 = 19 + 2x2^2
// 33 = 31 + 2x1^2
// It turns out that the conjecture was false.
// 
// What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?
namespace Problem46
{
    class Program
    {
        private static List<int> _Primes;
        private static int _PrimesToTake = 2;

        static void Main()
        {
            var timer = new Stopwatch();
            timer.Start();
            foreach (var compostieNumber in GetCompositeNumbers())
            {
                if(!IsSumOfPrimeAndTwoTimesSquare(compostieNumber))
                {
                    Console.WriteLine(compostieNumber);
                    break;
                }
            }
            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.ReadLine();
        }

        private static IEnumerable<int> GetCompositeNumbers()
        {
            for (int i = 5; ; i += 2)
            {
                for (int j = 3; j < i; j += 2)
                {
                    if (i % j == 0)
                    {
                        yield return i;
                        break;
                    }
                }
            }
        }

        private static bool IsSumOfPrimeAndTwoTimesSquare(int number)
        {
            if (_Primes == null || number > _Primes.Max())
            {
                _PrimesToTake *= 2;
                _Primes = GetPrimes().Take(_PrimesToTake).ToList();
            }
            for (int i = 0; _Primes.ElementAt(i) < number; i++)
            {
                int n = number - _Primes.ElementAt(i);
                if (n % 2 == 0)
                {
                    n /= 2;
                    if (Math.Sqrt(n) % 1 == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static IEnumerable<int> GetPrimes()
        {
            yield return 2;
            var primesSoFar = new List<long> { 2 };

            Func<long, bool> isPrime = n => primesSoFar.TakeWhile(p => p <= (long)Math.Sqrt(n)).FirstOrDefault(p => n % p == 0) == 0;
            for (int i = 3; ; i += 2)
            {
                if (isPrime(i))
                {
                    yield return i;
                    primesSoFar.Add(i);
                }
            }
        }
    }
}
