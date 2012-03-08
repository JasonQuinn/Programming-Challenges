using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem35
{
    /// <summary>
    /// The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.
    /// 
    /// There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.
    /// 
    /// How many circular primes are there below one million?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Circular Count-{0}", CircularNumbersCount(1000000));
            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.Read();
        }

        /// <summary>
        /// Returns a count of all the Circular Prime under the maxNumber
        /// </summary>
        /// <param name="maxNumber">The max number to try</param>
        /// <returns>Count of circular numbers</returns>
        private static int CircularNumbersCount(int maxNumber)
        {
            int count = 0;
            int[] primes = GetPrimes().TakeWhile(u => u < maxNumber).ToArray();
            for (int i = 2; i < maxNumber; i++)
            {
                if (IsCircularPrime(i.ToString(), primes))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Returns a bool indicating if the number is a Circular Prime
        /// </summary>
        /// <param name="number">Number to test</param>
        /// <param name="primes">A list of prime numbers</param>
        /// <returns>
        /// True if number is a circular prime
        /// False if number is not a circular prime
        /// </returns>
        private static bool IsCircularPrime(string number, int[] primes)
        {
            //If number countaine 0,2,4,5,6,8 it can be divided by 2 or 5 so cant be a prime number
            if (number.Length > 1 && (number.Contains('0') || number.Contains('2') || number.Contains('4') || number.Contains('5') || number.Contains('6') || number.Contains('8')))
            {
                return false;
            }
            //Check each number in the circular number if its not prime return false
            for (int i = 0; i < number.Length; i++)
            {
                int numberInt = int.Parse(number);
                if (primes.ElementAt(primes.TakeWhile(u => u <= numberInt && numberInt % u != 0).Count()) != numberInt)
                {
                    return false;
                }
                number = number.Substring(1) + number[0];
            }
            //Is a prime number
            return true;
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
