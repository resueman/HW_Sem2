using NUnit.Framework;

namespace Task2
{
    /// <summary>
    /// Class that checks the correctness of the list functions
    /// </summary>
    public class ListTests
    {
        private List<int> list;
        private List<int> emptyList;

        [SetUp]
        public void Setup()
        {
            emptyList = new List<int>();
            list = new List<int>();

            list.AddNode(105, 1);
            list.AddNode(267, 2);
            list.AddNode(657, 3);
            list.AddNode(987, 4);
            list.AddNode(453, 3);
            list.AddNode(65, 1);
            list.AddNode(1004, 7);
            list.AddNode(543, 5);
        }

        [Test]
        public void IsEmptyOnEmptyList()
        {
            Assert.IsTrue(emptyList.IsEmpty() && emptyList.Length == 0);
        }

        [Test]
        public void IsEmptyAfterAddAndDelete()
        {
            for (int i = 0; i < 100; ++i)
            {
                emptyList.AddNode(i, 1);
            }
            for (int i = 0; i < 100; ++i)
            {
                emptyList.DeleteNode(1);
            }
            Assert.IsFalse(emptyList.IsEmpty() && emptyList.Length == 1);
        }

        [Test]
        public void CheckAddTest1()
        {
            Assert.AreEqual("65 105 267 453 543 657 987 1004 ", list.GetStringOfListElements());
        }

        [TestCase(2, 9)]
        [TestCase(544, 8)]
        [TestCase(653, 3)]
        [TestCase(536, 2)]
        [TestCase(783, 1)]
        [Test]
        public void CheckAddTest2(int value, int position)
        {
            list.AddNode(value, position);
            Assert.AreEqual(list.GetValue(position), value);
        }

        [Test]
        public void CorrectDeleteTest1()
        {
            list.DeleteNode(1);
            Assert.AreEqual("105 267 453 543 657 987 1004 ", list.GetStringOfListElements());
        }

        [Test]
        public void CorrectDeleteTest2()
        {
            list.DeleteNode(1);
            list.DeleteNode(7);
            Assert.AreEqual("105 267 453 543 657 987 ", list.GetStringOfListElements());
        }

        [Test]
        public void CorrectDeleteTest3()
        {
            list.DeleteNode(1);
            list.DeleteNode(7);
            list.DeleteNode(3);
            Assert.AreEqual("105 267 543 657 987 ", list.GetStringOfListElements());
        }

        [Test]
        public void CorrectDeleteTest4()
        {
            var positions = new int[] { 1, 7, 3, 3 };
            for (int i = 0; i < 4; ++i)
            {
                list.DeleteNode(positions[i]);
            }
            Assert.AreEqual("105 267 657 987 ", list.GetStringOfListElements());
        }

        [Test]
        public void CorrectDeleteTest5()
        {
            var positions = new int[] { 1, 7, 3, 3, 4 };
            for (int i = 0; i < 5; ++i)
            {
                list.DeleteNode(positions[i]);
            }
            Assert.AreEqual("105 267 657 ", list.GetStringOfListElements());
        }

        [Test]
        public void CorrectDeleteTest7()
        {
            var positions = new int[] { 1, 7, 3, 3, 4, 1 };
            for (int i = 0; i < 6; ++i)
            {
                list.DeleteNode(positions[i]);
            }
            Assert.AreEqual("267 657 ", list.GetStringOfListElements());
        }

        [Test]
        public void CorrectDeleteTest8()
        {
            var positions = new int[] { 1, 7, 3, 3, 4, 1, 2 };
            for (int i = 0; i < 7; ++i)
            {
                list.DeleteNode(positions[i]);
            }
            Assert.AreEqual("267 ", list.GetStringOfListElements());
        }

        [Test]
        public void CorrectDeleteTest9()
        {
            var positions = new int[] { 1, 7, 3, 3, 4, 1, 2, 1 };
            for (int i = 0; i < 8; ++i)
            {
                list.DeleteNode(positions[i]);
            }
            Assert.AreEqual("List is empty", list.GetStringOfListElements());
        }

        [TestCase(4, 12)]
        [TestCase(2, 11)]
        [TestCase(9873, 10)]
        [TestCase(14, -9)]
        [TestCase(34, -1)]
        [TestCase(489, 0)]
        [Test]
        public void AddToIncorrectPosition(int value, int position)
        {
            Assert.Throws<IncorrectPositionException>(() => { list.AddNode(value, position); });
        }

        [TestCase(10)]
        [TestCase(9)]
        [TestCase(-2)]
        [TestCase(-1)]
        [TestCase(0)]
        [Test]
        public void DeleteFromIncorrectPosition(int position)
        {
            Assert.Throws<IncorrectPositionException>(() => { emptyList.DeleteNode(position); });
        }

        [Test]
        public void ClearFunctionTest()
        {
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
        }

        [TestCase(4, 12)]
        [TestCase(2, 11)]
        [TestCase(9873, 10)]
        [TestCase(14, -9)]
        [TestCase(34, -1)]
        [TestCase(489, 0)]
        [Test]
        public void SetToIncorrectPosition(int value, int position)
        {
            Assert.Throws<IncorrectPositionException>(() => { list.SetValue(value, position); });
        }

        [TestCase(10)]
        [TestCase(9)]
        [TestCase(-2)]
        [TestCase(-1)]
        [TestCase(0)]
        [Test]
        public void GetValueFromIncorrectPosition(int position)
        {
            Assert.Throws<IncorrectPositionException>(() => { list.GetValue(position); });
        }

        [TestCase(11, 1)]
        [TestCase(12, 2)]
        [TestCase(13, 3)]
        [TestCase(16, 4)]
        [TestCase(24, 5)]
        [TestCase(45, 6)]
        [TestCase(56, 7)]
        [TestCase(72, 8)]
        [Test]
        public void SetValueTest(int value, int position)
        {
            list.SetValue(value, position);
            Assert.AreEqual(value, list.GetValue(position));
        }

        [TestCase(65, 1)]
        [TestCase(105, 2)]
        [TestCase(267, 3)]
        [TestCase(453, 4)]
        [TestCase(543, 5)]
        [TestCase(657, 6)]
        [TestCase(987, 7)]
        [TestCase(1004, 8)]
        [Test]
        public void GetValueTest(int result, int position)
        {
            Assert.AreEqual(result, list.GetValue(position));
        }
    }
}
