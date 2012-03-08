using System;
using System.Collections;
using System.Diagnostics;

namespace Problem50
{
    /// <summary>
    /// The prime 41, can be written as the sum of six consecutive primes:
    /// 
    /// 41 = 2 + 3 + 5 + 7 + 11 + 13
    /// This is the longest sum of consecutive primes that adds to a prime below one-hundred.
    /// 
    /// The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.
    /// 
    /// Which prime, below one-million, can be written as the sum of the most consecutive primes?
    /// </summary>
    class Program
    {
        static void Main()
        {
            var sw = new Stopwatch();
            sw.Start();
            ArrayList primes = GeneratePrimes(1000000);
            primes.Remove(1);
            long result = 0;
            long maxlength = 0;
            Console.WriteLine("starting check");
            for (int start = 0; start < primes.Count; start++)
            {
                long temp = 0;
                for (int i = start; i < primes.Count; i++)
                {
                    temp = temp + (long)primes[i];
                }
                for (int k = primes.Count - 1; k > start; k--)
                {
                    if (temp < 1000000 && primes.Contains(temp) && k - start >= maxlength)
                    {
                        maxlength = k - start;
                        result = temp;
                        Console.WriteLine(result);
                        break;
                    }
                    temp = temp - (long)primes[k];
                    if (temp <= start)
                        break;
                }
            }
            Console.WriteLine(result);
            Console.WriteLine(maxlength);
            Console.WriteLine(sw.Elapsed);
            Console.ReadLine();
        }
        static ArrayList GeneratePrimes(long num)
        {
            var retValue = new ArrayList { (long)2, (long)3 };
            long stepper = 5;
            long check = 1;
            while (stepper <= num)
            {
                foreach (long i in retValue)
                {
                    if (stepper % i == 0)
                    {
                        check = 0;
                        break;
                    }
                    if (Math.Sqrt(stepper) < i)
                    {
                        break;
                    }
                }
                if (check == 1)
                {
                    //Console.WriteLine(((float)Stepper / (float)num) * 100);
                    retValue.Add(stepper);
                }
                check = 1;
                stepper++;
                stepper++;
            }
            return retValue;
        }
    }
}
