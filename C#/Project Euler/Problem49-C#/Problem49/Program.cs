using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// http://projecteuler.net/index.php?section=problems&id=49
//
// The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: (i) each of the three terms are prime, and, (ii) each of the 4-digit numbers are permutations of one another.
// 
// There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, but there is one other 4-digit increasing sequence.
// 
// What 12-digit number do you form by concatenating the three terms in this sequence?
namespace Problem49
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TestPrimes());
            Console.ReadLine();
        }

        //Breaks if there are 3 primes which are a permutation of the first
        static List<string> TestPrimes()
        {
            var fourDigitPrimes = GetPrimes().SkipWhile(u => u.ToString().Length < 4).TakeWhile(u => u.ToString().Length == 4).ToList();

            var numberList = new List<string>();
            for (int i = 0; i < fourDigitPrimes.Count(); i++)
            {
                int? primeOne = fourDigitPrimes.ElementAt(i);
                int? primeTwo = null;
                int? primeThree = null;
                int? diff = null;
                for (int j = i + 1; j < fourDigitPrimes.Count(); j++)
                {
                    if (SortStringChars(fourDigitPrimes.ElementAt(i)) == SortStringChars(fourDigitPrimes.ElementAt(j)))
                    {
                        if (primeTwo != null && fourDigitPrimes.ElementAt(j) - primeTwo == diff)
                        {
                            primeThree = fourDigitPrimes.ElementAt(j);
                            numberList.Add(primeOne.ToString() + primeTwo.ToString() + primeThree.ToString());
                        }
                        else
                        {
                            primeTwo = fourDigitPrimes.ElementAt(j);
                            diff = primeTwo - primeOne;
                        }
                    }
                }
                primeTwo = null;
                primeThree = null;
                diff = null;
            }
            return numberList;
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

        public static string SortStringChars(int s)
        {
            char[] c = s.ToString().ToCharArray();
            Array.Sort(c);
            return new String(c);
        }

    }
}
