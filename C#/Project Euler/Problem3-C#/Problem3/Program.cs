using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            const long n = 600851475143;
            //var test = new Primes().ToList();
            Console.WriteLine(GetPrimes().TakeWhile(x => x < (long)Math.Sqrt(n)).Where(x => n % x == 0).Last());
            Console.ReadLine();
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
