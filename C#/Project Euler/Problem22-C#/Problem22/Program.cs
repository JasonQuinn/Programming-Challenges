using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Problem22
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalScore = 0;
            IEnumerable<string> names = GetNames();
            for (int i = 0; i < names.Count(); i++)
            {
                totalScore += GetScore(names.ElementAt(i), i + 1);
                Debug.Assert(totalScore >= 0, "int overflow-totalScore");
            }
            Console.WriteLine(totalScore);
            Console.Read();
        }

        private static int GetScore(string name, int position)
        {
            int score = 0;
            foreach (char item in name)
            {
                int charValue=item - 64;
                score += charValue;
                Debug.Assert(charValue >= 1 && charValue <= 26,"Not In Alphabet");
                Debug.Assert(score > 0, "int overflow-score");
            }
            score = score * position;
            Debug.Assert(score > 0, "int overflow-return score");
            return score;
        }

        private static IEnumerable<string> GetNames()
        {
            StreamReader reader = new StreamReader(@"..\..\..\..\Problem22\names.txt");
            IEnumerable<string> names = Regex.Split(reader.ReadLine().Replace("\"", ""), ",").OrderBy(u => u);
            return names;
        }
    }
}
