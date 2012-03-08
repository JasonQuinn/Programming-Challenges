using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Problem71
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();

            //todo everything

            timer.Stop();
            Console.WriteLine("Time ellapsed - {0}", timer.Elapsed);
            Console.ReadLine();
        }
    }
}
