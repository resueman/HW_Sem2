using NUnit.Framework;
using System;

namespace Set
{
    public class Tests
    {
        private  Set<int> set0;
        private  Set<int> set1;
        private  Set<int> set3;
        private  Set<int> set4;
        private  Set<int> set5;
        private  Set<int> set8; 
        private Set<int> set11;
        private  Set<int> otherSet1;
        private  Set<int> otherSet2;
        private  int[] array11;
        private  int[] array8;

        [SetUp]
        public void Init()
        {
            set0 = new Set<int>();
            set1 = new Set<int> { 9 };
            set3 = new Set<int> { 28, 37, 19 };
            set4 = new Set<int> { 19, 57, 8, 58 };
            set5 = new Set<int> { 48, 90, 120, 28, 10 };
            set8 = new Set<int> { 150, 98, 90, 95, 18, 180, 170, 160 };
            set11 = new Set<int> { 37, 20, 90, 48, 18, 28, 150, 170, 9, 30, 120 };
            otherSet1 = new Set<int> { 28, 37, 19, 45, 87, 93, 94, 12, 1234, 909 };
            otherSet2 = new Set<int> { 28, 37, 19 };
            array11 = new int[] { 37, 20, 90, 48, 18, 28, 150, 170, 9, 30, 120 };
            array8 = new int[] { 150, 98, 90, 95, 18, 180, 170, 160 };
        }

        [Test]
        public void AddTest()
        {
            var toAdd = new int[] { 37, 20, 90, 48, 18, 28, 150, 170, 9, 30, 120 };
            for (int i = 0; i < toAdd.Length; ++i)
            {
                set0.Add(toAdd[i]);
            }
            CollectionAssert.AreEquivalent(set0, array11);
            CollectionAssert.AreEquivalent(set11, array11);
            CollectionAssert.AreEquivalent(set8, array8);
        }

        [Test]
        public void ContainsTest()
        {
            for (int i = 0; i < array11.Length; ++i)
            {
                Assert.IsTrue(set11.Contains(array11[i]));
            }
        }

        [Test]
        public void ContainsAfterRemoveTest()
        {
            var keysToRemove = new int[] { 170, 9, 37 };
            foreach (var key in keysToRemove)
            {
                set11.Remove(key);
                Assert.IsFalse(set11.Contains(key));
            }
        }

        [Test]
        public void RemoveTestOnOneElement()
        {
            Assert.IsFalse(set1.Remove(8));
            Assert.IsTrue(set1.Remove(9));
            Assert.IsFalse(set1.Contains(9));
        }

        [Test]
        public void RemoveHeadOfBigTreeTest()
        {
            Assert.IsTrue(set11.Remove(37));
            Assert.IsFalse(set11.Contains(37));
            var result = new int[] { 9, 18, 20, 28, 30, 48, 90, 120, 150, 170 };
            CollectionAssert.AreEquivalent(set11, result);
        }

        [Test]
        public void RemoveManyElementsTest()
        {
            var toRemove = new int[] { 37, 20, 48, 170, 30, 9 };
            for (int i = 0; i < toRemove.Length; ++i)
            {
                set11.Remove(toRemove[i]);
            }
            var result = new int[] { 18, 28, 90, 120, 150 };
            CollectionAssert.AreEquivalent(set11, result);
        }

        [Test]
        public void ManyAddAndRemoveTest()
        {
            var toAdd = new int[] { 37, 20, 48, 170, 30, 9, 88, 45, 89, 53, 97, 37, 99, 33, 12, 890 };
            var toRemove = new int[] { 45, 48, 170, 890, 150, 98, 98, 98, 170, 890, 9, 20, 37, 53, 18 };
            var result = new int[] { 30, 88, 89, 97, 99, 33, 12, 90, 180, 160, 95 };
            Array.Sort(result);
            for (int i = 0; i < toAdd.Length; ++i)
            {
                set8.Add(toAdd[i]);
            }
            for (int i = 0; i < toRemove.Length; ++i)
            {
                set8.Remove(toRemove[i]);
            }
            CollectionAssert.AreEquivalent(set8, result);
        }

        [Test]
        public void ClearTest()
        {
            set1.Clear();
            Assert.IsTrue(set1.Count == 0);
        }

