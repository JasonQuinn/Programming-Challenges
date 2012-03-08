using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem33
{
    //The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.
    //
    //We shall consider fractions like, 30/50 = 3/5, to be trivial examples.
    //
    //There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.
    //
    //If the product of these four fractions is given in its lowest common terms, find the value of the denominator.
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            List<KeyValuePair<int, int>> fractionList = GetFractionList();
            List<KeyValuePair<int, int>> curiousFractionList = GetCuriousFractionList(fractionList);
            double product = 1;
            foreach (KeyValuePair<int, int> keyValuePair in curiousFractionList)
            {
                product *= ((double)keyValuePair.Key / (double)keyValuePair.Value);
            }
            Console.WriteLine("Denominator-{0}", 1d / product);
            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.Read();
        }

        private static List<KeyValuePair<int, int>> GetCuriousFractionList(List<KeyValuePair<int, int>> fractionList)
        {
            List<KeyValuePair<int, int>> curiousFractionList = new List<KeyValuePair<int, int>>();
            foreach (KeyValuePair<int, int> fraction in fractionList)
            {
                if (IsCuriousFraction(fraction))
                {
                    curiousFractionList.Add(fraction);
                }
            }
            return curiousFractionList;
        }

        /// <summary>
        /// Is the fraction curious
        /// </summary>
        /// <param name="keyValuePair"></param>
        /// <returns></returns>
        private static bool IsCuriousFraction(KeyValuePair<int, int> keyValuePair)
        {
            if (keyValuePair.Key.ToString()[0] == keyValuePair.Value.ToString()[0])
            {
                decimal firstNumber = ((decimal)keyValuePair.Key / (decimal)keyValuePair.Value);
                decimal secondNumber = (decimal.Parse(keyValuePair.Key.ToString()[1].ToString()) / decimal.Parse(keyValuePair.Value.ToString()[1].ToString()));
                if (firstNumber == secondNumber && secondNumber < 1)
                {
                    return true;
                }
            }
            if (keyValuePair.Key.ToString()[0] == keyValuePair.Value.ToString()[1])
            {
                decimal firstNumber = ((decimal)keyValuePair.Key / (decimal)keyValuePair.Value);
                decimal secondNumber = (decimal.Parse(keyValuePair.Key.ToString()[1].ToString()) / decimal.Parse(keyValuePair.Value.ToString()[0].ToString()));
                if (firstNumber == secondNumber && secondNumber < 1)
                {
                    return true;
                }
            }
            if (keyValuePair.Key.ToString()[1] == keyValuePair.Value.ToString()[0])
            {
                decimal firstNumber = ((decimal)keyValuePair.Key / (decimal)keyValuePair.Value);
                decimal secondNumber = (decimal.Parse(keyValuePair.Key.ToString()[0].ToString()) / decimal.Parse(keyValuePair.Value.ToString()[1].ToString()));
                if (firstNumber == secondNumber && secondNumber < 1)
                {
                    return true;
                }
            }
            if (keyValuePair.Key.ToString()[1] == keyValuePair.Value.ToString()[1])
            {
                decimal firstNumber = ((decimal)keyValuePair.Key / (decimal)keyValuePair.Value);
                decimal secondNumber = (decimal.Parse(keyValuePair.Key.ToString()[0].ToString()) / decimal.Parse(keyValuePair.Value.ToString()[0].ToString()));
                if (firstNumber == secondNumber && secondNumber < 1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns the lsit of fractions
        /// </summary>
        private static List<KeyValuePair<int, int>> GetFractionList()
        {
            List<KeyValuePair<int, int>> fractionList = new List<KeyValuePair<int, int>>();
            for (int i = 11; i < 100; i++)
            {
                if (i % 10 != 0)
                {
                    for (int j = i; j < 100; j++)
                    {
                        if (j % 10 != 0)
                        {
                            if (i.ToString().Any(u => j.ToString().Contains(u)))
                            {
                                fractionList.Add(new KeyValuePair<int, int>(i, j));
                            }
                        }
                    }
                }
            }
            return fractionList;
        }
    }
}
