using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodingInterview.Moderate
{
    public static class FactorialZerosClass
    {
        public static int FactorialZeros(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException(nameof(n));

            int result = 0;
            while (n >= 5)
            {
                result += n / 5;
                n /= 5;
            }

            return result;
        }
    }

    [TestClass]
    public class FactorialZerosTestClass
    {
        [TestMethod]
        public void FactorialZerosTest()
        {
            for(int i = 0; i <= 15; i++)
            {
                long factorial = FactorialZerosTestClass.Factorial(i);
                int expected = 0;
                while (factorial % 10 == 0)
                {
                    expected++;
                    factorial /= 10;
                }

                int actual = FactorialZerosClass.FactorialZeros(i);
                Assert.AreEqual(expected, actual);
            }
        }

        private static long Factorial(int n)
        {
            long result = 1;
            while(n > 1)
            {
                result *= n;
                n--;
            }

            return result;
        }
    }
}
