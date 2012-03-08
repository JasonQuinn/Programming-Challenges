using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Problem81
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();

            var reader = new StreamReader("../../matrix.txt");
            string line;
            var intMatrix = new List<int[]>();
            while ((line = reader.ReadLine()) != null)
            {
                intMatrix.Add(line.Split(',').Select(int.Parse).ToArray());
            }

            var matrix = new Matrix(intMatrix.ToArray());
            var maxPath = matrix.FindMinPath();
            Console.WriteLine(maxPath);

            timer.Stop();
            Console.WriteLine("Time ellapsed - " + timer.Elapsed);
            Console.ReadLine();
        }
    }
}