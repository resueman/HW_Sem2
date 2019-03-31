using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2.Tests
{
    [TestClass]
    public class UniqueList
    {
        UniqueList<int> list;

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

        [TestMethod]
        [ExpectedException(typeof(AddExistingNodeException))]
        public void AddExistingNodeInTheMiddleTest1()
        {
            list.AddNode(0);
        }

        [TestMethod]
        [ExpectedException(typeof(AddExistingNodeException))]
        public void AddExistingNodeInTheMiddleTest2()
        {
            list.AddNode(-2);
        }

        [TestMethod]
        [ExpectedException(typeof(AddExistingNodeException))]
        public void AddExistingNodeInTheMiddleTest3()
        {
            list.AddNode(2);
        }

        [TestMethod]
        [ExpectedException(typeof(DeleteNonExistentNodeException))]
        public void DeleteNonExistentNodeTest1()
        {
            list.DeleteNode(4);
        }

        [TestMethod]
        [ExpectedException(typeof(DeleteNonExistentNodeException))]
        public void DeleteNonExistentNodeTest2()
        {
            list.DeleteNode(-8);
        }

        [TestMethod]
        [ExpectedException(typeof(DeleteNonExistentNodeException))]
        public void DeleteFromEmptyList()
        {
            list.Clear();
            list.DeleteNode(2);
        }
    }
}
