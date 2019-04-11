using NUnit.Framework;

namespace Task2
{    
    public class HashTableTests
    {
        private HashTable<int> set;
        private HashTable<int> emptySet;

        [SetUp]
        public void Setup()
        {
            emptySet = new HashTable<int>(new NoNameHashFunction<int>());
            set = new HashTable<int>(new NoNameHashFunction<int>());
            for (int i = -50; i < 51; ++i)
            {
                set.AddToSet(i);
            }
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(98)]
        [TestCase(10000)]
        [TestCase(42)]
        [TestCase(5)]
        [Test]
        public void IsExistOnEmptySet(int key)
        {
            Assert.IsFalse(emptySet.IsExist(key));
        }

        [TestCase(-51)]
        [TestCase(51)]
        [TestCase(100)]
        [TestCase(-100)]
        [TestCase(55)]
        [TestCase(89890343)]
        [TestCase(-73647647)]
        [TestCase(1234567)]
        [Test]
        public void CheckIsExistsOnNonExistentValue(int key)
        {
            Assert.IsFalse(set.IsExist(key));
        }

        [TestCase(-50)]
        [TestCase(50)]
        [TestCase(10)]
        [TestCase(-15)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(12)]
        [Test]
        public void CheckIsExistsOnExistentValue(int key)
        {
            Assert.IsTrue(set.IsExist(key));
        }

        [Test]
        public void CheckAllKeysOnExsistence()
        {
            for (int i = -50; i < 51; ++i)
            {
                Assert.IsTrue(set.IsExist(i));
            }
        }

        [Test]
        public void IsExistsOnExistentValueAfterManyAdditions()
        {
            for (int i = -1000000; i < 1000001; ++i)
            {
                emptySet.AddToSet(i);
            }

            for (int i = -1000000; i < 1000001; ++i)
            {
                Assert.IsTrue(emptySet.IsExist(i));
            }
        }

        [Test]
        public void AddExistingKey()
        {
            for (int i = -10; i < 11; ++i)
            {
                Assert.IsFalse(set.AddToSet(i));
            }
        }

        [TestCase(6)]
        [TestCase(-18)]
        [TestCase(0)]
        [TestCase(50)]
        [TestCase(-50)]
        [TestCase(34)]
        [TestCase(-49)]
        [TestCase(-47)]
        [TestCase(-48)]
        [TestCase(45)]
        [TestCase(46)]
        [Test]
        public void DeleteExistingKey(int key)
        {
            set.DeleteFromSet(key);
            Assert.IsFalse(set.IsExist(key));
        }

        [TestCase(2347654)]
        [TestCase(-75)]
        [TestCase(-87654)]
        [TestCase(435)]
        [TestCase(51)]
        [TestCase(-51)]
        [Test]
        public void DeleteNonExistentKey(int key)
        {
            Assert.IsFalse(set.DeleteFromSet(key));
        }

        [TestCase(1432654)]
        [TestCase(677667686)]
        [TestCase(987)]
        [TestCase(43)]
        [TestCase(-75354)]
        [TestCase(-9)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(-3)]
        [Test]
        public void DeleteAfterAddTest(int key)
        {
            emptySet.AddToSet(key);
            emptySet.DeleteFromSet(key);
            Assert.IsFalse(emptySet.IsExist(key));
        }
    }
}