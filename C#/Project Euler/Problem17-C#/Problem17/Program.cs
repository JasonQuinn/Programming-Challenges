using System;
using System.Collections.Generic;
using System.Linq;

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
        static readonly Dictionary<int, string> NumberLengths = new Dictionary<int, string>();

        static void Main()
        {
            NumberLengths.Add(1, "One");
            NumberLengths.Add(2, "Two");
            NumberLengths.Add(3, "Three");
            NumberLengths.Add(4, "Four");
            NumberLengths.Add(5, "Five");
            NumberLengths.Add(6, "Six");
            NumberLengths.Add(7, "Seven");
            NumberLengths.Add(8, "Eight");
            NumberLengths.Add(9, "Nine");
            NumberLengths.Add(10, "Ten");
            NumberLengths.Add(11, "Eleven");
            NumberLengths.Add(12, "Twelve");
            NumberLengths.Add(13, "Thirteen");
            NumberLengths.Add(14, "Fourteen");
            NumberLengths.Add(15, "Fifteen");
            NumberLengths.Add(16, "Sixteen");
            NumberLengths.Add(17, "Seventeen");
            NumberLengths.Add(18, "Eighteen");
            NumberLengths.Add(19, "Nineteen");
            NumberLengths.Add(20, "Twenty");
            NumberLengths.Add(30, "Thirty");
            NumberLengths.Add(40, "Forty");
            NumberLengths.Add(50, "Fifty");
            NumberLengths.Add(60, "Sixty");
            NumberLengths.Add(70, "Seventy");
            NumberLengths.Add(80, "Eighty");
            NumberLengths.Add(90, "Ninety");
            NumberLengths.Add(100, "Hundred");
            NumberLengths.Add(1000, "Thousand");

            Console.WriteLine(CountOfNumbers(1000));
            Console.Read();
        }

        private static int CountOfNumbers(int maxNumber)
        {
            int sum = 0;
            for (var i = 1; i <= maxNumber; i++)
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
                numberInWords += NumberLengths.First(u => u.Key == int.Parse(numberString[0].ToString())).Value;
                numberInWords += NumberLengths.First(u => u.Key == 1000).Value;

                numberString = numberString.Substring(1);
                if (numberString[0] == '0' && numberString[1] == '0' && numberString[2] == '0')
                {
                    numberString = numberString.Substring(1);
                    numberString = numberString.Substring(1);
                    numberString = numberString.Substring(1);
                }
            }
            if (numberString.Length >= 3)
            {
                numberInWords += NumberLengths.First(u => u.Key == int.Parse(numberString[0].ToString())).Value;
                numberInWords += NumberLengths.First(u => u.Key == 100).Value;

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
                    numberInWords += NumberLengths.First(u => u.Key == int.Parse(numberString[0].ToString() + numberString[1].ToString())).Value;
                    numberString = numberString.Substring(1);
                }
                else if (numberString[0] != '0')
                {
                    numberInWords += NumberLengths.First(u => u.Key == int.Parse(numberString[0].ToString() + "0")).Value;
                }
                numberString = numberString.Substring(1);
            }
            if (numberString.Length >= 1 && numberString[0] != '0')
            {
                numberInWords += NumberLengths.First(u => u.Key == int.Parse(numberString[0].ToString())).Value;
                numberString = numberString.Substring(1);
            }
            return numberInWords.Length;
        }
    }
}
