using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Problem38
{
    /// <summary>
    /// Take the number 192 and multiply it by each of 1, 2, and 3:
    /// 
    /// 192  1 = 192
    /// 192  2 = 384
    /// 192  3 = 576
    /// By concatenating each product we get the 1 to 9 pandigital, 192384576. We will call 192384576 the concatenated product of 192 and (1,2,3)
    /// 
    /// The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, giving the pandigital, 918273645, which is the concatenated product of 9 and (1,2,3,4,5).
    /// 
    /// What is the largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated product of an integer with (1,2, ... , n) where n > 1?
    /// </summary>
    class Program
    {
        static void Main()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            var products = new List<int>();
            for (int i = 1; i < 100000; i++)
            {
                string concatenatedProduct = ConcatenatedProductN(i);
                if(concatenatedProduct!=null)
                {
                    products.Add(int.Parse(ConcatenatedProductN(i)));
                }
            }
            Console.WriteLine("Max concatenated product-{0}", products.Max());

            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.Read();
        }

        static string ConcatenatedProductN(int startNumber)
        {
            return ConcatenatedProductN(startNumber.ToString(), 2, startNumber);
        }

        private static string ConcatenatedProductN(string concatenatedProduct, int n, int startNumber)
        {
            concatenatedProduct += n * startNumber;
            if (concatenatedProduct.Length > 9)
            {
                return null;
            }
            if (IsPandigital(concatenatedProduct))
            {
                return concatenatedProduct;
            }
            return ConcatenatedProductN(concatenatedProduct, n + 1, startNumber);
        }

        static bool IsPandigital(string number)
        {
            if (number.Length == 9)
            {
                if (number.Contains('1') && number.Contains('2') && number.Contains('3') && number.Contains('4') && number.Contains('5') &&
                    number.Contains('6') && number.Contains('7') && number.Contains('8') && number.Contains('9'))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
