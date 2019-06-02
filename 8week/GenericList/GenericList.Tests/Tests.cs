using NUnit.Framework;
using System;

namespace GenericList
{
    /// <summary>
    /// Class that tests Generic List
    /// </summary>
    public class GenericListTests
    {
        private readonly List<int> list1 = new List<int>() { 4, 8, 34, -7, 14, -23, 87, 2345, -143, -364, 78 };
        private readonly List<int> emptyList = new List<int>();
        private readonly int[] keys = new int[] { 4, 8, 34, -7, 14, -23, 87, 2345, -143, -364, 78 };

        private static void AreEqual<T>(List<T> list, T[] array) where T : IComparable<T>
        {
            if (list.Count != array.Length)
            {
                Assert.Fail();
            }
            int i = 0;
            foreach (var key in list)
            {
                Assert.IsTrue(array[i].CompareTo(key) == 0);
                ++i;
            }
        }

        private static void AreEqual<T>(T[] array1, T[] array2) where T : IComparable<T>
        {
            if (array1.Length != array2.Length)
            {
                Assert.Fail();
            }
            for (int i = 0; i < array1.Length; ++i)
            {
                Assert.IsTrue(array1[i].CompareTo(array2[i]) == 0);
            }
        }

        [Test]
        public void OneAddTest()
        {
            list1.Add(10000);
            Assert.IsTrue(list1.Contains(10000));
        }

        [Test]
        public void ManyAddTest()
        {
            var toAdd = new int[] { 53, 589, 93, 234, 456, 4562, 98, -88, -49, -8839 };
            for (int j = 0; j < toAdd.Length; ++j)
            {
                list1.Add(toAdd[j]);
            }
            var expected = new int[] { 4, 8, 34, -7, 14, -23, 87, 2345, -143,
                -364, 78, 53, 589, 93, 234, 456, 4562, 98, -88, -49, -8839 };

            AreEqual(list1, expected);
        }

        [Test]
        public void DeleteFromEmptySet()
        {
            Assert.IsFalse(list1.Remove(2));
        }

        [Test]
        [TestCase(12)]
        [TestCase(11)]
        [TestCase(-1)]
        public void DeleteFromIncorrectPositionTest(int position)
        {
            Assert.Throws<IncorrectPositionException>(() => list1.RemoveAt(position));
        }

        [Test]
        [TestCase(10, 78)]
        [TestCase(0, 4)]
        [TestCase(1, 8)]
        [TestCase(9, -364)]
        [TestCase(2, 34)]
        [TestCase(5, -23)]
        //  4, 8, 34, -7, 14, -23, 87, 2345, -143, -364, 78
        public void RemoveOneElementFromCorrectPositionTest(int position, int deletedValue)
        {
            list1.RemoveAt(position);
            Assert.IsFalse(list1.Contains(deletedValue));
        }

        [Test]
        public void RemoveManyElementsFromBeginTest()
        {
            for (int i = 0; i < 5; ++i)
            {
                list1.RemoveAt(0);
            }
            var expected = new int[] { -23, 87, 2345, -143, -364, 78 };
            AreEqual(list1, expected);
        }

        [Test]
        public void RemoveManyElementsFromEndTest()
        {
            for (int i = 0; i < 5; ++i)
            {
                list1.RemoveAt(list1.Count - 1);
            }
            var expected = new int[] { 4, 8, 34, -7, 14, -23 };
            AreEqual(list1, expected);
        }

        [Test] 
        public void RemoveManyElementsByValuesTest()
        {
            var toDelete = new int[] { 4, -7, 8, 78, -143, -364, 87 };
            foreach (var key in toDelete)
            {
                list1.Remove(key);
            }
            var result = new int[] { 34, 14, -23, 2345 };
            AreEqual(list1, result);
        }

        [Test]
        public void ContainsTest()
        {
            for (int i = 0; i < keys.Length; ++i)
            {
                Assert.IsTrue(list1.Contains(keys[i]));
            }
        }

