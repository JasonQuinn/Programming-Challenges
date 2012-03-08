using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem41
{
    //We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital and is also prime.
    //
    //What is the largest n-digit pandigital prime that exists?
    class Program
    {
        static List<string> pandigitalNumbers = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Pandigital Number-{0}", GetHighestPandigitalNumbers());
            Console.Read();
        }

        private static List<string> SetNumbers(int n)
        {
            List<string> numbers = new List<string>();
            for (int i = n; i >= 1; i--)
            {
                numbers.Add(i.ToString());
            }
            return numbers;
        }

        static string GetHighestPandigitalNumbers()
        {
            GetPandigitalNumbers(string.Empty, SetNumbers(7), 7);//
            var primer = GetPrimes().TakeWhile(u => u <= int.Parse(pandigitalNumbers[0])).ToList();
            foreach (string pandigitalNumber in pandigitalNumbers)
            {
                if (primer.Contains(int.Parse(pandigitalNumber)))
                {
                    return pandigitalNumber;
                }
            }
            return null;
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

        static void GetPandigitalNumbers(string pandigitalNumber, List<string> numbers, int count)
        {
            if (count <= 0)
            {
                if (!pandigitalNumbers.Contains(pandigitalNumber))
                {
                    pandigitalNumbers.Add(pandigitalNumber);
                }
            }
            else
            {
                if (pandigitalNumbers.Count > 10000)
                {
                    return;
                }
                foreach (string number in numbers)
                {
                    if (!pandigitalNumber.Contains(number))
                    {
                        GetPandigitalNumbers(pandigitalNumber + number, numbers, count - 1);
                    }
                }
            }

        }
    }
}
