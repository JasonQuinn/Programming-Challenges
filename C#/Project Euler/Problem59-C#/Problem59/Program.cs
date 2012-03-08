using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Problem59
{
    class Program
    {

        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();

            var reader = new StreamReader("../../cipher1.txt");
            var text = reader.ReadToEnd();

            var fileChars = text.Split(',').Select(u => Convert.ToChar(int.Parse(u)));

            var encryption = new Encryption(fileChars);
            var value = encryption.TryToUnencrypt();
            if (value != -1)
            {
                Console.WriteLine(value);
            }

            timer.Stop();
            Console.WriteLine("Time ellapsed - " + timer.Elapsed);
            Console.ReadLine();
        }
    }
}
