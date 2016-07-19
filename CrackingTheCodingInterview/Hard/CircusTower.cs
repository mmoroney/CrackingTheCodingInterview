using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodingInterview.Hard
{
    public static class CircusTowerClass
    {
        public static int MaxPeople(int[] heights, int[] weights)
        {
            int n = heights.Length;

            int[] depths = new int[n];
            for (int i = 0; i < n; i++)
                CircusTowerClass.MaxDepth(heights, weights, n, i, depths);

            return depths.Max();
        }

        private static int MaxDepth(int[] heights, int[] weights, int n, int current, int[] depths)
        {
            if (depths[current] > 0)
                return depths[current];

            depths[current] = 1;

            for(int i = 0; i < n; i++)
            {
                if (heights[current] > heights[i] && weights[current] > weights[i])
                    depths[current] = Math.Max(depths[current], 1 + CircusTowerClass.MaxDepth(heights, weights, n, i, depths));
            }

            return depths[current];
        }
    }

    [TestClass]
    public class CircusTowerTestClass
    {
        [TestMethod]
        public void CircusTowerTest()
        {
            int[] heights = new int[] { 65, 70, 56, 75, 60, 68 };
            int[] weights = new int[] { 100, 150, 90, 190, 95, 110 };

            Assert.AreEqual(6, CircusTowerClass.MaxPeople(heights, weights));
        }
    }
}
