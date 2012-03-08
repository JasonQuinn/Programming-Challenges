using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetPalindromes());
            Console.ReadLine();
        }

        private static int GetPalindromes()
        {
            List<int> listOfPalindromes = new List<int>();
            for (int i = 999; i > 0; i--)
            {
                for (int j = 999; j > 0; j--)
                {
                    int multipliedNumber = j * i;
                    char[] multipliedString = multipliedNumber.ToString().ToCharArray();
                    if (multipliedString.SequenceEqual(multipliedString.Reverse()))
                    {
                        listOfPalindromes.Add(multipliedNumber);
                    }
                }
            }
            int largestPalindromes = listOfPalindromes.OrderBy(u => u).Last();
            return largestPalindromes;
        }
    }
}
