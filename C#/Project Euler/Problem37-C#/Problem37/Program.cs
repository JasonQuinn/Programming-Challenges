using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem37
{
    /// <summary>
    /// The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.
    /// 
    /// Find the sum of the only eleven primes that are both truncatable from left to right and right to left.
    /// 
    /// NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.
    /// </summary>
    class Program
    {
        static List<int> primesList;

        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Sum={0}", SumOfTruncatablePrimes());
            timer.Stop();
            Console.WriteLine("Time={0}", timer.Elapsed);
            Console.Read();
        }

        private static int SumOfTruncatablePrimes()
        {
            List<int> truncatablePrimes = new List<int>();
            primesList = GetPrimes().Take(100000).ToList();
            List<int> primes = GetPrimes().Take(100000).Where(u => (u.ToString().First() == '2' && u.ToString().LastIndexOf('2') == 0) || u.ToString().First() == '3' || u.ToString().First() == '5' || u.ToString().First() == '7').Where(u => u.ToString().Last() == '3' || u.ToString().Last() == '5' || u.ToString().Last() == '7').ToList();
            for (int i = 3; ; i++)
            {
                int prime = primes.ElementAt(i);
                if (IsTruncatablePrime(prime))
                {
                    truncatablePrimes.Add(prime);
                    if (truncatablePrimes.Count == 11)
                    {
                        return truncatablePrimes.Sum();
                    }
                }
            }
        }

        private static bool IsTruncatablePrime(int numberToCheck)
        {
            if (LeftTrunciate(numberToCheck.ToString()))
            {
                if (RightTrunciate(numberToCheck.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool LeftTrunciate(string numberToCheck)
        {
            if (numberToCheck.Length == 0)
            {
                return true;
            }
            else
            {
                int number = int.Parse(numberToCheck);
                if (primesList.TakeWhile(u => u <= number).LastOrDefault() == number)
                {
                    return LeftTrunciate(numberToCheck.Substring(1));
                }
                else
                {
                    return false;
                }
            }
        }

        private static bool RightTrunciate(string numberToCheck)
        {
            if (numberToCheck.Length == 0)
            {
                return true;
            }
            else
            {
                int number = int.Parse(numberToCheck);
                if (primesList.TakeWhile(u => u <= number).LastOrDefault() == number)
                {
                    return RightTrunciate(numberToCheck.Substring(0, numberToCheck.Length - 1));
                }
                else
                {
                    return false;
                }
            }
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
