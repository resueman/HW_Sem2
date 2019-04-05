using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Tests
{
    [TestClass]
    public class StackList
    {
        StackList<int> stack;

        [TestInitialize]
        public void Initialization()
        {
            stack = new StackList<int>();
        }

        [TestMethod]
        [ExpectedException(typeof(StackIsEmptyException))]
        public void PopFromEmptyStack()
        {
            stack.Pop();
        }

        [TestMethod]
        public void PopTestWithTwoElemets()
        {
            stack.Push(666);
            stack.Push(-666);
            Assert.AreEqual(-666, stack.Pop());
            Assert.AreEqual(666, stack.Pop());
        }

        [TestMethod]
        public void PushAndPopTestsWithManyElements()
        {
            for (int i = -1000000; i < 1000001; ++i)
            {
                stack.Push(i);
            }
            for (int i = 1000000; i > -1000001; --i)
            {
                Assert.AreEqual(i, stack.Pop());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(StackIsEmptyException))]
        public void GetTopOfEmptyStack()
        {
            stack.Top();
        }

        [TestMethod]
        public void GetTopOfNotEmptyStack()
        {
            stack.Push(100);
            stack.Push(222);
            Assert.AreEqual(222, stack.Top());
        }

        [TestMethod]
        public void CheckThatTopDoesNotPop()
        {
            stack.Push(111);
            stack.Push(222);
            stack.Push(333);
            Assert.AreEqual(333, stack.Top());
            stack.Pop();
            Assert.AreEqual(222, stack.Top());
        }

        [TestMethod]
        public void CheckIsEmptyMethodStack()
        {
            Assert.IsTrue(stack.IsEmpty());
            stack.Push(666);
            Assert.IsFalse(stack.IsEmpty());
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
        }
    }
}
