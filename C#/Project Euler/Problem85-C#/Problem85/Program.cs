using System;
using System.Diagnostics;

namespace Problem85
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();

            //var closestNumber = int.MaxValue;
            //var closestX = -1;
            //var closestY = -1;

            //for (var x = 1; x <= 2000; x++)
            //{
            //    for (var y = 1; y <= 2000; y++)
            //    {
            //        var currentNumber = GetNumberOfRectanges(x, y);
            //        if (currentNumber > 2000000)
            //        {
            //            if (currentNumber < closestNumber)
            //            {
            //                closestNumber = currentNumber;
            //                closestX = x;
            //                closestY = y;
            //            }
            //            break;
            //        }
            //    }
            //}


            var smallestDifference = int.MaxValue;
            var closestX = -1;
            var closestY = -1;

            for (var x = 1; x <= 2000; x++)
            {
                for (var y = 1; y <= 2000; y++)
                {
                    var currentNumber = GetNumberOfRectanges(x, y);
                    var currentDifference = Math.Abs(2000000 - currentNumber);
                    if (currentDifference < smallestDifference)
                    {
                        smallestDifference = currentDifference;
                            closestX = x;
                            closestY = y;
                    }
                    if (currentNumber > 2000000)
                    {
                        break;
                    }
                }
            }



            timer.Stop();

            Console.WriteLine("Area = " + (closestX*closestY));
            Console.WriteLine("Time taken-" + timer.Elapsed);
            Console.ReadLine();
        }

        static int GetNumberOfRectanges(int x, int y)
        {
            return (x*(x + 1)*y*(y + 1))/4;
        }
    }
}
