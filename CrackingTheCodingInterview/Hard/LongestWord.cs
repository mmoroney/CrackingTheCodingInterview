using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodingInterview.Hard
{
    public static class LongestWordClass
    {
        public static string LongestWord(string[] words)
        {
            Dictionary<string, bool> results = new Dictionary<string, bool>();
            foreach (string word in words)
                results[word] = true;

            foreach (string word in words.OrderByDescending(s => s.Length))
                if (LongestWordClass.CanBuild(word, true, results))
                    return word;

            return string.Empty;
        }

        private static bool CanBuild(string s, bool isWord, Dictionary<string, bool> results)
        {
            bool result = false;
            if (!isWord && results.TryGetValue(s, out result))
                return result;

            result = false;

            for (int i = 1; i < s.Length - 1; i++)
            {
                if (LongestWordClass.CanBuild(s.Substring(0, i), false, results) && LongestWordClass.CanBuild(s.Substring(i), false, results))
                {
                    result = true;
                    break;
                }
            }

            results[s] = result;
            return result;
        }
    }

    [TestClass]
    public class LongestWordTestClass
    {
        [TestMethod]
        public void LongestWordTest()
        {
            LongestWordTestClass.LongestWordTest(
                new string[] { "cat", "banana", "dog", "nana", "walk", "walker", "dogwalker" },
                "dogwalker");

            LongestWordTestClass.LongestWordTest(
                new string[] { "a", "b", "c", "aaad", "bc", "werta", "abcdc", "aaaadbc" },
                "aaaadbc");

            LongestWordTestClass.LongestWordTest(
                new string[] { "abc", "def", "ghi", "jkl" },
                string.Empty);
        }

        private static void LongestWordTest(string[] words, string expected)
        {
            Assert.AreEqual(expected, LongestWordClass.LongestWord(words));
        }
    }
}
