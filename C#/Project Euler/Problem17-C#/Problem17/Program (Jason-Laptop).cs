using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem17
{
    /// <summary>
    /// If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
    /// 
    /// If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
    /// 
    /// NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of "and" when writing out numbers is in compliance with British usage.
    /// 
    /// </summary>
    class Program
    {
        static Dictionary<int, string> numberLengths = new Dictionary<int, string>();

        static void Main(string[] args)
        {
            numberLengths.Add(1, "One");
            numberLengths.Add(2, "Two");
            numberLengths.Add(3, "Three");
            numberLengths.Add(4, "Four");
            numberLengths.Add(5, "Five");
            numberLengths.Add(6, "Six");
            numberLengths.Add(7, "Seven");
            numberLengths.Add(8, "Eight");
            numberLengths.Add(9, "Nine");
            numberLengths.Add(10, "Ten");
            numberLengths.Add(11, "Eleven");
            numberLengths.Add(12, "Twelve");
            numberLengths.Add(13, "Thirteen");
            numberLengths.Add(14, "Fourteen");
            numberLengths.Add(15, "Fifteen");
            numberLengths.Add(16, "Sixteen");
            numberLengths.Add(17, "Seventeen");
            numberLengths.Add(18, "Eighteen");
            numberLengths.Add(19, "Nineteen");
            numberLengths.Add(20, "Twenty");
            numberLengths.Add(30, "Thirty");
            numberLengths.Add(40, "Forty");
            numberLengths.Add(50, "Fifty");
            numberLengths.Add(60, "Sixty");
            numberLengths.Add(70, "Seventy");
            numberLengths.Add(80, "Eighty");
            numberLengths.Add(90, "Ninety");
            numberLengths.Add(100, "Hundred");
            numberLengths.Add(1000, "Thousand");

            LetterCount(1015);
            Console.WriteLine(CountOfNumbers(1000));
            Console.Read();
        }

        private static int CountOfNumbers(int maxNumber)
        {
            int sum = 0;
            for (int i = 1; i <= maxNumber; i++)
            {
                sum += LetterCount(i);
            }
            return sum;
        }

        /// <summary>
        /// Gets the number of letters in a number
        /// </summary>
        /// <param name="number">int Number (must be less tan or equal to 1000)</param>
        /// <returns>The number of letters in the number</returns>
        private static int LetterCount(int number)
        {
            string numberInWords = string.Empty;
            string numberString = number.ToString();
            if (numberString.Length == 4)
            {
                numberInWords += numberLengths.First(u => u.Key == int.Parse(numberString[0].ToString())).Value;
                numberInWords += numberLengths.First(u => u.Key == 1000).Value;

                numberString = numberString.Substring(1);
                if (numberString[0] == '0' && numberString[1] == '0' && numberString[1] == '0')
                {
                    numberString = numberString.Substring(1);
                    numberString = numberString.Substring(1);
                    numberString = numberString.Substring(1);
                }
            }
            if (numberString.Length >= 3)
            {
                numberInWords += numberLengths.First(u => u.Key == int.Parse(numberString[0].ToString())).Value;
                numberInWords += numberLengths.First(u => u.Key == 100).Value;

                numberString = numberString.Substring(1);
                if (numberString[0] != '0' || numberString[1] != '0')
                {
                    numberInWords += "And";
                }
                else
                {
                    numberString = numberString.Substring(1);
                    numberString = numberString.Substring(1);
                }
            }
            if (numberString.Length >= 2)
            {
                if (numberString[0] == '1')
                {
                    numberInWords += numberLengths.First(u => u.Key == int.Parse(numberString[0].ToString() + numberString[1].ToString())).Value;
                    numberString = numberString.Substring(1);
                }
                else if (numberString[0] != '0')
                {
                    numberInWords += numberLengths.First(u => u.Key == int.Parse(numberString[0].ToString() + "0")).Value;
                }
                numberString = numberString.Substring(1);
            }
            if (numberString.Length >= 1 && numberString[0] != '0')
            {
                numberInWords += numberLengths.First(u => u.Key == int.Parse(numberString[0].ToString())).Value;
                numberString = numberString.Substring(1);
            }
            return numberInWords.Length;
        }
    }
}
