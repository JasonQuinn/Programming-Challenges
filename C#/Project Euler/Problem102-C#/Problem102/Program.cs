using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Problem102
{
    //Three distinct points are plotted at random on a Cartesian plane, for which -1000  x, y  1000, such that a triangle is formed.
    //
    //Consider the following two triangles:/
    //A(-340,495), B(-153,-910), C(835,-947)
    //X(-175,41), Y(-421,-714), Z(574,-645)
    //
    //It can be verified that triangle ABC contains the origin, whereas triangle XYZ does not.
    //
    //Using triangles.txt (right click and 'Save Link/Target As...'), a 27K text file containing the co-ordinates of one thousand "random" triangles, find the number of triangles for which the interior contains the origin.
    //NOTE: The first two examples in the file represent the triangles in the example given above.
    internal class Program
    {
        private static void Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();

            var reader = new StreamReader("../../triangles.txt");
            string line;
            var triangles = new List<Triangle>();
            while ((line = reader.ReadLine()) != null)
            {
                var splitLine = line.Split(',').Select(int.Parse).ToArray();
                var pointA = new Vector2(splitLine[0], splitLine[1]);
                var pointB = new Vector2(splitLine[2], splitLine[3]);
                var pointC = new Vector2(splitLine[4], splitLine[5]);
                triangles.Add(new Triangle(pointA, pointB, pointC));
            }

            var countainsOriginCount = triangles.Count(u=>u.CointainsOrigin());
            Console.WriteLine("Count - " + countainsOriginCount);

            timer.Stop();
            Console.WriteLine("Time ellapsed - " + timer.Elapsed);
            Console.ReadLine();
        }
    }
}
