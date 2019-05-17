using NUnit.Framework;
using System.Collections.Generic;

namespace Test2
{

    /// <summary>
    /// Class that checks the correct operation of the BubbleSort on different types
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// Method which compares two lists
        /// </summary>
        /// <typeparam name="T">Type of list elements</typeparam>
        /// <param name="list1">First list to sort</param>
        /// <param name="list2">Second list to sort</param>
        private void Compare<T>(List<T> list1, List<T> list2)
        {
            for (int i = 0; i < list1.Count; ++i)
            {
                Assert.AreEqual(list1[i], list2[i]);
            }
        }

        [Test]
        public void IntTest()
        {
            var list = new List<int>() { 0, 765, 8, 527, -653, -325 };
            var sortedList = new List<int>() { -653, -325, 0, 8, 527, 765 };
            BubbleSort.Sort(list, Comparer<int>.Default);
            Compare(list, sortedList);
        }

        [Test]
        public void StringTest()
        {
            var list = new List<string>() { "alcv", "ab", "abcdz", "abcdzx", "a", "abcdf" };
            var sortedList = new List<string>() { "a", "ab", "abcdf", "abcdz", "abcdzx", "alcv" };
            BubbleSort.Sort(list, Comparer<string>.Default);
            Compare(list, sortedList);
        }

        [Test]
        public void CharTest()
        {
            var list = new List<char>() { 'b', 'd', 'a', 'f', 'a' };
            var sortedList = new List<char>() { 'a', 'a', 'b', 'd', 'f' };
            BubbleSort.Sort(list, Comparer<char>.Default);
            Compare(list, sortedList);
        }
    }
}
