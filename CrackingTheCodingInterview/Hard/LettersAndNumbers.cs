using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodingInterview.Hard
{
    public static class LettersAndNumbersClass
    {
        public static int LettersAndNumbers(char[] data)
        {
            int[] diffs = new int[data.Length];
            int diff = 0;

            for(int i = 0; i < data.Length; i++)
            {
                if (char.IsLetter(data[i]))
                    diff++;
                else
                    diff--;

                diffs[i] = diff;
            }

            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            dictionary[0] = -1;
            int max = 0;

            for (int i = 0; i < diffs.Length; i++)
            {
                int first;
                if (dictionary.TryGetValue(diffs[i], out first))
                    max = Math.Max(max, i - first);
                else
                    dictionary[diffs[i]] = i;
            }

            return max;
        }
    }

    [TestClass]
    public class LettersAndNumbersTestClass
    {
        [TestMethod]
        public void LettersAndNumbersTest()
        {
            char[] test = "kl2jy5f".ToCharArray();
            int foo = LettersAndNumbersTest(test);

            Random random = new Random();
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    char[] data = new char[j];
                    for(int k = 0; k < data.Length; k++)
                    {
                        int next = random.Next(0, 37);
                        data[k] = (char)((next < 10) ? next + '0': 'a' + next - 10);
                    }

                    int expected = LettersAndNumbersTestClass.LettersAndNumbersTest(data);
                    int actual = LettersAndNumbersClass.LettersAndNumbers(data);

                    Assert.AreEqual(expected, actual);
                }
            }
        }

        private static int LettersAndNumbersTest(char[] data)
        {
            for (int i = data.Length; i > 0; i--)
            {
                for (int j = 0; j <= data.Length - i; j++)
                {
                    int diff = 0;
                    for (int k = j; k <= j + i - 1; k++)
                    {
                        if (char.IsLetter(data[k]))
                            diff++;
                        else
                            diff--;
                    }

                    if (diff == 0)
                        return i;
                }
            }

            return 0;
        }
    }
}
