using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;

//Very slow
namespace Problem79
{
    class Program
    {
        static void Main()
        {
            var timer = new Stopwatch();
            timer.Start();

            var keyLog = new StreamReader("../../keylog.txt");
            var lines = new List<string>();
            string line;
            while ((line = keyLog.ReadLine()) != null)
            {
                lines.Add(line);
            }
            var passcode = new Passcode(lines);

            var number = GetNumber(passcode);
            Console.WriteLine(number);
            timer.Stop();
            Console.WriteLine("Time ellapsed - " + timer.Elapsed);
            Console.ReadLine();
        }

        private static BigInteger GetNumber(Passcode passcode)
        {
            for (BigInteger i = passcode.LowestPossibleNum; ; i++)
            {
                if (passcode.CheckIfNumberWorks(i))
                {
                    return i;
                }
            }
        }
    }
}