        [Test]
        public void Overlaps()
        {
            Assert.IsTrue(set8.Overlaps(set11));
            Assert.IsTrue(set5.Overlaps(set8));
            Assert.IsFalse(set11.Overlaps(set0));
            Assert.IsFalse(set1.Overlaps(set3));
            Assert.IsFalse(set4.Overlaps(set1));
        }

        [Test]
        public void IntersectWith()           
        {
            set11.IntersectWith(set8);
            var result = new int[] { 170, 150, 90, 18 };
            CollectionAssert.AreEquivalent(set11, result);
        }

        [Test]
        public void ExceptWith()
        {
            var toRemove = new int[] { 37, 20, 48, 170, 30, 9 };
            set11.ExceptWith(toRemove);            
            var result = new int[] { 18, 28, 90, 120, 150 };
            CollectionAssert.AreEquivalent(set11, result);
        }

        [Test]
        public void SymmetricExceptWithTest()
        {
            set11.SymmetricExceptWith(array8);
            var result = new int[] { 37, 20, 48, 28, 9, 30, 120, 98, 95, 180, 160 };
            Array.Sort(result);
            CollectionAssert.AreEquivalent(set11, result);
        }

        [Test]
        public void UnionWithTest()
        {
            set11.UnionWith(set8);
            set11.UnionWith(set5);
            set11.UnionWith(set4);
            set11.UnionWith(set1);
            set11.UnionWith(set0);
            var result = new int[] { 9, 37, 20, 90, 48, 18, 28, 150, 170, 30, 120, 98, 95, 180, 160, 10, 19, 57, 8, 58 };
            Array.Sort(result);
            CollectionAssert.AreEquivalent(set11, result);
        }

        [Test]
        public void SetEqualsTest()
        {
            var array1 = new int[] { 37, 20, 90, 48, 18, 150, 170, 9, 30, 120 };
            var array2 = new int[] { 37, 20, 90, 48, 18, 28, 150, 170, 9, 1, 30, 120 };
            Assert.IsFalse(set11.SetEquals(array1));
            Assert.IsFalse(set11.SetEquals(array2));
            Assert.IsTrue(set11.SetEquals(array11));
            Assert.IsTrue(set8.SetEquals(array8));
        }

        [Test]
        public void CorrectCopyToZeroArrayIndexTest()
        {
            var array = new int[11];
            set11.CopyTo(array, 0);
            var expected = new int[] { 37, 20, 90, 48, 18, 28, 150, 170, 9, 30, 120 };
            Array.Sort(expected);
            for (int i = 0; i < expected.Length; ++i)
            {
                Assert.AreEqual(expected[i], array[i]);
            }
        }

        [Test]
        public void CorrectCopyToNonZeroArrayIndexTest()
        {
            var array = new int[3] { 6, 7, 8 };
            var result = new int[] { 6, 7, 8, 9, 18, 20, 28, 30, 37, 48, 90, 120, 150, 170 };
            Array.Resize(ref array, 14);
            set11.CopyTo(array, 3);
            for (int i = 0; i < result.Length; ++i)
            {
                Assert.AreEqual(result[i], array[i]);
            }
        }

        [Test]
        public void InorrectCopyToTestTooShortArray()
        {
            var array = new int[5];
            Assert.Throws<IndexOutOfRangeException>(() => set11.CopyTo(array, 0));
        }

        [Test]
        public void IncorrectCopyToTestNegativeArrayIndex()
        {
            var array = new int[5];
            Assert.Throws<ArgumentOutOfRangeException>(() => set1.CopyTo(array, -1));
        }

        [Test]
        public void IsProperSubsetOfTest()
        {
            Assert.IsTrue(set3.IsProperSubsetOf(otherSet1));
            Assert.IsFalse(set3.IsProperSubsetOf(otherSet2));
        }

        [Test]
        public void IsSubsetOfTest()
        {
            Assert.IsTrue(set3.IsSubsetOf(otherSet1));
            Assert.IsTrue(set3.IsSubsetOf(otherSet2));
        }

        [Test]
        public void IsSupersetOfTest()
        {
            Assert.IsTrue(otherSet1.IsSupersetOf(set3));
            Assert.IsTrue(otherSet2.IsSupersetOf(set3));
        }

        [Test]
        public void IsProperSupersetOfTest()
        {
            Assert.IsTrue(otherSet1.IsProperSupersetOf(set3));
            Assert.IsFalse(otherSet2.IsProperSupersetOf(set3));
        }
    }
}