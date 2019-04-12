using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.Tests
{
    [TestClass]
    public class UniqueListTests
    {
        private UniqueList<int> list;

        [TestInitialize]
        public void Initialization()
        {
            list = new UniqueList<int>();
            list.AddNode(-3);
            list.AddNode(-2);
            list.AddNode(-1);
            list.AddNode(0);
            list.AddNode(1);
            list.AddNode(2);
            list.AddNode(3);
        }

        [DataRow(-5)]
        [DataRow(7)]
        [DataRow(4)]
        [DataRow(-8)]
        [TestMethod]
        public void CorrectAdd(int value)
        {
            list.AddNode(value);
            Assert.AreEqual(value, list.GetValue(1));
        }

        [TestMethod]
        public void CorrectDeleteTest1()
        {
            list.DeleteNode(-3);
            Assert.AreEqual("3 2 1 0 -1 -2 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void CorrectDeleteTest2()
        {
            list.DeleteNode(1);
            list.DeleteNode(3);
            Assert.AreEqual("2 0 -1 -2 -3 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void CorrectDeleteTest3()
        {
            list.DeleteNode(-2);
            list.DeleteNode(0);
            list.DeleteNode(-1);
            Assert.AreEqual("3 2 1 -3 ", list.GetStringOfListElements());
        }


        [DataRow(4, 1)]
        [DataRow(6, 2)]
        [DataRow(9, 7)]
        [DataRow(-5, 6)]
        [DataRow(-44, 4)]
        [TestMethod]
        public void CorrectSet(int value, int position)
        {
            list.SetValue(value, position);
            Assert.AreEqual(value, list.GetValue(position));
        }

        [TestMethod]
        [ExpectedException(typeof(AddExistingNodeException))]
        public void AddExistingNodeToBegin()
        {
            list.AddNode(3);
        }

        [TestMethod]
        [ExpectedException(typeof(AddExistingNodeException))]
        public void AddExistingNodeToEnd()
        {
            list.AddNode(-3);
        }

        [DataRow(0)]
        [DataRow(-2)]
        [DataRow(2)]
        [DataRow(1)]
        [DataRow(-1)]
        [TestMethod]
        [ExpectedException(typeof(AddExistingNodeException))]
        public void AddExistingNodeInTheMiddle(int value)
        {
            list.AddNode(value);
        }

        [DataRow(-8)]
        [DataRow(4)]
        [DataRow(-4)]
        [DataRow(7)]
        [TestMethod]
        [ExpectedException(typeof(DeleteNonExistentNodeException))]
        public void DeleteNonExistentNode(int value)
        {
            list.DeleteNode(value);
        }

        [TestMethod]
        [ExpectedException(typeof(DeleteNonExistentNodeException))]
        public void DeleteFromEmptyList()
        {
            list.Clear();
            list.DeleteNode(2);
        }

        [DataRow(3, 1)]
        [DataRow(-1, 2)]
        [DataRow(1, 7)]
        [DataRow(0, 3)]
        [DataRow(-3, 5)]
        [DataRow(-2, 4)]
        [TestMethod]
        [ExpectedException(typeof(ImpossibleSetException))]
        public void SetExistingValue(int value, int position)
        {
            list.SetValue(value, position);
        }
    }
}
