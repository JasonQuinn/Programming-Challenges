using System;
using System.Diagnostics;

namespace Problem112
{
    /// <summary>
    /// Working from left-to-right if no digit is exceeded by the digit to its left it is called an increasing number; for example, 134468.
    /// 
    /// Similarly if no digit is exceeded by the digit to its right it is called a decreasing number; for example, 66420.
    /// 
    /// We shall call a positive integer that is neither increasing nor decreasing a "bouncy" number; for example, 155349.
    /// 
    /// Clearly there cannot be any bouncy numbers below one-hundred, but just over half of the numbers below one-thousand (525) are bouncy. In fact, the least number for which the proportion of bouncy numbers first reaches 50% is 538.
    /// 
    /// Surprisingly, bouncy numbers become more and more common and by the time we reach 21780 the proportion of bouncy numbers is equal to 90%.
    /// 
    /// Find the least number for which the proportion of bouncy numbers is exactly 99%.
    /// </summary>
    class Program
    {
        static void Main()
        {
            var timer = new Stopwatch();
            timer.Start();

            var amountOfBouncyNumbers = 0;
            int bouncyNumber;

            var i = 0;
            do
            {
                bouncyNumber = ++i;
                if (IsBouncyNumber(i))
                {
                    amountOfBouncyNumbers++;
                }
            } while ((double)amountOfBouncyNumbers / i != 0.99);

            Console.WriteLine("Bouncy Number-{0}", bouncyNumber);

            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);

            Console.Read();
        }

        private static bool IsBouncyNumber(int number)
        {
            var numberString = number.ToString();
            bool increasing = false, decreasing = false;
            for (int i = 0; i < numberString.Length - 1; i++)
            {
                if (int.Parse(numberString[i].ToString()) - int.Parse(numberString[i + 1].ToString()) < 0)
                {
                    increasing = true;
                }
                if (int.Parse(numberString[numberString.Length - i - 1].ToString()) - int.Parse(numberString[numberString.Length - i - 2].ToString()) < 0)
                {
                    decreasing = true;
                }
                if (increasing && decreasing)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
