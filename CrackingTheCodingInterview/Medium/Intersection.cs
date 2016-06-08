using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodingInterview.Medium
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }
    }

    public static class IntersectionClass
    {
        public static Point Intersection(Line a, Line b)
        {
            double[,] matrix = new double[2, 2];

            matrix[0, 0] = b.Start.Y - b.End.Y;
            matrix[0, 1] = b.End.X - b.Start.X;
            matrix[1, 0] = a.Start.Y - a.End.Y;
            matrix[1, 1] = a.End.X - a.Start.X;

            double[] vector = new double[2];
            vector[0] = b.Start.X - a.Start.X;
            vector[1] = b.Start.Y - a.Start.Y;

            double determinant = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

            if (determinant == 0)
                return null;

            double[] results = new double[2];

            for(int i = 0; i < 2; i++)
            {
                double sum = 0;
                for(int j = 0; j < 2; j++)
                    sum += matrix[i, j] * vector[j];

                results[i] = sum / determinant;
                if (results[i] < 0 || results[i] > 1)
                    return null;
            }

            return new Point { X = a.Start.X + results[0] * (a.End.X - a.Start.X), Y = a.Start.Y + results[1] * (a.End.Y - a.Start.Y) };
        }
    }

    [TestClass]
    public class IntersectionTestClass
    {
        [TestMethod]
        public void IntersectionTest()
        {
            IntersectionTestClass.IntersectionTest(0, 1, 0, -1, -1, 0, 1, 0, new Point { X = 0, Y = 0 });
            IntersectionTestClass.IntersectionTest(0, 0, 10, 0, 0, -10, 10, 10, new Point { X = 5, Y = 0 });
            IntersectionTestClass.IntersectionTest(0, 0, 1, 1, 2, 2, 3, 3, null);
        }

        private static void IntersectionTest(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4, Point expected)
        {
            Line a = new Line
            {
                Start = new Point { X = x1, Y = y1 },
                End = new Point { X = x2, Y = y2 }
            };

            Line b = new Line
            {
                Start = new Point { X = x3, Y = y3 },
                End = new Point { X = x4, Y = y4 }
            };

            Point actual = IntersectionClass.Intersection(a, b);

            if (expected == null)
                Assert.IsNull(actual);
            else
            {
                Assert.AreEqual(expected.X, actual.X);
                Assert.AreEqual(expected.Y, actual.Y);
            }
        }
    }
}
