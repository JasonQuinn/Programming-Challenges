using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem24
{
    class Program
    {
        /// <summary>
        /// A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
        /// 
        /// 012   021   102   120   201   210
        /// 
        /// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("1000000 element-{0}", GetLexicographicPermutation().ElementAt(1000000 - 1));
            timer.Stop();
            Console.WriteLine("Time-{0}", timer.Elapsed);
            Console.Read();
        }

        private static IEnumerable<string> GetLexicographicPermutation()
        {
            List<int> number = new List<int>();
            for (int i0 = 0; i0 < 10; i0++)
            {
                number.Add(i0);
                for (int i1 = 0; i1 < 10; i1++)
                {
                    if (!number.Contains(i1))
                    {
                        number.Add(i1);
                        for (int i2 = 0; i2 < 10; i2++)
                        {
                            if (!number.Contains(i2))
                            {
                                number.Add(i2);
                                for (int i3 = 0; i3 < 10; i3++)
                                {
                                    if (!number.Contains(i3))
                                    {
                                        number.Add(i3);
                                        for (int i4 = 0; i4 < 10; i4++)
                                        {
                                            if (!number.Contains(i4))
                                            {
                                                number.Add(i4);
                                                for (int i5 = 0; i5 < 10; i5++)
                                                {
                                                    if (!number.Contains(i5))
                                                    {
                                                        number.Add(i5);
                                                        for (int i6 = 0; i6 < 10; i6++)
                                                        {
                                                            if (!number.Contains(i6))
                                                            {
                                                                number.Add(i6);
                                                                for (int i7 = 0; i7 < 10; i7++)
                                                                {
                                                                    if (!number.Contains(i7))
                                                                    {
                                                                        number.Add(i7);
                                                                        for (int i8 = 0; i8 < 10; i8++)
                                                                        {
                                                                            if (!number.Contains(i8))
                                                                            {
                                                                                number.Add(i8);
                                                                                for (int i9 = 0; i9 < 10; i9++)
                                                                                {
                                                                                    if (!number.Contains(i9))
                                                                                    {
                                                                                        number.Add(i9);
                                                                                        yield return i0.ToString() + i1.ToString() + i2.ToString() + i3.ToString() + i4.ToString() + i5.ToString() + i6.ToString() + i7.ToString() + i8.ToString() + i9.ToString();

                                                                                        number.Remove(number.Last());
                                                                                    }
                                                                                }
                                                                                number.Remove(number.Last());
                                                                            }
                                                                        }
                                                                        number.Remove(number.Last());
                                                                    }
                                                                }
                                                                number.Remove(number.Last());
                                                            }
                                                        }
                                                        number.Remove(number.Last());
                                                    }
                                                }
                                                number.Remove(number.Last());
                                            }
                                        }
                                        number.Remove(number.Last());
                                    }
                                }
                                number.Remove(number.Last());
                            }
                        }
                        number.Remove(number.Last());
                    }
                }
                number.Remove(number.Last());
            }
        }
    }
}
