using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Tests for Map, Fold, Filter functions
    /// </summary>
    public class Tests
    {
        private List<char> listOfChars;
        private List<int> listOfNumbers;
        private List<string> slogans;

        [SetUp]
        public void SetUp()
        {
            listOfNumbers = new List<int> { 1, 3, 7, -2, 0, 15, 1000000, -43000000 };

            listOfChars = new List<char>() { 'a', 'b', 'c', 'f', 'm', 'k', 'n', 'o', 'y', 'z' };

            slogans = new List<string>() { "Freedom", "Equality", "Brotherhood",
              "Cuba - yes", "Yankee - no", "Proletarians of all countries", "Unite",
              "Wir", "Sind", "Das", "Volk" };

        }

        private static bool CheckEquality<T>(List<T> initialList, List<T> resultList)
        {
            for (int i = 0; i < initialList.Count; ++i)
            {
                if (!initialList[i].Equals(resultList[i]))
                {
                    return false;
                }
            }
            return true;
        }

        [Test]
        public void MapForIntType()
        {
            var result = new List<int> { 2, 6, 14, -4, 0, 30, 2000000, -86000000 };
            listOfNumbers = Functions.Functions.Map(listOfNumbers, x => x * 2);
            Assert.IsTrue(CheckEquality(listOfNumbers, result));
        }

        [Test]
        public void MapForStringType()
        {
            var result = new List<string> { "Freedom!", "Equality!", "Brotherhood!",
              "Cuba - yes!", "Yankee - no!", "Proletarians of all countries!", "Unite!",
              "Wir!", "Sind!", "Das!", "Volk!" };
            slogans = Functions.Functions.Map(slogans, word => word + "!");
            Assert.IsTrue(CheckEquality(slogans, result));
        }

        [Test]
        public void FilterForIntType()
        {
            var result = new List<int> { -2, 0, -43000000 };
            listOfNumbers = Functions.Functions.Filter(listOfNumbers, x => x <= 0);
            Assert.IsTrue(CheckEquality(listOfNumbers, result));
        }

        [Test]
        public void FilterForCharType()
        {
            var result = new List<char> { 'a', 'b', 'c', 'f', 'm', 'k', 'n' };
            listOfChars = Functions.Functions.Filter(listOfChars, x => x <= 'n');
            Assert.IsTrue(CheckEquality(listOfChars, result));
        }

        [Test]
        public void FilterForStringType()
        {
            var result = new List<string> { "Brotherhood", "Yankee - no", "Proletarians of all countries" };
            slogans = Functions.Functions.Filter(slogans, x => x.Length > 10);
            Assert.IsTrue(CheckEquality(slogans, result));
        }

        [Test]
        public static void FoldForInt()
        {
            var list = new List<int> { 2, 6, 8, 10 };
            Assert.AreEqual(6720, Functions.Functions.Fold(list, 7, ((x, val) => x * val)));
        }

        [Test]
        public static void FoldForString()
        {
            var list = new List<string> { "a", "b", "c", "l", "q", "z" };
            Assert.AreEqual("zqlcbap", Functions.Functions.Fold(list, "p", ((x, val) => x + val)));
        }
    }
}