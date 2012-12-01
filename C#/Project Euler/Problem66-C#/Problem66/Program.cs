using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

//Consider quadratic Diophantine equations of the form:
//
//x^2 – Dy^2 = 1
//
//For example, when D=13, the minimal solution in x is 649^2 – 13x180^2 = 1.
//
//It can be assumed that there are no solutions in positive integers when D is square.
//
//By finding minimal solutions in x for D = {2, 3, 5, 6, 7}, we obtain the following:
//
//3^2 – 2x2^2 = 1
//2^2 – 3x1^2 = 1
//9^2 – 5x4^2 = 1
//5^2 – 6x2^2 = 1
//8^2 – 7x3^2 = 1
//
//Hence, by considering minimal solutions in x for D <= 7, the largest x is obtained when D=5.
//
//Find the value of D <= 1000 in minimal solutions of x for which the largest value of x is obtained.
namespace Problem66
{
    class Program
    {
        static void Main()
        {
            var timer = new Stopwatch();
            timer.Start();
            var numberD = 0;
            long largetX = 0;
            for (var D = 2; D <= 1000; D++)
            {
                var bw = new BackgroundWorker();
                
                if (!IsSquare(D))
                {
                    numberD++;
                    bw.DoWork += bw_DoWork;
                    bw.RunWorkerCompleted +=
                        delegate(object sender, RunWorkerCompletedEventArgs e)
                            {
                                var minimalX = (long) e.Result;
                                numberD--;
                                if (minimalX > largetX)
                                {
                                    largetX = minimalX;
                                }
                                if (numberD == 0)
                                {
                                    Console.WriteLine(largetX);
                                }
                            };
                    bw.RunWorkerAsync(D);

                }
            }
            timer.Stop();
            while (numberD!=0)
            {
                Thread.Sleep(1000);
            }
            //Console.WriteLine(largetX);
            Console.WriteLine("Time " + timer.Elapsed);
            Console.ReadLine();
        }

        static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            var D = Convert.ToInt32(e.Argument);

            if ((worker.CancellationPending == true))
            {
                e.Cancel = true;
            }
            else
            {
                e.Result = GetMinimalX(D);
            }

        }

        private static long GetMinimalX (int D)
        {
            for (var x = 1;; x++)
            {
                for (var y = 1; y <= x; y++)
                {
                    if(MatchesEquation(x,y,D))
                    {
                        return x;
                    }
                }
            }
        }

        private static bool MatchesEquation(long x, long y, long D)
        {
            return checked(Math.Pow(x, 2) - (D*Math.Pow(y, 2)) == 1);
        }

        private static bool IsSquare(int number)
        {
            var result = Math.Sqrt(number);
            return result % 1 == 0;
        }
    }
}
