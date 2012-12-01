using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace Problem62
{
    //The cube, 41063625 (345^3), can be permuted to produce two other cubes: 56623104 (384^3) and 66430125 (405^3). 
    //In fact, 41063625 is the smallest cube which has exactly three permutations of its digits which are also cube.

    //Find the smallest cube for which exactly five permutations of its digits are cube.
    internal class Program
    {
        private static void Main()
        {
            var timer = new Stopwatch();
            timer.Start();

            var smallestPermitation = FindSmallestCubeWithPermitations(5);

            timer.Stop();
            Console.WriteLine("Smallest permitation - " + smallestPermitation);
            Console.WriteLine("Time - " + timer.ElapsedMilliseconds);
            Console.ReadLine();
        }

        private static BigInteger FindSmallestCubeWithPermitations(int numberOfPermitations)
        {
            var startNumber = 0;
            var cubes = new List<BigInteger>();
            BigInteger smallestPermitation;
            while (true)
            {
                var cubeNumber = Cube(++startNumber);
                if (cubes.Any())
                {
                    if (cubes.First().ToString(CultureInfo.InvariantCulture).Length ==
                        cubeNumber.ToString(CultureInfo.InvariantCulture).Length)
                    {
                        cubes.Add(cubeNumber);
                    }
                    else
                    {
                        if (HasRequiredPermitations(cubes, numberOfPermitations, out smallestPermitation))
                        {
                            break;
                        }
                        cubes.Clear();
                        startNumber--;
                    }
                }
                else
                {
                    cubes.Add(cubeNumber);
                }
            }

            return smallestPermitation;
        }

        private static bool HasRequiredPermitations(IEnumerable<BigInteger> listOfNumbers,
                                                    int numberOfPermitationsToFind,
                                                    out BigInteger smallestPermitation)
        {
            smallestPermitation = -1;
            listOfNumbers = listOfNumbers.ToArray();
            if (listOfNumbers.Count() < numberOfPermitationsToFind)
            {
                return false;
            }

            var minPermitation =
                //create a dictionary with the cube number and the sorted version
                listOfNumbers.ToDictionary(u => u,
                                           u =>
                                           string.Join("",
                                                       u.ToString(CultureInfo.InvariantCulture)
                                                        .ToArray()
                                                        .OrderBy(i => i)))
                    //Group into groups with the same sorted string where the group contains more values than the number of permitations
                             .GroupBy(u => u.Value)
                             .Where(g => g.Count() == numberOfPermitationsToFind).ToArray();

            if (minPermitation.Any())
            {
                //Find the smallest cube number accross the groups
                smallestPermitation = minPermitation.Min(u => u.Min(i => i.Key));
                return true;
            }
            return false;
        }

        private static BigInteger Cube(BigInteger number)
        {
            return BigInteger.Pow(number, 3);
        }
    }
}