        [Test]
        public void IndexOfTest()
        {
            for (int i = 0; i < keys.Length; ++i)
            {
                Assert.AreEqual(list1.IndexOf(keys[i]), i);
            }
        }

        [Test]
        [TestCase(-1)]
        [TestCase(11)]
        [TestCase(-2)]
        [TestCase(12)]
        public void InsertToIncorrectPositionTest(int position)
        {
            Assert.Throws<IncorrectPositionException>(() => list1.Insert(position, 1));
        }

        [Test]
        public void ManyInsertToBeginTest()
        {
            for (int i = 4; i > -1; --i)
            {
                list1.Insert(0, i + 10);
            }
            var expected = new int[] {10, 11, 12, 13, 14, 4, 8, 34, -7, 14, -23, 87, 2345, -143, -364, 78 };
            AreEqual(list1, expected);
        }

        [Test]
        public void ManyInsertToEndTest()
        {
            for (int i = 0; i < 5; ++i)
            {
                list1.Insert(list1.Count, i);
            }
            var expected = new int[] { 4, 8, 34, -7, 14, -23, 87, 2345, -143, -364, 78, 0, 1, 2, 3, 4 };
            AreEqual(list1, expected);
        }

        [Test]
        public void InsertAfterHeadTest()
        {
            list1.Insert(1, 76599);
            var expected = new int[] { 4, 76599, 8, 34, -7, 14, -23, 87, 2345, -143, -364, 78 };
            AreEqual(list1, expected);
        }

        [Test]
        public void InsertBeforeTailTest()
        {
            list1.Insert(list1.Count - 1, 76599);
            var expected = new int[] { 4, 8, 34, -7, 14, -23, 87, 2345, -143, -364, 76599, 78 };
            AreEqual(list1, expected);
        }

        [Test]
        public void InsertToTheMiddleTest()
        {
            list1.Insert(5, 76599);
            var expected = new int[] { 4, 8, 34, -7, 14, 76599, -23, 87, 2345, -143, -364, 78 };
            AreEqual(list1, expected);
        }


        [Test]
        public void InsertToEmptyListTest()
        {
            for (int i = 4; i >= 0; --i)
            {
                emptyList.Insert(0, i);
            }
            var expected = new int[] { 0, 1, 2, 3, 4 };
            AreEqual(emptyList, expected);
        }

        [Test]
        public void ClearTest()
        {
            list1.Clear();
            Assert.AreEqual(list1.Count, 0);
            for (int i = 0; i < keys.Length; ++i)
            {
                Assert.IsFalse(list1.Contains(keys[i]));
            }
        }

        [Test]
        public void CorrectCopyToNonZeroArrayIndexTest()
        {
            var arrayToCopyTo = new int[3] { 6, 7, 778 };
            var expected = new int[] { 6, 7, 778, 4, 8, 34, -7, 14, -23, 87, 2345, -143, -364, 78 };
            Array.Resize(ref arrayToCopyTo, 14);
            list1.CopyTo(arrayToCopyTo, 3);
            AreEqual(expected, arrayToCopyTo);            
        }

        [Test]
        public void InorrectCopyToTestTooShortArray()
        {
            var arrayToCopyTo = new int[5];
            Assert.Throws<ArgumentException>(() => list1.CopyTo(arrayToCopyTo, 0));
        }

        [Test]
        public void IncorrectCopyToTestNegativeArrayIndex()
        {
            var arrayToCopyTo = new int[5];
            Assert.Throws<IndexOutOfRangeException>(() => list1.CopyTo(arrayToCopyTo, -1));
        }

        [Test]
        public void CorrectCopyToZeroArrayIndexTest()
        {
            var arrayToCopyTo = new int[11];
            list1.CopyTo(arrayToCopyTo, 0);
            AreEqual(keys, arrayToCopyTo);
        }
    }
}
