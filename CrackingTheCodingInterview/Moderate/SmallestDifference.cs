using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodingInterview.Moderate
{
    public static class SmallestDifferenceClass
    {
        public static int SmallestDifference(int[] a, int[] b)
        {
            Array.Sort(a);
            Array.Sort(b);

            int i = 0;
            int j = 0;
            int difference = int.MaxValue;

            while(i < a.Length && j < b.Length)
            {
                difference = Math.Min(difference, Math.Abs(a[i] - b[j]));
                if (a[i] < b[j])
                    i++;
                else
                    j++;
            }

            return difference;
        }
    }

    [TestClass]
    public class SmallestDifferenceTestClass
    {
        [TestMethod]
        public void SmallestDifferenceTest()
        {
            SmallestDifferenceTestClass.SmallestDifferenceTest(new int[] { 1, 3, 15, 11, 2 }, new int[] { 23, 127, 235, 19, 8 });
            Random random = new Random();

            for(int i = 1; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    int[] a = new int[i];
                    int[] b = new int[j];

                    for(int k = 0; k < a.Length; k++)
                        a[k] = random.Next(0, 100);

                    for (int k = 0; k < b.Length; k++)
                        b[k] = random.Next(0, 100);

                    SmallestDifferenceTestClass.SmallestDifferenceTest(a, b);
                }
            }
        }

        private static void SmallestDifferenceTest(int[] a, int[] b)
        {
            int expected = int.MaxValue;

            for (int i = 0; i < a.Length; i++)
            {
                for(int j = 0; j < b.Length; j++)
                {
                    expected = Math.Min(expected, Math.Abs(a[i] -  b[j]));
                }
            }

            int actual = SmallestDifferenceClass.SmallestDifference(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}
