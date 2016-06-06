using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodingInterview.Hard
{
    public static class ShuffleClass
    {
        public static int[] Shuffle()
        {
            List<int> list = new List<int>();
            Random random = new Random();

            for(int i = 0; i < 52; i++)
                list.Insert(random.Next(0, list.Count + 1), i);

            return list.ToArray();
        }
    }

    [TestClass]
    public class ShuffleTestClass
    {
        [TestMethod]
        public void ShuffleTest()
        {
            ShuffleClass.Shuffle();
        }
    }
}
