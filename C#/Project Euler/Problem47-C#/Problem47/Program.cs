using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

// The first two consecutive numbers to have two distinct prime factors are:
// 
// 14 = 2 x 7
// 15 = 3 x 5
// 
// The first three consecutive numbers to have three distinct prime factors are:
// 
// 644 = 2² x 7 x 23
// 645 = 3 x 5 x 43
// 646 = 2 x 17 x 19.
// 
// Find the first four consecutive integers to have four distinct primes factors. What is the first of these numbers?
namespace Problem47
{
    class Program
    {
        private static List<int> _Primes;
        private static int _PrimesToTake = 2;
        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("First Number-{0}",FirstInSequence(4, 4));
            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.ReadLine();
        }

        private static int FirstInSequence(int numOfConsecutiveNumbers, int numberOfDistinctPrimes)
        {
            
            int currentNumOfConsecutive = 0;
            int firstInSequence = -1;
            for (int i = 0; currentNumOfConsecutive < numOfConsecutiveNumbers; i++)
            {
                if(GetPrimeFactors(i).Distinct().Count() == numberOfDistinctPrimes)
                {
                    currentNumOfConsecutive++;
                    if(currentNumOfConsecutive == 1)
                    {
                        firstInSequence = i;
                    }
                    else if(currentNumOfConsecutive == numOfConsecutiveNumbers)
                    {
                        return firstInSequence;
                    }
                }
                else
                {
                    currentNumOfConsecutive = 0;
                }
            }
            return -1;
        }

        private static IEnumerable<int> GetPrimes()
        {
            yield return 2;
            var primesSoFar = new List<long> {2};

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

        private static IEnumerable<int> GetPrimeFactors(int number)
        {
            var primeFactorList = new List<int>();
            var position = 0;
            var primeToTest = -1;
            while (number > 1 && primeToTest <= number)
            {
                try
                {
                    primeToTest = _Primes.ElementAt(position);
                    if (number%primeToTest == 0)
                    {
                        primeFactorList.Add(primeToTest);
                        number = number/primeToTest;
                    }
                    else
                    {
                        position++;
                    }
                }
                catch
                {
                    _PrimesToTake *= 2;
                    _Primes = GetPrimes().Take(_PrimesToTake).ToList();
                }
            }
            return primeFactorList;
        }
    }
}
