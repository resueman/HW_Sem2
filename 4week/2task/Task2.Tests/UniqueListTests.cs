using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.Tests
{
    /// <summary>
    /// Class which tests the correctness of unique list functions
    /// </summary>
    [TestClass]
    public class UniqueListTests
    {
        private UniqueList<int> list;

        [TestInitialize]
        public void Initialization()
        {
            list = new UniqueList<int>();
            list.Add(-3);
            list.Add(-2);
            list.Add(-1);
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
        }

        [DataRow(-5)]
        [DataRow(7)]
        [DataRow(4)]
        [DataRow(-8)]
        [TestMethod]
        public void CorrectAdd(int value)
        {
            list.Add(value);
            Assert.AreEqual(value, list.GetValue(1));
        }

        [TestMethod]
        public void DeleteFirstElementByValue()
        {
            list.Delete(-3);
            Assert.AreEqual("3 2 1 0 -1 -2 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void DeleteLastElementByValue()
        {
            list.Delete(1);
            list.Delete(3);
            Assert.AreEqual("2 0 -1 -2 -3 ", list.GetStringOfListElements());
        }

        [TestMethod]
        public void DeleteSeveralElementsFromTheMiddleByValue()
        {
            list.Delete(-2);
            list.Delete(0);
            list.Delete(-1);
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
            list.Add(3);
        }

        [TestMethod]
        [ExpectedException(typeof(AddExistingNodeException))]
        public void AddExistingNodeToEnd()
        {
            list.Add(-3);
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
            list.Add(value);
        }

        [DataRow(-8)]
        [DataRow(4)]
        [DataRow(-4)]
        [DataRow(7)]
        [TestMethod]
        [ExpectedException(typeof(DeleteNonExistentNodeException))]
        public void DeleteNonExistentNode(int value)
        {
            list.Delete(value);
        }

        [TestMethod]
        [ExpectedException(typeof(DeleteNonExistentNodeException))]
        public void DeleteFromEmptyList()
        {
            list.Clear();
            list.Delete(2);
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
