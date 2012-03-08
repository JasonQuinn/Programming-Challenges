using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Problem42
{
    /// <summary>
    /// The nth term of the sequence of triangle numbers is given by, tn = ½n(n+1); so the first ten triangle numbers are:
    /// 
    /// 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
    /// 
    /// By converting each letter in a word to a number corresponding to its alphabetical position and adding these values we form a word value. For example, the word value for SKY is 19 + 11 + 25 = 55 = t10. If the word value is a triangle number then we shall call the word a triangle word.
    /// 
    /// Using words.txt (right click and 'Save Link/Target As...'), a 16K text file containing nearly two-thousand common English words, how many are triangle words?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Count-{0}", AmountOfTriangleNumbers(GetScore()));
            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.Read();
        }

        private static IEnumerable<int> GetTrangleNumbers()
        {
            Func<int, int> TriangleNumber = n => (int)((.5 * n) * (n + 1));
            int i = 1;
            while (true)
            {
                yield return TriangleNumber(i);
                i++;
            }
        }

        private static int AmountOfTriangleNumbers(List<int> wordsDictionary)
        {
            int count = 0;
            IEnumerable<int> triangleNumbers = GetTrangleNumbers().TakeWhile(u => u <= wordsDictionary.Max());
            foreach (var item in wordsDictionary)
            {
                if (triangleNumbers.TakeWhile(u => u <= item).Contains(item))
                {
                    count++;
                }
            }
            return count;
        }

        private static IEnumerable<string> GetWords()
        {
            StreamReader reader = new StreamReader(@"..\..\..\words.txt");
            IEnumerable<string> names = Regex.Split(reader.ReadLine().Replace("\"", ""), ",");
            return names;
        }

        private static List<int> GetScore()
        {
            List<int> scores = new List<int>();
            foreach (string word in GetWords())
            {
                scores.Add(word.Select(u => u - 64).Sum());
            }
            return scores;
        }
    }
}
