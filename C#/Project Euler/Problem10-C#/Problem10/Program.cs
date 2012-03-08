using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetPrimes().TakeWhile(u => u < 2000000).Sum(u => (long)u));
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
