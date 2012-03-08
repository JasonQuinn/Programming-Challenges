using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem26
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberOfRecurringCharacters(3);
        }

        private static int NumberOfRecurringCharacters(int divisor)
        {
            string number = (1 / (decimal)divisor).ToString().Substring(2);
            bool shouldContinue = true;
            int i = 0;
            while (shouldContinue && i < number.Length)
            {

            }

            return -1;
        }
    }
}
