using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

// Comparing two numbers written in index form like 2^11 and 3^7 is not difficult, as any calculator would confirm that 2^11 = 2048 < 3^7 = 2187.
// 
// However, confirming that 632382^518061  519432^525806 would be much more difficult, as both numbers contain over three million digits.
// 
// Using base_exp.txt (right click and 'Save Link/Target As...'), a 22K text file containing one thousand lines with a base/exponent pair on each line, determine which line number has the greatest numerical value.
// 
// NOTE: The first two lines in the file represent the numbers in the example given above.
namespace Problem99
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Line-{0}", GetMaxLine());
            Console.ReadLine();
        }

        private static int GetMaxLine()
        {
            var text = Regex.Split(File.ReadAllText(@"..\..\base_exp.txt"), "\r\n");

            int maxLine = -1;
            var max = -1d;
            for (int i = 0; i < text.Count(); i++)
            {
                var line = text[i].Split(',');
                var number = SizeOfNumber(int.Parse(line[0]), int.Parse(line[1]));
                if (number > max)
                {
                    maxLine = i + 1;
                    max = number;
                }
            }
            return maxLine;
        }

        private static double SizeOfNumber(int a, int x)
        {
            return x * Math.Log(a);
        }
    }
}
