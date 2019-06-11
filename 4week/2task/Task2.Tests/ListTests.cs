using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.Tests
{
    /// <summary>
    /// Class that tests the correctness of list functions
    /// </summary>
    [TestClass]
    public class ListTests
    {
        private List<int> emptyList;
        private List<int> list;

        [TestInitialize]
        public void Initialization()
        {
            emptyList = new List<int>();
            list = new List<int>();

            list.Add(105, 1);
            list.Add(267, 2);
            list.Add(657, 3);
            list.Add(987, 4);
            list.Add(453, 3);
            list.Add(65, 1);
            list.Add(1004, 7);
            list.Add(543, 5);
        }

        [TestMethod]
        public void IsEmptyOnEmptyList()
        {
            Assert.IsTrue(emptyList.IsEmpty());
            Assert.IsTrue(emptyList.Length == 0);
        }

        [TestMethod]
        public void IsEmptyAfterAddAndDelete()
        {
            for (int i = 0; i < 100; ++i)
            {
                emptyList.Add(i, 1);
            }
            for (int i = 0; i < 100; ++i)
            {
                emptyList.DeleteByPosition(1);
            }
            Assert.IsTrue(emptyList.IsEmpty());
            Assert.IsTrue(emptyList.Length == 0);
            Assert.AreEqual("List is empty", emptyList.GetStringOfListElements());
        }

        [TestMethod]
        public void CorrectAdd()
        {
            Assert.AreEqual("65 105 267 453 543 657 987 1004 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void DeleteFirstElement()
        {
            list.DeleteByPosition(1);
            Assert.AreEqual("105 267 453 543 657 987 1004 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void DeleteLastElement()
        {
            list.DeleteByPosition(8);
            Assert.AreEqual("65 105 267 453 543 657 987 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void DeleteSeveralElementsFromTheMiddle()
        {
            var positions = new int[] { 7, 3, 3, 4 };
            for (int i = 0; i < 4; ++i)
            {
                list.DeleteByPosition(positions[i]);
            }
            Assert.AreEqual("65 105 543 1004 ", list.GetStringOfListElements());
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPositionException))]
        public void IncorrectDelete()
        {
            var positions = new int[] { 1, 7, 3, 3, 4, 4 };
            for (int i = 0; i < 6; ++i)
            {
                list.DeleteByPosition(positions[i]);
            }
            Assert.AreEqual("105 267 657 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void CorrectDeleteManyElements()
        {
            var positions = new int[] { 1, 7, 3, 3, 4, 1 };
            for (int i = 0; i < 6; ++i)
            {
                list.DeleteByPosition(positions[i]);
            }
            Assert.AreEqual("267 657 ", list.GetStringOfListElements());
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPositionException))]
        public void AddToIncorrectPositionMoreThanLengthPlusOne()
        {
            list.Add(4, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPositionException))]
        public void AddToIncorrectZeroPosition()
        {
            list.Add(4, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPositionException))]
        public void DeleteFromIncorrectPositionMoreThanLength()
        {
            emptyList.Add(1, 1);
            emptyList.Add(2, 2);
            emptyList.Add(3, 3);
            emptyList.DeleteByPosition(4);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPositionException))]
        public void DeleteFromIncorrectZeroPosition()
        {
            list.DeleteByPosition(0);
        }

        [TestMethod]
        public void ClearFunctionTest()
        {
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPositionException))]
        public void IncorrectSetToZeroPosition()
        {
            list.SetValue(7, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPositionException))]
        public void IncorrectSetToPositionMoreThanLength()
        {
            list.SetValue(8, 9);
        }

        [TestMethod]
        public void SetValueTest()
        {
            list.SetValue(11, 1);
            list.SetValue(12, 2);
            list.SetValue(13, 3);
            list.SetValue(16, 4);
            list.SetValue(24, 5);
            list.SetValue(45, 6);
            list.SetValue(56, 7);
            list.SetValue(72, 8);
            Assert.AreEqual("11 12 13 16 24 45 56 72 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void GetValueFromMiddlePosition()
        {
            Assert.AreEqual(453, list.GetValue(4));
        }

        [TestMethod]
        public void GetFirstValue()
        {
            Assert.AreEqual(65, list.GetValue(1));
        }

        [TestMethod]
        public void GetLastValue()
        {
            Assert.AreEqual(1004, list.GetValue(8));
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPositionException))]
        public void GetValueOfIncorrectZeroPosition()
        {
            list.GetValue(0);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPositionException))]
        public void GetValueOfIncorrectPositionMoreThanLength()
        {
            list.GetValue(9);
        }
    }
}
