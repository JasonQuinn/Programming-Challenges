using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Euler's Totient function, φ(n) [sometimes called the phi function], is used to determine the number of numbers less than n which are relatively prime to n. For example, as 1, 2, 4, 5, 7, and 8, are all less than nine and relatively prime to nine, φ(9)=6.
// 
// n	Relatively Prime	φ(n)	n/φ(n)
// 2	1	                1	    2
// 3	1,2	                2   	1.5
// 4	1,3	                2	    2
// 5	1,2,3,4         	4   	1.25
// 6	1,5	                2	    3
// 7	1,2,3,4,5,6	        6   	1.1666...
// 8	1,3,5,7	            4   	2
// 9	1,2,4,5,7,8     	6	    1.5
// 10	1,3,7,9         	4   	2.5
// It can be seen that n=6 produces a maximum n/φ(n) for n  10.
// 
// Find the value of n  1,000,000 for which n/φ(n) is a maximum.
namespace Problem69
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Max Value-{0}", MaxEulerTotientFunction());
            Console.ReadLine();
        }

        private static decimal MaxEulerTotientFunction()
        {
            var maxValue = -1m;
            var nForMax = -1;
            for (int i = 2; i <= 1000000; i++)
            {
                var number = i / EulerTotientFunction(i);
                if (number > maxValue)
                {
                    maxValue = number;
                    nForMax = i;
                }
            }
            return nForMax;
        }

        private static decimal EulerTotientFunction(int number)
        {
            var primeFactors = GetPrimeFactors(number).Distinct();
            return primeFactors.Aggregate<int, decimal>(number, (current1, primeFactor) => current1 * (1 - 1 / (decimal)primeFactor));
        }

        private static IEnumerable<int> GetPrimeFactors(int number)
        {
            var primeFactorList = new List<int>();
            var position = 0;
            var primeToTest = -1;
            while (number > 1 && primeToTest / 2 <= number)
            {
                primeToTest = Primes.ElementAt(position);
                if (number % primeToTest == 0)
                {
                    primeFactorList.Add(primeToTest);
                    number = number / primeToTest;
                }
                else
                {
                    position++;
                }
            }
            return primeFactorList;
        }

        private static readonly List<int> Primes = FindPrimesBySieveOfAtkins(1000000);
        private static List<int> FindPrimesBySieveOfAtkins(int max)
        {
            var isPrime = new BitArray((int)max + 1, false);
            var sqrt = (int)Math.Sqrt(max);

            Parallel.For(1, sqrt, x =>
            {
                var xx = x * x;
                for (int y = 1; y <= sqrt; y++)
                {
                    var yy = y * y;
                    var n = 4 * xx + yy;
                    if (n <= max && (n % 12 == 1 || n % 12 == 5))
                        isPrime[n] = !isPrime[n];

                    n = 3 * xx + yy;
                    if (n <= max && n % 12 == 7)
                        isPrime[n] = !isPrime[n];

                    n = 3 * xx - yy;
                    if (x > y && n <= max && n % 12 == 11)
                        isPrime[n] = !isPrime[n];
                }
            });

            var primes = new List<int> { 2, 3 };
            for (int n = 5; n <= sqrt; n++)
            {
                if (isPrime[n])
                {
                    primes.Add(n);
                    int nn = n * n;
                    for (int k = nn; k <= max; k += nn)
                        isPrime[k] = false;
                }
            }

            for (int n = sqrt + 1; n <= max; n++)
                if (isPrime[n])
                    primes.Add(n);

            return primes;
        }

    }
}
