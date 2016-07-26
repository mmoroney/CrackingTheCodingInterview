using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodingInterview.Hard
{
    public static class MagicIndexClass
    {
        public static int MagicIndex(int[] data)
        {
            return MagicIndexClass.MagicIndex(data, 0, data.Length - 1);
        }

        private static int MagicIndex(int[] data, int start, int end)
        {
            if (start > end)
                return -1;

            int mid = start + (end - start) / 2;

            if (data[mid] == mid)
                return mid;

            int left = MagicIndexClass.MagicIndex(data, start, Math.Min(mid - 1, data[mid]));

            if (left != -1)
                return left;

            return MagicIndexClass.MagicIndex(data, Math.Max(mid + 1, data[mid]), end);
        }
    }

    [TestClass]
    public class MagicIndexTestClass
    {
        [TestMethod]
        public void MagicIndexTest()
        {
            int n = 20;

            for (int i = 0; i < 10; i++)
            {
                int[] data = new int[n];
                Random random = new Random();

                for (int j = 0; j < data.Length; j++)
                    data[j] = random.Next(-n, n);

                Array.Sort(data);

                int actual = MagicIndexClass.MagicIndex(data);

                if (actual == -1)
                    Assert.IsFalse(MagicIndexTestClass.HasMagicIndex(data, n));
                else
                    Assert.AreEqual(data[actual], actual);
            }
        }

        private static bool HasMagicIndex(int[] data, int n)
        {
            for(int i = 0; i < n; i++)
            {
                if (data[i] == i)
                    return true;
            }

            return false;
        }
    }
}
