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
        private List<string> Slogans;

        [SetUp]
        public void SetUp()
        {
            listOfNumbers = new List<int> { 1, 3, 7, -2, 0, 15, 1000000, -43000000 };

            listOfChars = new List<char>() { 'a', 'b', 'c', 'f', 'm', 'k', 'n', 'o', 'y', 'z' };

            Slogans = new List<string>() { "Freedom", "Equality", "Brotherhood",
            "Cuba - yes", "Yankee - no", "Proletarians of all countries", "Unite",
            "Wir", "Sind", "Das", "Volk" };

        }

        private bool CheckEquality<T>(List<T> initialList, List<T> resultList)
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
            Slogans = Functions.Functions.Map(Slogans, word => word + "!");
            Assert.IsTrue(CheckEquality(Slogans, result));
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
            Slogans = Functions.Functions.Filter(Slogans, x => x.Length > 10);
            Assert.IsTrue(CheckEquality(Slogans, result));
        }

        [Test]
        public void FoldForInt()
        {
            var list = new List<int> { 2, 6, 8, 10 };
            Assert.AreEqual(6720, Functions.Functions.Fold(list, 7, ((x, val) => x * val)));
        }

        [Test]
        public void FoldForString()
        {
            var list = new List<string> { "a", "b", "c", "l", "q", "z" };
            Assert.AreEqual("zqlcbap", Functions.Functions.Fold(list, "p", ((x, val) => x + val)));
        }
    }
}