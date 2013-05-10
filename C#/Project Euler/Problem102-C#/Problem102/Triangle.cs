using System;

namespace Problem102
{
    public class Triangle
    {
        public Vector2 PointA { get; private set; }
        public Vector2 PointB { get; private set; }
        public Vector2 PointC { get; private set; }

        public Triangle(Vector2 pointA, Vector2 pointB, Vector2 pointC)
        {
            PointA = pointA;
            PointB = pointB;
            PointC = pointC;
        }

        public bool CointainsOrigin()
        {
            return ContainsOrigin(this);
        }

        private static bool ContainsOrigin(Triangle triangle)
        {
            return ContainsOrigin(triangle.PointA, triangle.PointB, triangle.PointC);
        }

        private static bool ContainsOrigin(Vector2 pointA, Vector2 pointB, Vector2 pointC)
        {
            var area = TriangleArea(pointA, pointB, pointC);

            var origin = new Vector2(0, 0);
            var areaA = TriangleArea(origin, pointB, pointC);
            var areaB = TriangleArea(pointA, origin, pointC);
            var areaC = TriangleArea(pointA, pointB, origin);

            var totalAreaFromOrigin = areaA + areaB + areaC;

            return area.Equals(totalAreaFromOrigin);
        }

        private static double TriangleArea(Vector2 pointA, Vector2 pointB, Vector2 pointC)
        {
            var area =
                Math.Abs(((double) pointA.X*(pointB.Y - pointC.Y) + pointB.X*(pointC.Y - pointA.Y) +
                          pointC.X*(pointA.Y - pointB.Y))/2);
            return area;
        }
    }
}