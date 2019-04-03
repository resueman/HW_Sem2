using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.Tests
{
    [TestClass]
    public class List
    {
        List<int> emptyList;
        List<int> list;

        [TestInitialize]
        public void Initialization()
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

        [TestMethod]
        public void IsEmptyOnEmptyList()
        {
            Assert.IsTrue(emptyList.IsEmpty() && emptyList.GetLengthOfList() == 0);
        }

        [TestMethod]
        public void IsEmptyAfterAddAndDelete()
        {
            for (int i = 0; i < 100; ++i)
            {
                emptyList.AddNode(i, 1);
            }
            for (int i = 0; i < 100; ++i)
            {
                emptyList.DeleteNodeByPosition(1);
            }
            Assert.IsFalse(emptyList.IsEmpty() && emptyList.GetLengthOfList() == 1);
        }

        [TestMethod]
        public void CorrectAdd()
        {
            Assert.AreEqual("65 105 267 453 543 657 987 1004 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void CorrectDeleteTest1()
        {
            list.DeleteNodeByPosition(1);
            Assert.AreEqual("105 267 453 543 657 987 1004 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void CorrectDeleteTest2()
        {
            list.DeleteNodeByPosition(1);
            list.DeleteNodeByPosition(7);
            Assert.AreEqual("105 267 453 543 657 987 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void CorrectDeleteTest3()
        {
            list.DeleteNodeByPosition(1);
            list.DeleteNodeByPosition(7);
            list.DeleteNodeByPosition(3);
            Assert.AreEqual("105 267 543 657 987 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void CorrectDeleteTest4()
        {
            list.DeleteNodeByPosition(1);
            list.DeleteNodeByPosition(7);
            list.DeleteNodeByPosition(3);
            list.DeleteNodeByPosition(3);
            Assert.AreEqual("105 267 657 987 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void CorrectDeleteTest5()
        {
            list.DeleteNodeByPosition(1);
            list.DeleteNodeByPosition(7);
            list.DeleteNodeByPosition(3);
            list.DeleteNodeByPosition(3);
            list.DeleteNodeByPosition(4);
            Assert.AreEqual("105 267 657 ", list.GetStringOfListElements());
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPositionException))]
        public void IncorrectDelete()
        {
            list.DeleteNodeByPosition(1);
            list.DeleteNodeByPosition(7);
            list.DeleteNodeByPosition(3);
            list.DeleteNodeByPosition(3);
            list.DeleteNodeByPosition(4);
            list.DeleteNodeByPosition(4);
            Assert.AreEqual("105 267 657 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void CorrectDeleteTest7()
        {
            list.DeleteNodeByPosition(1);
            list.DeleteNodeByPosition(7);
            list.DeleteNodeByPosition(3);
            list.DeleteNodeByPosition(3);
            list.DeleteNodeByPosition(4);
            list.DeleteNodeByPosition(1);
            Assert.AreEqual("267 657 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void CorrectDeleteTest8()
        {
            list.DeleteNodeByPosition(1);
            list.DeleteNodeByPosition(7);
            list.DeleteNodeByPosition(3);
            list.DeleteNodeByPosition(3);
            list.DeleteNodeByPosition(4);
            list.DeleteNodeByPosition(1);
            list.DeleteNodeByPosition(2);
            Assert.AreEqual("267 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void CorrectDeleteTest9()
        {
            list.DeleteNodeByPosition(1);
            list.DeleteNodeByPosition(7);
            list.DeleteNodeByPosition(3);
            list.DeleteNodeByPosition(3);
            list.DeleteNodeByPosition(4);
            list.DeleteNodeByPosition(1);
            list.DeleteNodeByPosition(2);
            list.DeleteNodeByPosition(1);
            Assert.AreEqual("List is empty", list.GetStringOfListElements());
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPositionException))]
        public void AddToIncorrectPositionMoreThanLengthPlusOne()
        {
            list.AddNode(4, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPositionException))]
        public void AddToIncorrectZeroPosition()
        {
            list.AddNode(4, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPositionException))]
        public void DeleteFromIncorrectPositionMoreThanLength()
        {
            emptyList.AddNode(1, 1);
            emptyList.AddNode(2, 2);
            emptyList.AddNode(3, 3);
            emptyList.DeleteNodeByPosition(4);
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectPositionException))]
        public void DeleteFromIncorrectZeroPosition()
        {
            list.DeleteNodeByPosition(0);
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
        public void GetValueTest1()
        {
            Assert.AreEqual(453, list.GetValue(4));
        }

        [TestMethod]
        public void GetValueTest2()
        {
            Assert.AreEqual(65, list.GetValue(1));
        }

        [TestMethod]
        public void GetValueTest3()
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
