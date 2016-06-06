using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodingInterview.Hard
{
    public static class AddWithoutPlusClass
    {
        public static int AddWithoutPlus(int a, int b)
        {
            if (b == 0)
                return a;

            int add = a ^ b;
            int carry = (a & b) << 1;

            return AddWithoutPlusClass.AddWithoutPlus(add, carry);
        }
    }

    [TestClass]
    public class AddWithoutPlusTestClass
    {
        [TestMethod]
        public void AddWithoutPlusTest()
        {
            Random random = new Random();
            for(int i = 0; i < 100; i++)
            {
                int a = random.Next(int.MinValue, int.MaxValue);
                int b = random.Next(int.MinValue, int.MaxValue);

                int expected = a + b;
                int actual = AddWithoutPlusClass.AddWithoutPlus(a, b);

                Assert.AreEqual(expected, actual);
            }
        }
    }
}
