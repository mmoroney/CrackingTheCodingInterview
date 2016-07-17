using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodingInterview.Hard
{
    public static class MaxSubmatrixClass
    {
        public static int MaxSubmatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (matrix.GetLength(1) != n)
                throw new ArgumentException(nameof(matrix));

            int maxSum = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int[] sums = new int[n];

                for (int j = i; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                        sums[k] += matrix[j, k];

                    maxSum = Math.Max(maxSum, MaxSubmatrixClass.MaxSubArray(sums));
                }
            }

            return maxSum;
        }

        private static int MaxSubArray(int[] data)
        {
            int currentSum = 0;
            int maxSum = 0;
            foreach(int i in data)
            {
                currentSum += i;
                currentSum = Math.Max(currentSum, 0);
                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum;
        }
    }

    [TestClass]
    public class MaxSubmatrixTestClass
    {
        [TestMethod]
        public void MaxSubmatrixTest()
        {
            for(int i = 0; i < 10; i++)
            {
                int n = 5;
                int[,] matrix = new int[n, n];
                Random random = new Random();

                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        matrix[j, k] = random.Next(-20, 21);
                    }
                }

                MaxSubmatrixTestClass.MaxSubmatrixTest(matrix, n);
            }
        }

        private static void MaxSubmatrixTest(int[,] matrix, int n)
        {
            int expected = MaxSubmatrixTestClass.GetMaxSubmatrixSum(matrix, n);
            int actual = MaxSubmatrixClass.MaxSubmatrix(matrix);
            Assert.AreEqual(expected, actual);
        }

        private static int GetMaxSubmatrixSum(int[,] matrix, int n)
        {
            int maxSum = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    for(int k = i; k < n; k++)
                    {
                        for (int l = j; l < n; l++)
                        {
                            int sum = 0;
                            for (int m = i; m <= k; m++)
                            {
                                for(int o = j; o <= l; o++)
                                {
                                    sum += matrix[m, o];
                                }
                            }

                            maxSum = Math.Max(sum, maxSum);
                        }
                    }
                }
            }

            return maxSum;
        }
    }
}
