using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Problem16
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = GetSumOfPower(2, 1000);
            Console.WriteLine(sum);
            Console.Read();
        }

        private static int GetSumOfPower(int number, int power)
        {
            BigInteger numberPowered = new BigInteger(number);

            for (int i = 1; i < power; i++)
            {
                numberPowered = numberPowered * number;
            }
            Func<BigInteger, int> SumOfDigits = n => n.ToString().Select(u => int.Parse(u.ToString())).Sum(u => u);
            int sum = SumOfDigits(numberPowered);
            return sum;
        }
    }
}
