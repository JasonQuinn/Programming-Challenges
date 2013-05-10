using System;
using System.Diagnostics;

namespace Problem85
{
    //By counting carefully it can be seen that a rectangular grid measuring 3 by 2 contains eighteen rectangles:
    //Although there exists no rectangular grid that contains exactly two million rectangles, find the area of the grid with the nearest solution.
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();

            var smallestDifference = int.MaxValue;
            var closestX = -1;
            var closestY = -1;

            for (var x = 1; x <= 2000; x++)
            {
                var contunue = true;
                for (var y = 1; y <= 2000; y++)
                {
                    var currentNumber = GetNumberOfRectanges(x, y);
                    var currentDifference = FindDifference(2000000, currentNumber);
                    if (currentDifference < smallestDifference)
                    {
                        smallestDifference = currentDifference;
                            closestX = x;
                            closestY = y;
                    }
                    if (currentNumber > 2000000)
                    {
                        contunue = false;
                        break;
                    }
                }
                if (!contunue)
                {
                    break;
                }
            }

            timer.Stop();

            Console.WriteLine("Area = " + (closestX*closestY));
            Console.WriteLine("Time taken-" + timer.Elapsed);
            Console.ReadLine();
        }

        /// <summary>
        /// Find the difference between two numbers
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        static int FindDifference(int n1, int n2)
        {
            return Math.Abs(n1 - n2);
        }

        /// <summary>
        /// Get the number of rectanges in a grid
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static int GetNumberOfRectanges(int x, int y)
        {
            return (x*(x + 1)*y*(y + 1))/4;
        }
    }
}
