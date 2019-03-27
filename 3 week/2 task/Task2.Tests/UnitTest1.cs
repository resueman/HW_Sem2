using NUnit.Framework;

namespace Task2
{
    public class Tests
    {
        HashTable<int> set;
        HashTable<int> emptySet;

        [SetUp]
        public void Setup()
        {
            emptySet = new HashTable<int>();
            set = new HashTable<int>();
            for (int i = -10; i < 11; ++i)
            {
                set.AddToSet(i);
            }
        }

        [Test]
        public void IsExistOnEmptySet()
        {
            Assert.IsFalse(emptySet.IsExist(0));
        }

        [Test]
        public void CheckIsExistsOnNonExistentValue()
        {
            Assert.IsFalse(set.IsExist(11));
            Assert.IsFalse(set.IsExist(-11));
        }

        [Test]
        public void CheckIsExistsOnExistentValueOneKey()
        {
            Assert.IsTrue(set.IsExist(0));
        }

        [Test]
        public void IsExistsOnExistentValueAfterManyAdditions()
        {
            for (int i = -10000; i < 10001; ++i)
            {
                emptySet.AddToSet(i);
            }

            for (int i = -10000; i < 10001; ++i)
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

        [Test]
        public void AddNonExistentKey()
        {
            set.AddToSet(111);
            Assert.IsTrue(set.IsExist(111));
        }

        [Test]
        public void DeleteExistingKey()
        {
            set.DeleteFromSet(0);
            Assert.IsFalse(set.IsExist(0));
        }

        [Test]
        public void DeleteNonExistentKey()
        {
            Assert.IsFalse(set.DeleteFromSet(862));
        }

        [Test]
        public void DeleteAfterAddTest()
        {
            set.AddToSet(88);
            set.DeleteFromSet(88);
            Assert.IsFalse(set.IsExist(88));
        }
    }
}